#include "common.h"

struct I2CInfo
{
	uint32_t FreqFlag;
};

static struct I2CInfo info[SUSI_I2C_MAX_DEVICE];
static SusiId_t devids[SUSI_I2C_MAX_DEVICE];
static const uint8_t maxdevice = NELEMS(devids);

enum funcRank{
	funcDev,
	funcProbe,
	funcRead,
	funcWrite,
	funcWtRd,
	funcFreq,
	NumFunc,
};

static int8_t functions[NumFunc + 1];

enum addrtypeRank{
	addrtype7,
	addrtype10,
	NumAddrType,
};

enum cmdtypeRank{
	cmdtypeByte,
	cmdtypeWord,
	cmdtypeNone,
	NumCmdType,
};

struct I2CConf{
	enum addrtypeRank addrType;
	uint32_t addr;
	enum cmdtypeRank cmdType;
	uint32_t cmd;
	uint8_t *wdata;
	uint32_t wlen;
	uint8_t *rdata;
	uint32_t rlen;
	
};

enum funcReadWriteRank{
	funcReadWriteAddr,
	funcReadWriteCmd,	
	funcReadWriteRdLen,
	funcReadWriteWtData,
	funcReadWriteRun,
	NumFuncReadWrite,
};

enum funcFrequencyRank{
	funcFrequencySet100,
	funcFrequencySet400,
	funcFrequencyGet,
	NumFuncFrequency,
};

uint8_t iic_init(void)
{
	SusiStatus_t status;
	uint32_t tmp;
	uint8_t index, i;

	status = SusiBoardGetValue(SUSI_ID_I2C_SUPPORTED, &tmp);
	if (status != SUSI_STATUS_SUCCESS)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	if (!tmp)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	index = 0;	/* index for devices */
	for (i = 0; i < maxdevice; i++)
	{
		if (tmp & (1 << i))
		{
			uint32_t tmp2;
			if (SusiI2CGetFrequency(i, &tmp2) == SUSI_STATUS_SUCCESS)
				info[index].FreqFlag = 1;
			else
				info[index].FreqFlag = 0;

			devids[index++] = i;
		}
	}
	
	if (!index)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	while (index < maxdevice)
		devids[index++] = SUSIDEMO_DEVICEID_UNDEFINED;

	index = 0;	/* index for I2C functions */
	functions[index++] = SUSIDEMO_FUNCTIONS_GOBACK;
	functions[index++] = funcDev;
	functions[index++] = funcProbe;
	functions[index++] = funcRead;
	functions[index++] = funcWrite;
	functions[index++] = funcWtRd;

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static void title(const char *name)
{
	printf(
		"**********************************************\n"
		"**               SUSI4.0 demo               **\n"
		"**********************************************\n\n");

	printf("%s\n\n", name);
}

static uint8_t iic_host(uint8_t *iDevice)
{
	if (*iDevice == 0 && devids[1] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		printf("Only an I2C host.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	if (*iDevice + 1 >= maxdevice)
	{
		*iDevice = 0;
		return SUSIDEMO_PRINT_NONE;
	}

	if (devids[*iDevice + 1] != SUSIDEMO_DEVICEID_UNDEFINED)
	{
		(*iDevice)++;
		return SUSIDEMO_PRINT_NONE;
	}

	*iDevice = 0;
	return SUSIDEMO_PRINT_NONE;
}

static uint8_t iic_probe(uint8_t iDevice, enum addrtypeRank addrType)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;
	uint32_t shiftaddr;
	uint8_t n;
	uint16_t i;

	n = 0;
	if (addrType == addrtype7)
	{
		for (i = 0x03; i < 0x78; i++)
		{
			shiftaddr = SUSI_I2C_ENC_7BIT_ADDR(i);
			status = SusiI2CProbeDevice(id, shiftaddr);
			if (status == SUSI_STATUS_SUCCESS)
			{
				printf("%02X ", shiftaddr);
				n++;
			}
		}
	}
	else if (addrType == addrtype10)
	{
		for (i = 0; i < 0x400; i++)
		{
			shiftaddr = SUSI_I2C_ENC_10BIT_ADDR(i);
			status = SusiI2CProbeDevice(id, shiftaddr);
			if (status == SUSI_STATUS_SUCCESS)
			{			
				printf("%04X ", i);
				n++;
			}
		}
	}
	
	if (!n)
	{
		printf("Found no device.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("\n");

	return SUSIDEMO_PRINT_SUCCESS;
}

static void menu_probe(void)
{
	printf(
		"Probe:\n\n"
		"0) Back to I2C menu\n"
		"1) Probe 7-bit address\n"
		"2) Probe 10-bit address\n"
		"\nEnter your choice: ");
	fflush(stdout);
}

static uint8_t iic_probe_loop(uint8_t iDevice, const char *devName)
{
	uint32_t op;
	int8_t manuItem[NumAddrType + 1];

	manuItem[0] = SUSIDEMO_FUNCTIONS_GOBACK;
	manuItem[1] = addrtype7;
	manuItem[2] = addrtype10;

	while (1)
	{
		clr_screen();
		title(devName);
		menu_probe();

		if (input_uint(&op, 10, NELEMS(manuItem), 0))
			goto unknown;

		switch (manuItem[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return SUSIDEMO_PRINT_NONE;

		case addrtype7:
			if (iic_probe(iDevice, addrtype7))
				goto pause;
			continue;

		case addrtype10:
			if (iic_probe(iDevice, addrtype10))
				goto pause;
			continue;
		}
unknown:
		printf("Unknown choice!\n");
pause:
		printf("\nPress ENTER to continue. ");
		wait_enter();
	}
}

static uint8_t iic_read(uint8_t iDevice, struct I2CConf config)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;
	uint32_t i;

	if (config.addrType == addrtype10)
		config.addr = SUSI_I2C_ENC_EXT_CMD(config.addr);

	if (config.cmdType == cmdtypeWord)
		config.cmd = SUSI_I2C_ENC_EXT_CMD(config.cmd);
	else if (config.cmdType == cmdtypeNone)
		config.cmd = SUSI_I2C_NO_CMD;

	status = SusiI2CReadTransfer(id, config.addr, config.cmd, config.rdata, config.rlen);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("Read transfer failed. (0x%08X)\n", status); 
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("Data (Hex):\n");
	for (i = 0; i < config.rlen; i++)
	{
		if (i < config.rlen - 1)
			printf("%02X ", config.rdata[i]);
		else
			printf("%02X\n", config.rdata[i]);
	}

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t iic_write(uint8_t iDevice, struct I2CConf config)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;

	if (config.addrType == addrtype10)
		config.addr = SUSI_I2C_ENC_EXT_CMD(config.addr);

	if (config.cmdType == cmdtypeWord)
		config.cmd = SUSI_I2C_ENC_EXT_CMD(config.cmd);
	else if (config.cmdType == cmdtypeNone)
		config.cmd = SUSI_I2C_NO_CMD;

	status = SusiI2CWriteTransfer(id, config.addr, config.cmd, config.wdata, config.wlen);

	if (status != SUSI_STATUS_SUCCESS)
	{		
		printf("Write transfer failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("Write transfer succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t iic_writeread(uint8_t iDevice, struct I2CConf config)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;
	uint32_t i;

	if (config.addrType == addrtype10)
		config.addr = SUSI_I2C_ENC_EXT_CMD(config.addr);

	if (config.cmdType == cmdtypeWord)
		config.cmd = SUSI_I2C_ENC_EXT_CMD(config.cmd);
	else if (config.cmdType == cmdtypeNone)
		config.cmd = SUSI_I2C_NO_CMD;

	status = SusiI2CWriteReadCombine(id, config.addr, config.wdata, config.wlen, config.rdata, config.rlen);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("Write&Read combine failed. (0x%08X)\n", status);		
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("Data (Hex):\n");
	for (i = 0; i < config.rlen; i++)
	{
		if (i < config.rlen - 1)
			printf("%02X ", config.rdata[i]);
		else
			printf("%02X\n", config.rdata[i]);
	}

	if (!i)
		printf("Write&Read combine succeed.\n");

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t get_frequency(uint8_t iDevice, uint32_t *freq)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;

	status = SusiI2CGetFrequency(id, freq);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("Get no frequency. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t set_frequency(uint8_t iDevice, uint32_t freq)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;

	status = SusiI2CSetFrequency(id, freq);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiI2CSetFrequency() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiI2CSetFrequency() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static void menu_readwrite(int8_t *manuItem, uint8_t numManuItem, enum funcRank iFunc, struct I2CConf config)
{
	uint8_t i;

	if (iFunc == funcRead)
		printf("Read Data:\n\n");
	else if (iFunc == funcWrite)
		printf("Write Data:\n\n");
	else if (iFunc == funcWtRd)
		printf("Write and Read Data:\n\n");

	manuItem[0] = SUSIDEMO_FUNCTIONS_GOBACK;
	printf("0) Back to I2C menu\n");

	i = 1;
	
	manuItem[i] = funcReadWriteAddr;
	if (config.addrType == addrtype7)
		printf("%u) Slave Address: 0x%02X (7-bit)\n", i, config.addr);
	else
		printf("%u) Slave Address: 0x%04X (10-bit)\n", i, config.addr);
	i++;

	if (iFunc != funcWtRd)
	{
		manuItem[i] = funcReadWriteCmd;
		if (config.cmdType == cmdtypeByte)
			printf("%u) Command: 0x%02X (Byte-type)\n", i, config.cmd);
		else if (config.cmdType == cmdtypeWord)
			printf("%u) Command: 0x%04X (Word-type)\n", i, config.cmd);
		else if (config.cmdType == cmdtypeNone)
			printf("%u) Command: None\n", i);
		i++;
	}

	if (iFunc == funcRead || iFunc == funcWtRd)
	{
		manuItem[i] = funcReadWriteRdLen;
		printf("%u) Read Data Length: %u\n", i, config.rlen);
		i++;
	}

	if (iFunc == funcWrite || iFunc == funcWtRd)
	{
		uint32_t j;

		manuItem[i] = funcReadWriteWtData;
		printf("%u) Write Data (HEX): ", i);
		for (j = 0; j < config.wlen; j++)
		{
			if (j < config.wlen - 1)
				printf("%02X ", config.wdata[j]);
			else
				printf("%02X\n", config.wdata[j]);
		}

		if (!j)
			printf("NULL\n");
		i++;
	}

	manuItem[i] = funcReadWriteRun;
	printf("%u) Run\n", i);
	i++;

	while (i < numManuItem)
		manuItem[i++] = SUSIDEMO_FUNCTIONS_UNDEFINED;

	printf("\nEnter your choice: ");
}

static uint8_t iic_readwrite_loop(uint8_t iDevice, const char *devName, enum funcRank iFunc)
{
	uint32_t op;
	uint32_t tmp_u32, tmpType, i;
	int8_t manuItem[NumFuncReadWrite + 1];
	struct I2CConf config;
	uint8_t tmpbuffer[0x100], readdatabuffer[0x100], writedatabuffer[0x100] = {0};

	config.addrType = addrtype7;
	config.addr = 0;
	config.cmdType = cmdtypeByte;
	config.cmd = 0;
	config.wlen = 0;
	config.rlen = 0;
	config.wdata = writedatabuffer;
	config.rdata = readdatabuffer;

	while (1)
	{
		clr_screen();
		title(devName);
		menu_readwrite(manuItem, NELEMS(manuItem), iFunc, config);

		if (input_uint(&op, 10, NELEMS(manuItem), 0))
			goto unknown;

		switch (manuItem[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return SUSIDEMO_PRINT_NONE;

		case funcReadWriteAddr:
			printf(
				"Address Type:\n"
				"0) 7-bit\n"
				"1) 10-bit\n"
				"\nEnter your choice: ");
			fflush(stdout);
			if (input_uint(&tmpType, 10, NumAddrType, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}

			if (tmpType == addrtype7)
			{
				printf("7-bit Slave Address: 0x");
				if (input_uint(&tmp_u32, 16, 0xFF, 0x00))
				{
					printf("Invalid input\n");
					goto pause;
				}
			}
			else if (tmpType == addrtype10)
			{
				printf("10-bit Slave Address: 0x");
				if (input_uint(&tmp_u32, 16, 0x03FF, 0x0000))
				{
					printf("Invalid input\n");
					goto pause;
				}
			}
			config.addrType = tmpType;
			config.addr = tmp_u32;
			continue;

		case funcReadWriteCmd:
			printf(
				"Command Type:\n"
				"0) Byte\n"
				"1) Word\n"
				"2) None\n"
				"\nEnter your choice: ");
			fflush(stdout);

			if (input_uint(&tmpType, 10, NumCmdType, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}

			if (tmpType == cmdtypeByte)
			{
				printf("\nByte Command: 0x");
				if (input_uint(&tmp_u32, 16, 0xFF, 0x00))
				{
					printf("Invalid input\n");
					goto pause;
				}
			}
			else if (tmpType == cmdtypeWord)
			{
				printf("\nWord Command: 0x");
				if (input_uint(&tmp_u32, 16, 0xFFFF, 0x0000))
				{
					printf("Invalid input\n");
					goto pause;
				}
			}
			config.cmdType = tmpType;
			config.cmd = tmp_u32;
			continue;

		case funcReadWriteWtData:
			printf("Data Length (%u to %u): ", 1, NELEMS(writedatabuffer));
			if (input_uint(&tmp_u32, 10, NELEMS(writedatabuffer), 1))
			{
				printf("Invalid input\n");
				goto pause;
			}

			printf("\nInput %u-byte value (Hex):\n ", tmp_u32);
			if (input_byte_sequence(tmpbuffer, tmp_u32, 16, 0xFF, 0))
			{
				printf("Input invalid value.\n");
				goto pause;
			}

			config.wlen = tmp_u32;
			memcpy(config.wdata, tmpbuffer, config.wlen);
			printf("\nWrite Data (Hex):\n");
			for (i = 0; i < config.wlen; i++)
			{
				if (i < config.wlen - 1)
					printf("%02X ", config.wdata[i]);
				else
					printf("%02X\n", config.wdata[i]);
			}
			continue;

		case funcReadWriteRdLen:
			printf("\nRead Length (%u to %u): ", 0, NELEMS(readdatabuffer));
			if (input_uint(&tmp_u32, 10, NELEMS(readdatabuffer), 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.rlen = tmp_u32;
			continue;

		case funcReadWriteRun:
			if (iFunc == funcRead)
			{
				if (iic_read(iDevice, config))
					goto pause;
			}
			else if (iFunc == funcWrite)
			{
				if (iic_write(iDevice, config))
					goto pause;
			}
			else if (iFunc == funcWtRd)
			{
				if (iic_writeread(iDevice, config))
					goto pause;
			}
		}
unknown:
		printf("Unknown choice!\n");
pause:
		printf("\nPress ENTER to continue. ");
		wait_enter();
	}
}

static void menu_frequency(int8_t *manuItem, uint8_t numManuItem, uint32_t freq)
{
	if (freq)
		printf("Frequency: %u kHz\n\n", freq);
	else
		printf("Frequency:\n\n");

	printf(
		"0) Back to I2C menu\n"
		"1) Set 1 to 100 kHz\n"
		"2) Set 400 kHz\n"
		"3) Get/Refresh\n"
		"\nEnter your choice: ");
	fflush(stdout);
}

static uint8_t iic_frequency_loop(uint8_t iDevice, const char *devName)
{
	uint32_t op;
	uint32_t freq = 0, tmp_u32;
	int8_t manuItem[NumFuncFrequency + 1];
	uint8_t i, index;

	index = 0;
	manuItem[index++] = SUSIDEMO_FUNCTIONS_GOBACK;

	for (i = 0; i < NumFuncFrequency; i++)
		manuItem[index++] = i;

	while (1)
	{
		clr_screen();
		title(devName);
		menu_frequency(manuItem, NELEMS(manuItem), freq);

		if (input_uint(&op, 10, NELEMS(manuItem), 0))
			goto unknown;

		switch (manuItem[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return SUSIDEMO_PRINT_NONE;

		case funcFrequencySet100:
			printf("Set Frequency (1 to 100 kHz): ");
			if (input_uint(&tmp_u32, 10, 100, 1))
			{
				printf("Invalid input\n");
				goto pause;
			}
			if (set_frequency(iDevice, tmp_u32))
				goto pause;
			continue;

		case funcFrequencySet400:
			if (set_frequency(iDevice, 400))
				goto pause;
			continue;

		case funcFrequencyGet:
			if (get_frequency(iDevice, &freq))
				goto pause;
			continue;
		}
unknown:
		printf("Unknown choice!\n");
pause:
		printf("\nPress ENTER to continue. ");
		wait_enter();
	}
}

static void menu(uint8_t iDevice)
{
	uint8_t i, j;

	printf("0) Back to Main menu\n");

	printf("1) Select I2C host: ");
	for (j = 0; j < maxdevice && devids[j] != SUSIDEMO_DEVICEID_UNDEFINED; j++)
	{
		if (j > 0)
			printf("/");

		if (j == iDevice)
			printf("[%u]", j);
		else
			printf(" %u ", j);
	}
	printf("\n");

	printf("2) Probe\n");
	printf("3) Read\n");
	printf("4) Write\n");
	printf("5) WR Combined\n");

	i = 6;

	if (info[iDevice].FreqFlag)
	{
		printf("%u) Frequency\n", i);
		functions[i++] = funcFreq;
	}

	while (i < NELEMS(functions))
		functions[i++] = SUSIDEMO_FUNCTIONS_UNDEFINED;
	
	printf("\nEnter your choice: ");
	fflush(stdout);
}

void iic_main(void)
{
	uint32_t op;
	uint8_t dev = 0;
	char devName[NAME_MAXIMUM_LENGTH];

	get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_I2C(devids[dev]), devName);

	while (1)
	{
		clr_screen();
		title(devName);
		menu(dev);

		if (input_uint(&op, 10, NELEMS(functions), 0))
			goto unknown;

		switch (functions[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return;

		case funcDev:
			if (iic_host(&dev))
				goto pause;
			get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_I2C(devids[dev]), devName);
			continue;

		case funcProbe:
			if (iic_probe_loop(dev, devName))
				goto pause;
			continue;

		case funcRead:
			if (iic_readwrite_loop(dev, devName, funcRead))
				goto pause;
			continue;

		case funcWrite:
			if (iic_readwrite_loop(dev, devName, funcWrite))
				goto pause;
			continue;

		case funcWtRd:
			if (iic_readwrite_loop(dev, devName, funcWtRd))
				goto pause;
			continue;

		case funcFreq:
			if (iic_frequency_loop(dev, devName))
				goto pause;
			continue;
		}
unknown:
		printf("Unknown choice!\n");
pause:
		printf("\nPress ENTER to continue. ");
		wait_enter();
	}
}
