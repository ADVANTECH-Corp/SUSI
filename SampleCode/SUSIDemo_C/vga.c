#include "common.h"

typedef struct {
	uint32_t maxValue;
	uint32_t minValue;
	/*
	 *enableFlag
	 * bit0: PWM emthod enable
	 * bit1: ACPI emthod enable
	 * bit2: frequency control enable
	 * bit3: polarity control enable
	 * bit4: backlight control enable
	 * others: reserve
	 */
	uint32_t enableFlag;
} VGAInfo, *PVGAInfo;

typedef struct {
	uint32_t frequencyVal;
	uint32_t polarityVal;
	uint32_t backlightVal;
	uint32_t methodVal;
	uint32_t brightnessVal;
} VGAConfig, *PVGAConfig;

enum enableRank{	
	enablePWM,
	enableACPI,
	enableFrequency,
	enablePolarity,
	enableBacklight,
	NumEnable,
};

static VGAInfo info[SUSI_ID_BACKLIGHT_MAX];
static SusiId_t devids[SUSI_ID_BACKLIGHT_MAX];
static const uint8_t maxdevice = NELEMS(devids);

enum methodRank{
	methodPWM,
	methodACPI,
	NumMethod,
};

enum funcRank{
	funcDev,
	funcMethod,
	funcBrightness,	
	funcFrequency,
	funcPolarity,
	funcBacklight,
	funcGet,
	NumFunc,
};

static int8_t functions[NumFunc + 1];	/* NumFunc + GoBack */

uint8_t vga_init(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint8_t index, i;
	uint32_t tmp;

	index = 0;	/* index for panel */
	for (i = 0; i < maxdevice; i++)
	{
		id = i;
		info[i].enableFlag = 0;

		status = SusiVgaGetCaps(id, SUSI_ID_VGA_BRIGHTNESS_MAXIMUM, &info[i].maxValue);
		if (status == SUSI_STATUS_SUCCESS && info[i].maxValue > 0)
			info[index].enableFlag |= (1 << enablePWM);

		if ((info[index].enableFlag & (1 << enablePWM)) != 0)
		{
			status = SusiVgaGetCaps(id, SUSI_ID_VGA_BRIGHTNESS_MINIMUM, &info[i].minValue);
			if (status != SUSI_STATUS_SUCCESS)
				info[i].enableFlag &= ~(1 << enablePWM);
		}

		if (SusiVgaGetBacklightLevel(id, &tmp) == SUSI_STATUS_SUCCESS)
			info[i].enableFlag |= (1 << enableACPI);

		if (SusiVgaGetBacklightEnable(id, &tmp) == SUSI_STATUS_SUCCESS)
			info[i].enableFlag |= (1 << enableBacklight);

		if (info[i].enableFlag == 0)
			continue;

		if (SusiVgaGetFrequency(id, &tmp) == SUSI_STATUS_SUCCESS)
			info[i].enableFlag |= (1 << enableFrequency);

		if (SusiVgaGetPolarity(id, &tmp) == SUSI_STATUS_SUCCESS)
			info[i].enableFlag |= (1 << enablePolarity);

		devids[index++] = id;
	}

	if (!index)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	while (index < maxdevice)
		devids[index++] = SUSIDEMO_DEVICEID_UNDEFINED;

	index = 0;	/* index for functions */
	functions[index++] = SUSIDEMO_FUNCTIONS_GOBACK;
	functions[index++] = funcDev;

	/*while (index < NELEMS(functions))
		functions[index++] = SUSIDEMO_FUNCTIONS_UNDEFINED;*/

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static void title(const char *name)
{
	printf(
		"**********************************************\n"
		"**               SUSI4.0 demo               **\n"
		"**********************************************\n\n");

	printf("VGA: %s\n\n", name);
}

static uint8_t brightness_method_init(uint8_t iDevice, uint32_t *pvalue)
{
	if (iDevice >= SUSI_ID_BACKLIGHT_MAX)
	{
		printf("ERROR: The flat panel is not exist.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	if ((info[iDevice].enableFlag & (1 << enablePWM)) != 0)
	{
		*pvalue = methodPWM;
	}
	else if ((info[iDevice].enableFlag & (1 << enableACPI)) != 0)
	{
		*pvalue = methodACPI;
	}
	else
	{
		printf("ERROR: No brightness method is supported.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t vga_panel(uint8_t *iDevice)
{
	if (*iDevice == 0 && devids[1] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		printf("Only a panel.\n");
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

static uint8_t vga_get_frequency(uint8_t iDevice, uint32_t *pvalue)
{
	uint32_t status;

	status = SusiVgaGetFrequency(devids[iDevice], pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiVgaGetFrequency() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t vga_set_frequency(uint8_t iDevice, uint32_t setVal)
{
	uint32_t status;

	status = SusiVgaSetFrequency(devids[iDevice], setVal);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiVgaSetFrequency() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiVgaSetFrequency() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t vga_get_polarity(uint8_t iDevice, uint32_t *pvalue)
{
	uint32_t status;

	status = SusiVgaGetPolarity(devids[iDevice], pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiVgaGetPolarity() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t vga_set_polarity(uint8_t iDevice, uint32_t orgVal)
{
	uint32_t status;

	if (orgVal == SUSI_BACKLIGHT_POLARITY_OFF)
		status = SusiVgaSetPolarity(devids[iDevice], SUSI_BACKLIGHT_POLARITY_ON);
	else
		status = SusiVgaSetPolarity(devids[iDevice], SUSI_BACKLIGHT_POLARITY_OFF);
	
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiVgaSetPolarity() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiVgaSetPolarity() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t vga_get_backlight(uint8_t iDevice, uint32_t *pvalue)
{
	uint32_t status;

	status = SusiVgaGetBacklightEnable(devids[iDevice], pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiVgaGetBacklightEnable() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t vga_set_backlight(uint8_t iDevice, uint32_t orgVal)
{
	uint32_t status;

	if (orgVal == SUSI_BACKLIGHT_SET_OFF)
		status = SusiVgaSetBacklightEnable(devids[iDevice], SUSI_BACKLIGHT_SET_ON);
	else
		status = SusiVgaSetBacklightEnable(devids[iDevice], SUSI_BACKLIGHT_SET_OFF);
	
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiVgaSetBacklightEnable() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiVgaSetBacklightEnable() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t vga_method(uint8_t iDevice, uint32_t *pvalue)
{
	if (iDevice >= SUSI_ID_BACKLIGHT_MAX)
	{
		printf("Unknown device.\n");
		return 1;
	}

	if (*pvalue == methodPWM)
	{
		if ((info[iDevice].enableFlag & (1 << enableACPI)) != 0)
		{
			*pvalue = methodACPI;
		}
		else
		{
			printf("The flat panel supports PWM method only.\n");
			return SUSIDEMO_PRINT_ERROR;
		}
	}
	else if (*pvalue == methodACPI)
	{
		if ((info[iDevice].enableFlag & (1 << enablePWM)) != 0)
		{
			*pvalue = methodPWM;
		}
		else
		{
			printf("The flat panel supports ACPI method only.\n");
			return SUSIDEMO_PRINT_ERROR;
		}
	}
	else
	{
		return brightness_method_init(iDevice, pvalue);
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t vga_get_brightness(uint8_t iDevice, uint32_t methodVal, uint32_t *pvalue)
{
	uint32_t status;

	switch (methodVal)
	{
	case methodPWM:
		status = SusiVgaGetBacklightBrightness(devids[iDevice], pvalue);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("SusiVgaGetBacklightBrightness() failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		break;

	case methodACPI:
		status = SusiVgaGetBacklightLevel(devids[iDevice], pvalue);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("SusiVgaGetBacklightLevel() failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		break;

	default:
		printf("Unknown method.\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_NONE;
}

static uint8_t vga_set_brightness(uint8_t iDevice, uint32_t methodVal)
{
	uint32_t status, setVal;

	switch (methodVal)
	{
	case methodPWM:
		if ((info[iDevice].enableFlag & (1 << enablePWM)) == 0)
		{
			printf("PWM method is unsupported.\n");
			return SUSIDEMO_PRINT_ERROR;
		}

		do {
			printf("\nBrightness value (%u to %u): ", info[iDevice].minValue, info[iDevice].maxValue);
		} while (input_uint(&setVal, 10, info[iDevice].maxValue, info[iDevice].minValue) != 0);

		status = SusiVgaSetBacklightBrightness(devids[iDevice], setVal);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("SusiVgaSetBacklightBrightness() failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		break;

	case methodACPI:
		if ((info[iDevice].enableFlag & (1 << enableACPI)) == 0)
		{
			printf("ACPI method is unsupported.\n");
			return SUSIDEMO_PRINT_ERROR;
		}

		do {
			printf("\nBrightness level (%u ~ %u): ", SUSI_BACKLIGHT_LEVEL_MINIMUM, SUSI_BACKLIGHT_LEVEL_MAXIMUM);
		} while (input_uint(&setVal, 10, SUSI_BACKLIGHT_LEVEL_MAXIMUM, SUSI_BACKLIGHT_LEVEL_MINIMUM) != 0);

		status = SusiVgaSetBacklightLevel(devids[iDevice], setVal);
		if (status != SUSI_STATUS_SUCCESS)
		{
			printf("SusiVgaSetBacklightLevel() failed. (0x%08X)\n", status);
			return SUSIDEMO_PRINT_ERROR;
		}
		break;

	default:
		printf("Unknown choice!\n");
		return SUSIDEMO_PRINT_ERROR;
	}

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t vga_get_config(uint8_t iDevice, PVGAConfig pconfig)
{
	if ((info[iDevice].enableFlag & ((1 << enablePWM) | (1 << enableACPI))) != 0)
	{
		if (vga_get_brightness(iDevice, pconfig->methodVal, &pconfig->brightnessVal) == SUSIDEMO_PRINT_ERROR)
			return SUSIDEMO_PRINT_ERROR;
	}

	if ((info[iDevice].enableFlag & (1 << enableFrequency)) != 0)
	{
		if (vga_get_frequency(iDevice, &pconfig->frequencyVal) == SUSIDEMO_PRINT_ERROR)
			return SUSIDEMO_PRINT_ERROR;
	}

	if ((info[iDevice].enableFlag & (1 << enablePolarity)) != 0)
	{
		if (vga_get_polarity(iDevice, &pconfig->polarityVal) == SUSIDEMO_PRINT_ERROR)
			return SUSIDEMO_PRINT_ERROR;
	}

	if ((info[iDevice].enableFlag & (1 << enableBacklight)) != 0)
	{
		if (vga_get_backlight(iDevice, &pconfig->backlightVal) == SUSIDEMO_PRINT_ERROR)
			return SUSIDEMO_PRINT_ERROR;
	}

	printf("Refreshed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static void menu(uint8_t iDevice, VGAConfig config)
{
	uint8_t i, index;

	printf("0) Back to Main menu\n");

	printf("1) Select Flat Panel: ");
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

	i = 2;

	if ((info[iDevice].enableFlag & ((1 << enablePWM) | (1 << enableACPI))) != 0)
	{
		printf("%u) Brightness method: ", i);

		if ((info[iDevice].enableFlag & (1 << enablePWM)) != 0)
		{
			if (config.methodVal == methodPWM)
				printf("[PWM]");
			else
				printf(" PWM ");
		}

		if ((info[iDevice].enableFlag & (1 << enablePWM)) != 0 &&
			(info[iDevice].enableFlag & (1 << enableACPI)) != 0)
			printf("/");

		if ((info[iDevice].enableFlag & (1 << enableACPI)) != 0)
		{
			if (config.methodVal == methodACPI)
				printf("[ACPI]");
			else
				printf(" ACPI");
		}

		printf("\n");
		functions[i++] = funcMethod;
	}

	if (config.methodVal == methodPWM)
	{
		printf("%u) Brightness value (%u to %u): %u\n", i, info[iDevice].minValue, info[iDevice].maxValue, config.brightnessVal);
		functions[i++] = funcBrightness;
	}
	else if (config.methodVal == methodACPI)
	{
		printf("%u) Brightness level: %u / %u\n", i, config.brightnessVal - SUSI_BACKLIGHT_LEVEL_MINIMUM, SUSI_BACKLIGHT_LEVEL_MAXIMUM - SUSI_BACKLIGHT_LEVEL_MINIMUM);
		functions[i++] = funcBrightness;
	}

	if ((info[iDevice].enableFlag & (1 << enableFrequency)) != 0)
	{
		printf("%u) Frequency: %u\n", i, config.frequencyVal);
		functions[i++] = funcFrequency;
	}

	if ((info[iDevice].enableFlag & (1 << enablePolarity)) != 0)
	{
		printf("%u) Polarity: ", i);
		config.polarityVal == SUSI_BACKLIGHT_POLARITY_ON ? printf("[Yes]/ No\n") : printf(" Yes /[No]\n");
		functions[i++] = funcPolarity;
	}

	if ((info[iDevice].enableFlag & (1 << enableBacklight)) != 0)
	{
		printf("%u) Backlight: ", i);
		config.backlightVal == SUSI_BACKLIGHT_SET_ON ? printf("[On]/ Off\n") : printf(" On /[Off]\n");
		functions[i++] = funcBacklight;
	}

	printf("%u) Get/Refresh all values\n", i);
	functions[i++] = funcGet;

	while (i < NELEMS(functions))
		functions[i++] = SUSIDEMO_FUNCTIONS_UNDEFINED;

	printf("\nEnter your choice: ");
}

void vga_main(void)
{
	uint32_t op;
	uint32_t tmp_u32;
	uint8_t dev = 0;
	char devName[NAME_MAXIMUM_LENGTH];
	VGAConfig config;

	get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_VGA_BACKLIGHT(devids[dev]), devName);
	brightness_method_init(dev, &config.methodVal);
	vga_get_config(dev, &config);

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
			if (vga_panel(&dev))
				goto pause;
			get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_VGA_BACKLIGHT(devids[dev]), devName);
			brightness_method_init(dev, &config.methodVal);
			vga_get_config(dev, &config);
			continue;

		case funcMethod:
			if (vga_method(dev, &config.methodVal))
				goto pause;
			vga_get_brightness(dev, config.methodVal, &config.brightnessVal);
			continue;

		case funcBrightness:
			if (vga_set_brightness(dev, config.methodVal))
				goto pause;
			continue;

		case funcFrequency:
			printf("\nFrequency (1 to 65535): %u Hz -> ", config.frequencyVal);
			if (input_uint(&tmp_u32, 10, 0xFFFF, 1))
			{
				printf("Invalid input\n");
				goto pause;
			}

			if (vga_set_frequency(dev, tmp_u32))
				goto pause;
			continue;

		case funcPolarity:
			if (vga_set_polarity(dev, config.polarityVal))
				goto pause;
			continue;

		case funcBacklight:
			if (vga_set_backlight(dev, config.backlightVal))
				goto pause;
			continue;

		case funcGet:
			if (vga_get_config(dev, &config))
				goto pause;
			continue;
		}
unknown:
		printf("Unknown choice!\n");
pause:
		printf("\nPress ENTER to continue. ");
		wait_enter();

		/* Get value after PAUSE */
		switch (functions[op])
		{
		case funcBrightness:
			vga_get_brightness(dev, config.methodVal, &config.brightnessVal);
			continue;

		case funcFrequency:
			vga_get_frequency(dev, &config.frequencyVal);
			continue;

		case funcPolarity:
			vga_get_polarity(dev, &config.polarityVal);
			continue;

		case funcBacklight:
			vga_get_backlight(dev, &config.backlightVal);
			continue;
		}
	}
}
