#include "common.h"

struct SusiPage {
	const char *name;
	uint8_t (*pfuncinit) (void);	/* returns 0 if device is not available */
	void (*pfuncmain) (void);
};

static struct SusiPage page_tbl[] = {
	{"Watch Dog",			wdog_init,		wdog_main},
	{"HWM",					hwm_init,		hwm_main},
	{"Smart Fan",			sfan_init,		sfan_main},
	{"GPIO",				gpio_init,		gpio_main},
	{"VGA",					vga_init,		vga_main},
	{"SMBus",				smb_init,		smb_main},
	{"I2C",					iic_init,		iic_main},
	{"Storage",				storage_init,	storage_main},
	{"Thermal Protection",	thmprot_init,	thmprot_main},
	{"Information",			info_init,		info_main},
};

static int8_t options2pages[NELEMS(page_tbl) + 1];	/* page_num + exit */
static const uint8_t maxpageoption = NELEMS(options2pages);

static void main_title(void)
{
	printf(
		"**********************************************\n"
		"**               SUSI4.0 demo               **\n"
		"**********************************************\n\n");

	printf("Main (demo version : %d.%d.%d.%d)\n\n", VER_MAJOR, VER_MINOR, VER_BUILD, VER_FIX);
}

#define SUSIDEMO_MAIN_PAGES_EXIT		SUSIDEMO_FUNCTIONS_GOBACK
#define SUSIDEMO_MAIN_PAGES_UNDEFINED	SUSIDEMO_FUNCTIONS_UNDEFINED

static int8_t main_init(void)
{
	uint8_t op = 0, i;

	options2pages[op++] = SUSIDEMO_MAIN_PAGES_EXIT;

	for (i = 0; i < NELEMS(page_tbl); i++)
	{
		if (page_tbl[i].pfuncinit())
		{
			options2pages[op++] = i;
		}
	}

	if (!op)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	while (op < maxpageoption)
	{
		options2pages[op++] = SUSIDEMO_MAIN_PAGES_UNDEFINED;
	}

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static void menu(void)
{
	uint8_t i;

	for (i = 0; i < maxpageoption && options2pages[i] != SUSIDEMO_MAIN_PAGES_UNDEFINED; i++)
	{
		if (options2pages[i] == SUSIDEMO_MAIN_PAGES_EXIT)
		{
			printf("%u) Terminate this program\n", i);
		}
		else
		{
			printf("%u) %s\n", i, page_tbl[options2pages[i]].name);
		}
	}

	printf("\nEnter your choice: ");
	fflush(stdout);
}

int main(void)
{
	SusiStatus_t status;
	uint32_t op; 
	int ret = 0;

	status = SusiLibInitialize();

	if (status == SUSI_STATUS_ERROR)
	{
		// This error only occurs on Linux distributions
		printf("Your Linux capabilities is not enough, recommond to become ROOT!\n");
		printf("Aborting demo now.\n");
		return -1;
	}

	if (status != SUSI_STATUS_SUCCESS && status != SUSI_STATUS_INITIALIZED)
	{
		printf("SusiLibInitialize() failed. (0x%08X)\n", status);
		printf("Exit the program...\n");
		return -1;
	}

	if (!main_init())
	{
		printf("No available page.\n");
		ret = -1;
		goto exit;
	}

	while (1)
	{
		clr_screen();
		main_title();
		menu();

		if (input_uint(&op, 10, maxpageoption, 0))
			goto unknown;
		
		if (options2pages[op] == SUSIDEMO_MAIN_PAGES_UNDEFINED)
			goto unknown;

		if (options2pages[op] == SUSIDEMO_MAIN_PAGES_EXIT)
			break;

		page_tbl[options2pages[op]].pfuncmain();

		continue;
unknown:
		printf("Unknown choice!\n");
		printf("\nPress ENTER to continue. ");
		wait_enter();
	}
exit:
	printf("Exit the program...\n");

	status = SusiLibUninitialize();

	if (ret)
		return ret;

	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiLibUninitialize() failed. (%8X)\n", status);
		return -1;
	}

	return 0;
}
