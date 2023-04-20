#include "common.h"

enum modeRank{
	modeOff,	/* = SUSI_FAN_CTRL_MODE_OFF */
	modeFull,	/* = SUSI_FAN_CTRL_MODE_FULL */
	modeManual,	/* = SUSI_FAN_CTRL_MODE_MANUAL */
	modeAuto,	/* = SUSI_FAN_CTRL_MODE_AUTO */
	NumMode,
};

static const char *modeStr[] = {
	"Off",
	"Full",
	"Manual",
	"Auto",
};

struct FanInfo
{
	uint32_t ctrlFlag;
	uint32_t autoFlag;
	int8_t mode[NumMode];
	SusiId_t temp[SUSI_ID_HWM_TEMP_MAX];
	char tempName[SUSI_ID_HWM_TEMP_MAX][NAME_MAXIMUM_LENGTH];
};

static struct FanInfo info[SUSI_ID_HWM_FAN_MAX];
static SusiId_t devids[SUSI_ID_HWM_FAN_MAX];
static const uint8_t maxdevice = NELEMS(devids);

static const char *opmodeStr[] = {
	"PWM",
	"RPM",
};

enum opmodeRank{
	opmodePWM,	/* = SUSI_FAN_AUTO_CTRL_OPMODE_PWM */
	opmodeRPM,	/* = SUSI_FAN_AUTO_CTRL_OPMODE_RPM */
	NumOpMode,
};

static int8_t opmode[NumOpMode];

enum funcRank{
	funcDev,
	funcMode,
	funcPWM,
	funcTmlSource,
	funcLowStopLimit,
	funcLowLimit,
	funcHighLimit,
	funcOpMode,
	funcMaxPWM,
	funcMinPWM,
	funcMaxRPM,
	funcMinRPM,
	funcGet,
	funcSet,
	NumFunc,
};

static int8_t functions[NumFunc + 1];	/* NumFunc + GoBack */

uint8_t sfan_init(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint8_t index, index2, i, j;
	SusiFanControl tmpConf;

	index = 0;	/* index for fan */
	for (i = 0; i < maxdevice; i++)
	{
		id = SUSI_ID_HWM_FAN_BASE + i;

		status = SusiFanControlGetConfig(id, &tmpConf);
		if (status != SUSI_STATUS_SUCCESS)
			continue;

		SusiFanControlGetCaps(id, SUSI_ID_FC_CONTROL_SUPPORT_FLAGS, &info[index].ctrlFlag);

		index2 = 0;	/* supported control mode */

		if (info[index].ctrlFlag & SUSI_FC_FLAG_SUPPORT_OFF_MODE)
			info[index].mode[index2++] = modeOff;

		if (info[index].ctrlFlag & SUSI_FC_FLAG_SUPPORT_FULL_MODE)
			info[index].mode[index2++] = modeFull;

		if (info[index].ctrlFlag & SUSI_FC_FLAG_SUPPORT_MANUAL_MODE)
			info[index].mode[index2++] = modeManual;

		if (info[index].ctrlFlag & SUSI_FC_FLAG_SUPPORT_AUTO_MODE)
			info[index].mode[index2++] = modeAuto;

		while (index2 < NELEMS(info[index].mode))
			info[index].mode[index2++] = SUSIDEMO_ITEM_UNDEFINED;

		if (info[index].ctrlFlag & SUSI_FC_FLAG_SUPPORT_AUTO_MODE)
		{
			SusiId_t temp_id;
			uint32_t temp_type;

			SusiFanControlGetCaps(id, SUSI_ID_FC_AUTO_SUPPORT_FLAGS, &info[index].autoFlag);

			index2 = 0;	/* supported temperature */
			for (j = 0; j < NELEMS(info[index].temp); j++)
			{
				temp_id = SUSI_ID_HWM_TEMP_BASE + j;
				if (SusiFanControlGetCaps(id, temp_id, &temp_type) == SUSI_STATUS_SUCCESS)
				{
					get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_HWM(temp_id), info[index].tempName[index2]);
					info[index].temp[index2] = temp_id;
					index2++;
				}
			}

			while (index2 < NELEMS(info[index].temp))
				info[index].temp[index2++] = SUSIDEMO_DEVICEID_UNDEFINED;
		}		

		devids[index++] = id;
	}

	if (!index)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	while (index < maxdevice)
		devids[index++] = SUSIDEMO_DEVICEID_UNDEFINED;

	index = 0;	/* index for Smart Fan functions */
	functions[index++] = SUSIDEMO_FUNCTIONS_GOBACK;
	functions[index++] = funcDev;
	functions[index++] = funcMode;

	/*while (index < NELEMS(fuctions))
		fuctions[index++] = SUSIDEMO_FUNCTIONS_UNDEFINED;*/

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static void support_opmode_init(uint8_t iDevice)
{
	if (info[iDevice].ctrlFlag & SUSI_FC_FLAG_SUPPORT_AUTO_MODE)
	{
		uint8_t index = 0;

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_PWM)
			opmode[index++] = opmodePWM;

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_RPM)
			opmode[index++] = opmodeRPM;

		while (index < NumOpMode)
			opmode[index++] = SUSIDEMO_ITEM_UNDEFINED;
	}
}

static void title(const char *name)
{
	printf(
		"**********************************************\n"
		"**               SUSI4.0 demo               **\n"
		"**********************************************\n\n");

	printf("%s Fan Controller\n\n", name);
}

static uint8_t sfan_fan(uint8_t *iDevice)
{
	if (*iDevice == 0 && devids[1] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		printf("Only a fan controller.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	if (*iDevice + 1 >= maxdevice)
	{
		*iDevice = 0;
		return SUSIDEMO_PRINT_NONE;
	}

	if (devids[*iDevice + 1] != SUSIDEMO_DEVICEID_UNDEFINED)
	{
		*iDevice += 1;
		return SUSIDEMO_PRINT_NONE;
	}

	*iDevice = 0;
	return SUSIDEMO_PRINT_NONE;
}

static uint8_t sfan_mode(uint8_t iDevice, uint32_t *confMode)
{
	uint8_t i;

	if (info[iDevice].mode[1] == SUSIDEMO_ITEM_UNDEFINED)
	{
		*confMode = info[iDevice].mode[0];
		printf("Only a control mode.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	for (i = 0; i < NumMode; i++)
	{
		if (info[iDevice].mode[i] == *confMode)
			break;
	}
	
	if (i + 1 < NumMode)
	{
		if (info[iDevice].mode[i + 1] != SUSIDEMO_ITEM_UNDEFINED)
		{
			*confMode = info[iDevice].mode[i + 1];
			return SUSIDEMO_PRINT_NONE;
		}
	}

	*confMode = info[iDevice].mode[0];
	return SUSIDEMO_PRINT_NONE;
}

static uint8_t sfan_thermalsource(uint8_t iDevice, SusiId_t *tmlSource)
{
	uint8_t i;
	const uint8_t max = NELEMS(info[iDevice].temp);

	if (info[iDevice].temp[0] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		printf("No thermal source.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	if (info[iDevice].temp[1] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		*tmlSource = info[iDevice].temp[0];
		printf("Only a thermal source.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	for (i = 0; i < max; i++)
	{
		/* SUSI_ID_GET_TYPE(config.AutoControl.TmlSource) != SUSI_ID_HWM_TEMP_BASE*/
		if (info[iDevice].temp[i] == *tmlSource)
			break;
	}

	if (i + 1 < max)
	{
		if (info[iDevice].temp[i + 1] != SUSIDEMO_DEVICEID_UNDEFINED)
		{
			*tmlSource = info[iDevice].temp[i + 1];
			return SUSIDEMO_PRINT_NONE;
		}
	}

	*tmlSource = info[iDevice].temp[0];
	return SUSIDEMO_PRINT_NONE;
}

static uint8_t sfan_opmode(uint32_t *confOpMode)
{
	uint8_t i;

	if (opmode[1] == SUSIDEMO_ITEM_UNDEFINED)
	{
		*confOpMode = opmode[0];
		printf("Only a output mode.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	for (i = 0; i < NumOpMode; i++)
	{
		if (opmode[i] == *confOpMode)
			break;
	}

	if (i + 1 < NumOpMode)
	{
		if (opmode[i + 1] != SUSIDEMO_ITEM_UNDEFINED)
		{
			*confOpMode = opmode[i + 1];
			return SUSIDEMO_PRINT_NONE;
		}
	}

	*confOpMode = opmode[0];
	return SUSIDEMO_PRINT_NONE;
}

static uint8_t sfan_get_config(uint8_t iDevice, SusiFanControl *config)
{
	SusiStatus_t status = SusiFanControlGetConfig(devids[iDevice], config);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiFanControlGetConfig() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}
	
	printf("SusiFanControlGetConfig() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t sfan_set_config(uint8_t iDevice, SusiFanControl config)
{
	SusiStatus_t status = SusiFanControlSetConfig(devids[iDevice], &config);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiFanControlSetConfig() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiFanControlSetConfig() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static void menu(uint8_t iDevice, SusiFanControl config)
{
	uint8_t i, index;

	printf("0) Back to Main menu\n");

	printf("1) Select Smart Fan: ");
	for (index = 0; index < maxdevice && devids[index] != SUSIDEMO_DEVICEID_UNDEFINED; index++)
	{
		if (index > 0)
			printf("/");

		if (index == iDevice)
			printf("[%u]", index);
		else
			printf(" %u ", index);
	}
	printf("\n");

	printf("2) Mode: ");
	for (index = 0; index < NumMode && info[iDevice].mode[index] != SUSIDEMO_ITEM_UNDEFINED; index++)
	{
		if (index > 0)
			printf("/");

		if (info[iDevice].mode[index] == config.Mode)
			printf("[%s]", modeStr[info[iDevice].mode[index]]);
		else
			printf(" %s ", modeStr[info[iDevice].mode[index]]);
	}
	printf("\n");

	i = 3;

	if (config.Mode == modeManual)
	{
		printf("%u) PWM: %u%%\n", i, config.PWM);
		functions[i++] = funcPWM;
	}
	
	if (config.Mode == modeAuto)
	{
		
		if (info[iDevice].temp[0] == SUSIDEMO_DEVICEID_UNDEFINED)
		{
			printf("%u) Thermal Source: N/A\n", i);
		}
		else
		{
			printf("%u) Thermal Source: Temperature ", i);
			for (index = 0; index < NELEMS(info[iDevice].temp) && info[iDevice].temp[index] != SUSIDEMO_ITEM_UNDEFINED; index++)
			{
				if (index)
					printf("/");

				if (info[iDevice].temp[index] == config.AutoControl.TmlSource)
					printf("[%s]", info[iDevice].tempName[index]);
				else
					printf(" %s ", info[iDevice].tempName[index]);
			}
			printf("\n");
		}
		functions[i++] = funcTmlSource;

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_LOW_STOP)
		{
			printf("%u) Low Stop Limit: %.1f Celsius\n", i, SUSI_DECODE_CELCIUS((float)config.AutoControl.LowStopLimit));
			functions[i++] = funcLowStopLimit;
		}

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_LOW_LIMIT)
		{
			printf("%u) Low Limit     : %.1f Celsius\n", i, SUSI_DECODE_CELCIUS((float)config.AutoControl.LowLimit));
			functions[i++] = funcLowLimit;
		}

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_HIGH_LIMIT)
		{
			printf("%u) High Limit    : %.1f Celsius\n", i, SUSI_DECODE_CELCIUS((float)config.AutoControl.HighLimit));
			functions[i++] = funcHighLimit;
		}

		printf("%u) Op Mode: ", i);
		for (index = 0; index < NumOpMode && opmode[index] > SUSIDEMO_ITEM_UNDEFINED; index++)
		{
			if (index)
				printf("/");

			if (config.AutoControl.OpMode == opmode[index])
				printf("[%s]", opmodeStr[opmode[index]]);
			else
				printf(" %s ", opmodeStr[opmode[index]]);
		}
		printf("\n");
		functions[i++] = funcOpMode;

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_PWM && config.AutoControl.OpMode == opmodePWM)
		{
			printf("%u) Max PWM: %u%%\n", i, config.AutoControl.MaxPWM);
			functions[i++] = funcMaxPWM;

			printf("%u) Min PWM: %u%%\n", i, config.AutoControl.MinPWM);
			functions[i++] = funcMinPWM;
		}

		if (info[iDevice].autoFlag & SUSI_FC_FLAG_SUPPORT_AUTO_RPM && config.AutoControl.OpMode == opmodeRPM)
		{
			printf("%u) Max RPM: %u RPM\n", i, config.AutoControl.MaxRPM);
			functions[i++] = funcMaxRPM;

			printf("%u) Min RPM: %u RPM\n", i, config.AutoControl.MinRPM);
			functions[i++] = funcMinRPM;
		}
	}

	printf("%u) Get/Refresh all values\n", i);
	functions[i++] = funcGet;

	printf("%u) Save and apply setting\n", i);	
	functions[i++] = funcSet;

	while (i < NELEMS(functions))
		functions[i++] = SUSIDEMO_FUNCTIONS_UNDEFINED;

	printf("\nEnter your choice: ");
	fflush(stdout);
}

void sfan_main(void)
{
	uint32_t op;
	uint32_t tmp_u32;
	uint8_t dev = 0;
	char devName[NAME_MAXIMUM_LENGTH];
	SusiFanControl config;

	get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_HWM_FANCONTROL(devids[dev]), devName);
	SusiFanControlGetConfig(devids[dev], &config);
	support_opmode_init(dev);

	while (1)
	{
		clr_screen();
		title(devName);
		menu(dev, config);

		if (input_uint(&op, 10, NELEMS(functions), 0))
			goto unknown;

		switch (functions[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return;

		case funcDev:
			if (sfan_fan(&dev))
				goto pause;
			get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_HWM_FANCONTROL(devids[dev]), devName);
			SusiFanControlGetConfig(devids[dev], &config);
			support_opmode_init(dev);
			continue;

		case funcMode:
			if (sfan_mode(dev, &config.Mode))
				goto pause;
			continue;

		case funcPWM:
			printf("PWM (0 ~ 100 percentage): ");
			if (input_uint(&tmp_u32, 10, 100, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.PWM = tmp_u32;
			continue;

		case funcTmlSource:
			if (sfan_thermalsource(dev, &config.AutoControl.TmlSource))
				goto pause;
			continue;

		case funcLowStopLimit:
			printf("Low Stop Limit (0 ~ 255 Celsius): ");
			if (input_uint(&tmp_u32, 10, 0xFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.LowStopLimit = SUSI_ENCODE_CELCIUS(tmp_u32);
			continue;

		case funcLowLimit:
			printf("Low Limit (0 ~ 255 Celsius): ");
			if (input_uint(&tmp_u32, 10, 0xFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.LowLimit = SUSI_ENCODE_CELCIUS(tmp_u32);
			continue;

		case funcHighLimit:
			printf("High Limit (0 ~ 255 Celsius): ");
			if (input_uint(&tmp_u32, 10, 0xFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.HighLimit = SUSI_ENCODE_CELCIUS(tmp_u32);
			continue;

		case funcOpMode:
			if (sfan_opmode(&config.AutoControl.OpMode))
				goto pause;
			continue;

		case funcMaxPWM:
			printf("Max PWM (0 ~ 100): ");
			if (input_uint(&tmp_u32, 10, 100, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.MaxPWM = tmp_u32;
			continue;

		case funcMinPWM:
			printf("Min PWM (0 ~ 100): ");
			if (input_uint(&tmp_u32, 10, 100, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.MinPWM = tmp_u32;
			continue;

		case funcMaxRPM:
			printf("Max RPM (0 ~ 65535): ");
			if (input_uint(&tmp_u32, 10, 0xFFFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.MaxRPM = tmp_u32;
			continue;

		case funcMinRPM:
			printf("Min RPM (0 ~ 65535): ");
			if (input_uint(&tmp_u32, 10, 0xFFFF, 0))
			{
				printf("Invalid input\n");
				goto pause;
			}
			config.AutoControl.MinRPM = tmp_u32;
			continue;

		case funcGet:
			if (sfan_get_config(dev, &config))
				goto pause;
			continue;

		case funcSet:
			if (sfan_set_config(dev, config))
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
