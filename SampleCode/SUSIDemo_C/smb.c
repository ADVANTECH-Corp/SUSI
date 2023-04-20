#include "common.h"

static SusiId_t devids[SUSI_SMBUS_MAX_DEVICE];
static const uint8_t maxdevice = NELEMS(devids);

enum funcRank{
	funcDev,
	funcProbe,
	funcRead,
	funcWrite,
	NumFunc,
};

static int8_t functions[NumFunc + 1];

const char *protocolStr[] = {
	"Quick",
	"Byte",
	"Byte Data",
	"Word Data",
	"Block",
	"I2C Block"
};

enum protocolRank{
	protQuick,
	protByte,
	protByteData,
	protWordData,
	protBlock,
	protI2CBlock,
	NumProtocol,
};

enum funcReadWriteRank{
	funcReadWriteProtocol,
	funcReadWriteAddr,
	funcReadWriteCmd,
	funcReadWriteData,
	funcReadWriteLen,
	funcReadWriteRun,
	NumFuncReadWrite,
};

struct SMBConf{
	uint8_t addr;
	uint8_t cmd;
	uint8_t protocol;
	uint32_t len;
	uint8_t *data;
};

uint8_t smb_init(void)
{
	SusiStatus_t status;
	uint32_t supFlag;
	uint8_t index, i;

	status = SusiBoardGetValue(SUSI_ID_SMBUS_SUPPORTED, &supFlag);
	if (status != SUSI_STATUS_SUCCESS)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	if (!supFlag)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	index = 0;	/* index for devices */
	for (i = 0; i < maxdevice; i++)
	{
		if (supFlag & (1 << i))
			devids[index++] = i;
	}

	if (!index)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	while (index < maxdevice)
		devids[index++] = SUSIDEMO_DEVICEID_UNDEFINED;

	index = 0;	/* index for SMbus functions */
	functions[index++] = SUSIDEMO_FUNCTIONS_GOBACK;

	for (i = 0; i < NumFunc; i++)
		functions[index++] = i;

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

static uint8_t smb_host(uint8_t *iDevice)
{
	if (*iDevice == 0 && devids[1] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		printf("Only an SMBus host.\n");
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

static uint8_t smb_probe(uint8_t iDevice)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;
	uint8_t shiftaddr, n, i;

	printf("\nProbe:\n");
	printf("Slave address of existed devices:\n");

	n = 0;
	for (i = 0x03; i < 0x78; i++)
	{
		shiftaddr = (i << 1);
		status = SusiSMBWriteQuick(id, shiftaddr);
		if (status == SUSI_STATUS_SUCCESS)
		{
			printf("0x%02X ", shiftaddr);
			n++;
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

static uint8_t smb_read(uint8_t iDevice, struct SMBConf config)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;
	uint32_t i;

	switch (config.protocol)
	{
	case protQuick:
		status = SusiSMBReadQuick(id, config.addr);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Read quick failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Read quick succeed.\n");
		break;

	case protByte:
		status = SusiSMBReceiveByte(id, config.addr, config.data);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Receive byte failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Data (Hex): %02X\n", config.data[0]);
		break;

	case protByteData:
		status = SusiSMBReadByte(id, config.addr, config.cmd, config.data);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Read byte data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Data (Hex): %02X\n", config.data[0]);
		break;

	case protWordData:
		status = SusiSMBReadWord(id, config.addr, config.cmd, (uint16_t *)config.data);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Read word data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Data (Hex): %04X\n", *((uint16_t *)config.data));
		break;

	case protBlock:
		status = SusiSMBReadBlock(id, config.addr, config.cmd, config.data, &config.len);
		if (status != SUSI_STATUS_SUCCESS && status != SUSI_STATUS_MORE_DATA)
		{
			printf("Read block data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}

		printf("Data (Hex):\n");
		for (i = 0; i < config.len; i++)
		{
			if (i < config.len - 1)
				printf("%02X ", config.data[i]);
			else
				printf("%02X\n", config.data[i]);
		}

		if (status == SUSI_STATUS_MORE_DATA)
		{
			printf(
				"...\n\n"
				"Read block need more length, target size is %u.\n", config.len);
			return SUSIDEMO_PRINT_ERROR;
		}
		break;

	case protI2CBlock:
		status = SusiSMBI2CReadBlock(id, config.addr, config.cmd, config.data, config.len);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Read I2C block data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}

		printf("Data (Hex):\n");
		for (i = 0; i < config.len; i++)
		{
			if (i < config.len - 1)
				printf("%02X ", config.data[i]);
			else
				printf("%02X\n", config.data[i]);
		}					
		break;
	}

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t smb_write(uint8_t iDevice, struct SMBConf config)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status;

	switch (config.protocol)
	{
	case protQuick:
		status = SusiSMBWriteQuick(id, config.addr);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Write quick failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Write quick succeed.\n");
		break;

	case protByte:
		status = SusiSMBSendByte(id, config.addr, config.data[0]);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Send byte failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Send byte succeed.\n");
		break;

	case protByteData:
		status = SusiSMBWriteByte(id, config.addr, config.cmd, config.data[0]);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Write byte data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Write byte data succeed.\n");
		break;

	case protWordData:
		status = SusiSMBWriteWord(id, config.addr, config.cmd, (config.data[1] << 8) | config.data[0]);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Write word data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Write word data succeed.\n");
		break;

	case protBlock:
		status = SusiSMBWriteBlock(id, config.addr, config.cmd, config.data, config.len);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Write block data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Write block data succeed.\n");
		break;

	case protI2CBlock:
		status = SusiSMBI2CWriteBlock(id, config.addr, config.cmd, config.data, config.len);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("Write I2C block data failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		printf("Write I2C block data succeed.\n");
		break;
	}

	return SUSIDEMO_PRINT_SUCCESS;
}

static void menu_readwrite(int8_t *manuItem, uint8_t numManuItem, struct SMBConf config, enum funcRank iFunc)
{
	uint8_t i, j;

	if (iFunc == funcRead)
		printf("Read Data:\n\n");
	else if (iFunc == funcWrite)
		printf("Write Data:\n\n");

	manuItem[0] = SUSIDEMO_FUNCTIONS_GOBACK;
	printf("0) Back to SMBus menu\n");

	i = 1;

	manuItem[i] = funcReadWriteProtocol;
	printf("%u) Protocol: %s\n", i, protocolStr[config.protocol]);
	i++;

	manuItem[i] = funcReadWriteAddr;
	printf("%u) Slave Address: 0x%02X\n", i, config.addr);	
	i++;

	if (config.protocol != protQuick && config.protocol != protByte)
	{
		manuItem[i] = funcReadWriteCmd;
		printf("%u) Command: 0x%02X\n", i, config.cmd);
		i++;
	}

	if (iFunc == funcRead)
	{
		if (config.protocol == protBlock || config.protocol == protI2CBlock)
		{
			manuItem[i] = funcReadWriteLen;
			printf("%u) Data Length: %u\n", i, config.len);
			i++;
		}
	}
	else if (iFunc == funcWrite)
	{
		if (config.protocol != protQuick)
		{
			manuItem[i] = funcReadWriteData;

			if (config.protocol == protByte || config.protocol == protByteData)
			{
				printf("%u) Data: 0x%02X\n", i, config.data[0]);
			}
			else if (config.protocol == protWordData)
			{
				printf("%u) Data: 0x%04X\n", i, (config.data[1] << 8) | config.data[0]);
			}
			else
			{
				printf("%u) Data (HEX): ", i);
				for (j = 0; j < config.len; j++)
				{
					if (j < config.len - 1)
						printf("%02X ", config.data[j]);
					else
						printf("%02X\n", config.data[j]);
				}
			}
			i++;
		}
	}	

	manuItem[i] = funcReadWriteRun;
	printf("%u) Run\n", i);
	i++;

	while (i < numManuItem)
		manuItem[i++] = SUSIDEMO_FUNCTIONS_UNDEFINED;

	printf("\nEnter your choice: ");
	fflush(stdout);
}

static uint8_t smb_readwrite_loop(uint8_t iDevice, const char *devName, enum funcRank iFunc)
{
	uint32_t op;
	uint32_t tmp_u32;
	int8_t manuItem[NumFuncReadWrite + 1];
	struct SMBConf config;
	uint8_t databuffer[0x20] = {0}, i;
	const uint8_t maxdatalength = NELEMS(databuffer);

	config.protocol = protQuick;
	config.addr = 0x00;
	config.cmd = 0x00;
	config.len = 1;
	config.data = databuffer;

	while (1)
	{
		clr_screen();
		title(devName);
		menu_readwrite(manuItem, NELEMS(manuItem), config, iFunc);

		if (input_uint(&op, 10, NELEMS(manuItem), 0))
			goto unknown;

		switch (manuItem[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return SUSIDEMO_PRINT_NONE;

		case funcReadWriteProtocol:
			printf("\nProtocol:\n");
			for (i = 0; i < NumProtocol; i++)
				printf("%u) %s\n", i, protocolStr[i]);
			printf("\nEnter your choice: ");
			fflush(stdout);

			if (input_uint(&tmp_u32, 10, NumProtocol, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.protocol = (uint8_t)tmp_u32;
			continue;

		case funcReadWriteAddr:
			printf("Slave Address: 0x");
			if (input_uint(&tmp_u32, 16, 0xFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.addr = (uint8_t)tmp_u32;
			continue;

		case funcReadWriteCmd:
			printf("Command: 0x");
			if (input_uint(&tmp_u32, 16, 0xFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.cmd = (uint8_t)tmp_u32;
			continue;

		case funcReadWriteData:
			if (config.protocol == protByte || config.protocol == protByteData)
			{
				printf("\nInput a BYTE data (Hex): 0x");
				if (input_uint(&tmp_u32, 16, 0xFF, 0))
				{
					printf("Invalid input\n");
					goto pause;
				}
				config.data[0] = tmp_u32;
			}
			else if (config.protocol == protWordData)
			{
				printf("\nInput a WORD data (Hex): 0x");
				if (input_uint(&tmp_u32, 16, 0xFFFF, 0))
				{
					printf("Invalid input\n");
					goto pause;
				}
				config.data[0] = (uint8_t)tmp_u32;
				config.data[1] = (uint8_t)(tmp_u32 >> 8);
			}
			else if (config.protocol == protBlock || config.protocol == protI2CBlock)
			{
				uint32_t i;
				uint8_t tmpbuffer[0x20];

				printf("Data Length (%u to %u): ", 1, maxdatalength);
				if (input_uint(&tmp_u32, 10, maxdatalength, 1))
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

				config.len = (uint8_t)tmp_u32;
				memcpy(config.data, tmpbuffer, config.len);
				printf("\nWrite Data (Hex):\n");
				for (i = 0; i < config.len; i++)
				{
					if (i < config.len - 1)
						printf("%02X ", config.data[i]);
					else
						printf("%02X\n", config.data[i]);
				}
			}
			continue;

		case funcReadWriteLen:
			printf("Data Length (%u to %u): ", 1, maxdatalength);
			if (input_uint(&tmp_u32, 10, maxdatalength, 1))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.len = (uint8_t)tmp_u32;
			continue;

		case funcReadWriteRun:
			if (iFunc == funcRead)
			{
				if (smb_read(iDevice, config))
					goto pause;
			}			
			else if (iFunc == funcWrite)
			{
				if (smb_write(iDevice, config))
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

static void menu(uint8_t iHost)
{
	uint8_t i;

	printf("0) Back to Main menu\n");

	printf("1) Select SMBus host: ");
	for (i = 0; i < maxdevice && devids[i] != SUSIDEMO_DEVICEID_UNDEFINED; i++)
	{
		if (i > 0)
			printf("/");

		if (i == iHost)
			printf("[%u]", i);
		else
			printf(" %u ", i);
	}
	printf("\n");

	printf("2) Probe\n");
	printf("3) Read\n");
	printf("4) Write\n");

	printf("\nEnter your choice: ");
	fflush(stdout);
}

void smb_main(void)
{
	uint32_t op;
	uint8_t dev = 0;
	char devName[NAME_MAXIMUM_LENGTH];

	get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_SMB(devids[dev]), devName);

	while (1)
	{
		clr_screen();
		title(devName);
		menu(dev);

		if (input_uint(&op, 10, NumFunc + 1, 0))
			goto unknown;

		switch (functions[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return;

		case funcDev:
			if (smb_host(&dev))
				goto pause;
			get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_SMB(devids[dev]), devName);
			continue;

		case funcProbe:
			if (smb_probe(dev))
				goto pause;
			continue;

		case funcRead:
			if (smb_readwrite_loop(dev, devName, funcRead))
				goto pause;
			continue;

		case funcWrite:
			if (smb_readwrite_loop(dev, devName, funcWrite))
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
