#include "common.h"

#define SUSIDEMO_INFORMATION_VALUE_MAX 7
static const char *infoValStr[] = {
	"Spec version",
	"Boot up times",
	"Running time (hours)",
	"Microsoft Plug-and-Play ID",
	"Platform revision",
	"Last Shutdown Status",
	"Last Shutdown Event"
};

#define SUSIDEMO_INFORMATION_STRING_MAX 9
static const char *infoStrStr[] = {
	"Board manufacturer",
	"Board name",
	"Board revision",
	"Board serial number",
	"BIOS revision",
	"Hardware revision",
	"Platform type",
	"Firmware name",
	"BIOS name"
};

#define SUSIDEMO_INFORMATION_VERSION_MAX 6
static const char *infoVerStr[] = {
	"Driver version",
	"Library version",
	"Firmware version",
	"SUSI_ID_BOARD_LAST_SHUTDOWN_STATUS_VAL",
	"SUSI_ID_BOARD_LAST_SHUTDOWN_EVENT_VAL",
	"EC protocol version",
};

uint8_t info_init(void)
{
	return SUSIDEMO_DEVICE_AVAILALBE;
}

static void info_title(void)
{
	printf("**********************************************\n");
	printf("**               SUSI4.0 demo               **\n");
	printf("**********************************************\n");
	printf("\nInformation\n\n");
}

static void print_uncompress_ASCII_PNP_ID(uint32_t pnp_id)
{
	uint16_t ascii_part = (uint16_t)((pnp_id >> 12) & 0x0000FFFF);
	uint8_t low_byte = (uint8_t)(ascii_part & 0x00FF);
	uint8_t high_byte = (uint8_t)(ascii_part >> 8);

	uint8_t first_char_pos = (uint8_t)(low_byte >> 2);
	uint8_t second_char_pos_high_part = (uint8_t)(low_byte & 0x03);
	uint8_t second_char_pos_low_part = (uint8_t)(high_byte >> 5);
	uint8_t second_char_pos = (uint8_t)((second_char_pos_high_part << 3) | second_char_pos_low_part);
	uint8_t third_char_pos = (uint8_t)(high_byte & 0x1F);

	char c1 = 64 + first_char_pos;
	char c2 = 64 + second_char_pos;
	char c3 = 64 + third_char_pos;
	uint16_t vendor_specific_id = (uint16_t)(pnp_id & 0x00000FFF);

	printf("%c%c%c, 0x%X\n", c1, c2, c3, vendor_specific_id);
}

static uint8_t get_value_info(void)
{
	uint32_t status, getVal, index, i;

	index = 0;
	for (i = 0; i < SUSIDEMO_INFORMATION_VALUE_MAX; i++)
	{
		status = SusiBoardGetValue(i, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			printf("%-30s: ", infoValStr[i]);

			switch (i)
			{
			case SUSI_ID_BOARD_PNPID_VAL:
				print_uncompress_ASCII_PNP_ID(getVal);
				break;

			case SUSI_ID_GET_SPEC_VERSION:
			case SUSI_ID_BOARD_PLATFORM_REV_VAL:
				printf("%u,%u\n", (getVal >> 24) & 0xFF, (getVal >> 16) & 0xFF);
				break;
			
			default:
				printf("%u\n", getVal);
				break;
			}
			index++;
		}
	}

	if (index == 0)
		return 1;

	return 0;
}

static uint8_t get_string_info(void)
{
	uint32_t status, index, i;
	char getStr[STRING_MAXIMUM_LENGTH];
	uint32_t getStrLen;

	index = 0;
	for (i = 0; i < SUSIDEMO_INFORMATION_STRING_MAX; i++)
	{
	getStrLen = STRING_MAXIMUM_LENGTH;
		status = SusiBoardGetStringA(i, getStr, &getStrLen);
		if (status == SUSI_STATUS_SUCCESS)
		{
			printf("%-30s: %s\n", infoStrStr[i], getStr);
			index++;
		}
	}

	if (index == 0)
		return 1;

	return 0;
}

static uint8_t get_customize_string(void)
{
	uint32_t status, index, i;
	char getStr[STRING_MAXIMUM_LENGTH];
	char getStrName[STRING_MAXIMUM_LENGTH];
	uint32_t getStrLen;

	index = 0;
	for (i = SUSI_ID_BOARD_OEM0_STR; i <= SUSI_ID_BOARD_OEM2_STR; i++)
	{
		getStrLen = STRING_MAXIMUM_LENGTH;
		status = SusiBoardGetStringA(0x10|(i), getStr, &getStrLen);
		if (status == SUSI_STATUS_SUCCESS)
		{
			getStrLen = STRING_MAXIMUM_LENGTH;
			SusiBoardGetStringA(SUSI_ID_MAPPING_GET_NAME_INFO(i), getStrName, &getStrLen);
			printf("%-30s: %s\n", getStrName, getStr);
			index++;
		}
	}

	if (index == 0)
		return 1;

	return 0;
}

static uint8_t get_version(void)
{
	uint32_t status, getVal, index, i;

	index = 0;
	for (i = 0; i < SUSIDEMO_INFORMATION_VERSION_MAX; i++)
	{
		/*
		ID 3 and 4 only define in C# demo ap
		public const UInt32 SUSI_ID_BOARD_LAST_SHUTDOWN_STATUS_VAL = 0x00010003;
        public const UInt32 SUSI_ID_BOARD_LAST_SHUTDOWN_EVENT_VAL  = 0x00010004;
		*/
		if (i == 3 || i == 4)
			continue;

		status = SusiBoardGetValue(SUSI_ID_BOARD_VER_BASE + i, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			printf("%-30s: ", infoVerStr[i]);

			switch (SUSI_ID_BOARD_VER_BASE + i)
			{
			case SUSI_ID_BOARD_DRIVER_VERSION_VAL:
			case SUSI_ID_BOARD_LIB_VERSION_VAL:
			case SUSI_ID_BOARD_FIRMWARE_VERSION_VAL:
				printf("%u.%u.%u\n", (getVal >> 24), ((getVal >> 16) & 0xFF), (getVal & 0xFFFF));
				break;
			case SUSI_ID_BOARD_DOCUMENT_VERSION_VAL:
				printf("%u.%u.%u\n", (getVal & 0xFF), ((getVal >> 8) & 0xFF), ((getVal >> 16) & 0xFF));
				break;

			default:
				printf("%u\n", getVal);
				break;
			}
			index++;
		}
	}

	if (index == 0)
		return 1;

	return 0;
}

void info_main(void)
{
	clr_screen();
	info_title();
	get_value_info();
	get_string_info();
	get_customize_string();
	
	get_version();

	printf("\nPress ENTER to continue. ");
	wait_enter();
}
