#include "common.h"

/*#define SUSIDEMO_HWM_ITEM_MAX 5*/

/*static int8_t item[SUSIDEMO_HWM_ITEM_MAX];*/

static int8_t volt[SUSI_ID_HWM_VOLTAGE_MAX];
static int8_t temp[SUSI_ID_HWM_TEMP_MAX];
static int8_t fan[SUSI_ID_HWM_FAN_MAX];
static int8_t current[SUSI_ID_HWM_CURRENT_MAX];
static int8_t caseopen[SUSI_ID_HWM_CASEOPEN_MAX];
static int8_t co_opened[SUSI_ID_HWM_CASEOPEN_MAX];	/* case-open which is open */

static char HwmName[NAME_MAXIMUM_LENGTH];

/*#define SUSIDEMO_HWM_FUNCTION_MAX 5*/
/*static int8_t func[SUSIDEMO_HWM_FUNCTION_MAX];*/
static const char *funcStr[] = {
	"Voltage",	
	"Temperature",
	"Fan speed",
	"Current",
	"Case open",
};

enum funcRank{
	funcVolt,	
	funcTemp,
	funcFan,
	funcCurrent,
	funcCaseOpen,
	NumFunc,
};

static int8_t functions[NumFunc + 1];	/* NumFunc + GoBack */

void hwm_init_item(int8_t maxNum, uint32_t idBase, int8_t *parrayItem)
{
	uint32_t status, getVal = 0;
	int8_t index, i;

	index = 0;
	for (i = 0; i < maxNum; i++)
	{
		status = SusiBoardGetValue(idBase + i, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			parrayItem[index] = i;
			index++;
		}
#ifdef _DEBUG
		else
		{
			if (status != SUSI_STATUS_UNSUPPORTED)
				printf("SusiBoardGetValue(0x%08X) failed. (0x%08X)\n", idBase + i, status);
		}
#endif
	}

	for (i = index; i < maxNum; i++)
		parrayItem[i] = -1;
}

uint8_t hwm_init(void)
{
	uint8_t index;

	index = 0;	/* index for WatchDog functions */
	functions[index++] = SUSIDEMO_FUNCTIONS_GOBACK;

	hwm_init_item(SUSI_ID_HWM_VOLTAGE_MAX, SUSI_ID_HWM_VOLTAGE_BASE, volt);
	if (volt[0] > -1)
	{
		functions[index] = funcVolt;
		index++;
	}

	hwm_init_item(SUSI_ID_HWM_TEMP_MAX, SUSI_ID_HWM_TEMP_BASE, temp);
	if (temp[0] > -1)
	{
		functions[index] = funcTemp;
		index++;
	}

	hwm_init_item(SUSI_ID_HWM_FAN_MAX, SUSI_ID_HWM_FAN_BASE, fan);
	if (fan[0] > -1)
	{
		functions[index] = funcFan;
		index++;
	}

	hwm_init_item(SUSI_ID_HWM_CURRENT_MAX, SUSI_ID_HWM_CURRENT_BASE, current);
	if (current[0] > -1)
	{
		functions[index] = funcCurrent;
		index++;
	}

	hwm_init_item(SUSI_ID_HWM_CASEOPEN_MAX, SUSI_ID_HWM_CASEOPEN_BASE, caseopen);
	if (caseopen[0] > -1)
	{
		functions[index] = funcCaseOpen;
		index++;
	}

	if (index <= 1)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	while (index < NELEMS(functions))
		functions[index++] = SUSIDEMO_FUNCTIONS_UNDEFINED;
	
	return SUSIDEMO_DEVICE_AVAILALBE;
}

static uint8_t hwm_get_name(SusiId_t based_id, char *pName)
{
	uint32_t length = NAME_MAXIMUM_LENGTH, tmpLength = length;	/* include '\0': strlen + 1 */
	SusiId_t mapped_id = SUSI_ID_MAPPING_GET_NAME_HWM(based_id);
	SusiStatus_t status = SusiBoardGetStringA(mapped_id, pName, &tmpLength);

	switch (status)
	{
	case SUSI_STATUS_MORE_DATA:
		pName[length - 2] = '*';
		pName[length - 1] = '\0';		
		break;

	case SUSI_STATUS_ERROR:
		STRING_CP(pName, "Unknown_Name");
		break;

	case SUSI_STATUS_SUCCESS:
		break;

	default:
		STRING_CP(pName, "Unknown_Name");
		/*printf("hwm_get_name() failed. (0x%08X)\n", status);*/
		return 1;
	}

	return 0;
}

static uint8_t title(void)
{
	printf("**********************************************\n");
	printf("**               SUSI4.0 demo               **\n");
	printf("**********************************************\n");
	printf("\nHardware Monitor\n\n");

	return 0;
}

static uint8_t get_voltage(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint32_t getVal;
	float convVal;
	int8_t i;

	if (volt[0] == -1)
		return 1;

	printf("\nVoltage\n\n");
	
	for (i = 0; i < SUSI_ID_HWM_VOLTAGE_MAX && volt[i] > -1; i++)
	{
		id = SUSI_ID_HWM_VOLTAGE_BASE + volt[i];
		hwm_get_name(id, HwmName);
		status = SusiBoardGetValue(id, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			convVal = (int32_t)getVal / (float)1000;
			printf("%-15s: %.3f V\n", HwmName, convVal);
		}
		else
		{
			printf("%-15s: get voltage failed. (0x%08X)\n", HwmName, status);
		}
	}

	printf("\n");

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t get_temperature(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint32_t getVal;
	float convVal;
	int8_t i;

	if (temp[0] == -1)
		return 1;

	printf("\nTemperature\n\n");

	for (i = 0; i < SUSI_ID_HWM_TEMP_MAX && temp[i] > -1; i++)
	{
		id = SUSI_ID_HWM_TEMP_BASE + temp[i];
		hwm_get_name(id, HwmName);
		status = SusiBoardGetValue(id, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			convVal = SUSI_DECODE_CELCIUS((float)getVal);
			printf("%-15s: %.1f Celsius\n", HwmName, convVal);
		}
		else
		{
			printf("%-15s: get temperature failed. (0x%08X)\n", HwmName, status);
		}
	}

	printf("\n");

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t get_fan_speed(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint32_t getVal;
	float convVal;
	int8_t i;

	if (fan[0] == -1)
		return 1;

	printf("\nFan Speed\n\n");
	
	for (i = 0; i < SUSI_ID_HWM_FAN_MAX && fan[i] > -1; i++)
	{
		id = SUSI_ID_HWM_FAN_BASE + fan[i];
		hwm_get_name(id, HwmName);
		status = SusiBoardGetValue(id, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			convVal = (float)getVal;
			printf("%-15s: %.0f RPM\n", HwmName, convVal);
		}
		else
		{
			printf("%-15s: get fan speed failed. (0x%08X)\n", HwmName, status);
		}
	}

	printf("\n");

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t get_current(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint32_t getVal;
	float convVal;
	int8_t i;

	if (current[0] == -1)
		return 1;

	printf("\nCurrent\n\n");

	for (i = 0; i < SUSI_ID_HWM_CURRENT_MAX && current[i] > -1; i++)
	{
		id = SUSI_ID_HWM_CURRENT_BASE + current[i];
		hwm_get_name(id, HwmName);
		status = SusiBoardGetValue(id, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			convVal = (int32_t)getVal / (float)1000;
			printf("%-15s: %.3f A\n", HwmName, convVal);
		}
		else
		{
			printf("%-15s: get current failed. (0x%08X)\n", HwmName, status);
		}
	}

	printf("\n");

	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t get_case_open(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint32_t getVal;
	int8_t index, i;

	if (caseopen[0] == -1)
		return 1;
	
	printf("\nCase Open\n\n");
	
	index = 0;
	for (i = 0; i < SUSI_ID_HWM_CASEOPEN_MAX && caseopen[i] > -1; i++)
	{
		id = SUSI_ID_HWM_CASEOPEN_BASE + caseopen[i];
		hwm_get_name(id, HwmName);
		getVal = 0;
		status = SusiBoardGetValue(id, &getVal);
		if (status == SUSI_STATUS_SUCCESS)
		{
			if (getVal == 0)
			{
				printf("%-15s: Normal\n", HwmName);
			}
			else
			{
				printf("%-15s: Been Opened\n", HwmName);
				co_opened[index] = i;
				index++;
			}
		}
		else
		{
			printf("%-15s: get case open failed. (0x%08X)\n", HwmName, status);
		}
	}

	printf("\n");

	for (i = index; i < SUSI_ID_HWM_CASEOPEN_MAX; i++)
		co_opened[i] = -1;

	return 0;
}

static uint8_t clear_case_open(uint8_t caseopenIndex)
{
	SusiStatus_t status;
	SusiId_t id;
	uint32_t setVal;

	id = SUSI_ID_HWM_CASEOPEN_BASE + caseopenIndex;
	setVal = CASEOPEN_CLEAR_CMD;

	status = SusiBoardGetValue(id, &setVal);
	if (status != SUSI_STATUS_SUCCESS)
	{
		hwm_get_name(id, HwmName);
		printf("%-15s: clear case open failed. (0x%08X)\n", HwmName, status);
		return 1;
	}

	return 0;
}

static uint8_t show_menu_caseopen_opend(void)
{
	uint8_t i;

	printf("\n");
	printf("0) Back to HWM menu\n");
	printf("1) Refresh\n");
	
	for (i = 0; i < SUSI_ID_HWM_CASEOPEN_MAX && co_opened[i] > -1; i++)
	{
		hwm_get_name(SUSI_ID_HWM_CASEOPEN_BASE + co_opened[i], HwmName);
		printf("%u) Clears %s\n", i + 2, HwmName);
	}
	
	printf("\nEnter your choice: ");
	fflush(stdout);

	return 0;
}

static uint8_t menu(void)
{
	uint8_t i;

	printf("0) Back to Main menu\n");	
	
	for (i = 1; i < NELEMS(functions) && functions[i] != SUSIDEMO_FUNCTIONS_UNDEFINED; i++)
		printf("%u) %s\n", i, funcStr[functions[i]]);
		
	printf("\nEnter your choice: ");
	fflush(stdout);

	return 0;
}

static uint8_t hwm_main_caseopen_opend(void)
{
	int32_t op;

	for (;;)
	{
		clr_screen();
		if (title() != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
			break;
		}

		get_case_open();
		show_menu_caseopen_opend();

		if (SCANF_IN("%d", &op) <= 0)
			op = -1;
		
		wait_enter();

		if (op == 0)
		{
			clr_screen();
			break;
		}

		if (op == 1)
		{
			continue;
		}

		if (op < 2 || op > SUSI_ID_HWM_CASEOPEN_MAX + 1)
		{
			printf("\nUnknown choice!\n\n");
			continue;
		}

		if (co_opened[op - 2] >= 0)
			clear_case_open(co_opened[op - 2]);
		else
			printf("\nUnknown choice!\n\n");
	}

	return SUSIDEMO_PRINT_NONE;
}

void hwm_main(void)
{
	uint32_t op;

	while (1)
	{
		clr_screen();
		title();
		menu();

		if (input_uint(&op, 10, NELEMS(functions), 0))
			goto unknown;

		switch (functions[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return;

		case funcVolt:
			if (get_voltage())
				goto pause;
			continue;

		case funcTemp:
			if (get_temperature())
				goto pause;
			continue;

		case funcFan:
			if (get_fan_speed())
				goto pause;
			continue;

		case funcCurrent:
			if (get_current())
				goto pause;
			continue;

		case funcCaseOpen:
			if (hwm_main_caseopen_opend())
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
