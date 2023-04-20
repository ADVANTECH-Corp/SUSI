#include "common.h"

struct WDogInfo {
	uint32_t unit;
	uint32_t maxDelay, minDelay, timeDelay;
	uint32_t maxReset, minReset, timeReset;
	uint32_t maxEvent, minEvent, timeEvent;
	uint32_t eventType, eventFlag;
};

static struct WDogInfo info[SUSI_ID_WATCHDOG_MAX];
static SusiId_t devids[SUSI_ID_WATCHDOG_MAX];
static const uint8_t maxdevice = NELEMS(devids);

struct WDogFunc {
	const char *description;
};

enum funcRank{
	funcDev,
	funcStart,
	funcTrigger,
	funcStop,
	NumFunc,
};

static int8_t functions[NumFunc + 1];	/* NumFunc + GoBack */

enum funcStartRank{
	funcStartDelay,
	funcStartReset,
	funcStartEvType,
	funcStartEvent,	
	funcStartRun,
	NumFuncStart,
};

static const char *evtypeStr[] = {
	"None",
	"IRQ",
	"SCI",
	"Power Button",
	"PIN"
};

enum evtypeRank{
	evtypeNone,		/* = SUSI_WDT_EVENT_TYPE_NONE */
	evtypeIRQ,		/* = SUSI_WDT_EVENT_TYPE_IRQ */
	evtypeSCI,		/* = SUSI_WDT_EVENT_TYPE_SCI */
	evtypePWBTN,	/* = SUSI_WDT_EVENT_TYPE_PWRBTN */
	evtypePIN, 		/* = SUSI_WDT_EVENT_TYPE_PIN */
	NumEventType,
};

static int8_t evtype[NumEventType];

uint8_t wdog_init(void)
{
	SusiStatus_t status;
	SusiId_t id;
	uint8_t index, i;

	index = 0;	/* index for devices */
	for (i = 0; i < maxdevice; i++)
	{
		id = (SusiId_t)i;

		status = SusiWDogGetCaps(id, SUSI_ID_WDT_SUPPORT_FLAGS, &info[index].eventFlag);
		if (status != SUSI_STATUS_SUCCESS)
			continue;

		status = SusiWDogGetCaps(id, SUSI_ID_WDT_UNIT_MINIMUM, &info[index].unit);
		if (status != SUSI_STATUS_SUCCESS)
			continue;
		if (info[index].unit == 0)
			continue;

		status = SusiWDogGetCaps(id, SUSI_ID_WDT_DELAY_MAXIMUM, &info[index].maxDelay);
		if (status != SUSI_STATUS_SUCCESS)
			info[index].maxDelay = 0;
		if (info[index].maxDelay > 0)
		{
			status = SusiWDogGetCaps(id, SUSI_ID_WDT_DELAY_MINIMUM, &info[index].minDelay);
			if (status != SUSI_STATUS_SUCCESS)
				info[index].minDelay = 0;
		}

		status = SusiWDogGetCaps(id, SUSI_ID_WDT_RESET_MAXIMUM, &info[index].maxReset);
		if (status != SUSI_STATUS_SUCCESS)
			info[index].maxReset = 0;
		if (info[index].maxReset > 0)
		{
			status = SusiWDogGetCaps(id, SUSI_ID_WDT_RESET_MINIMUM, &info[index].minReset);
			if (status != SUSI_STATUS_SUCCESS)
				info[index].minReset = 0;
		}

		status = SusiWDogGetCaps(id, SUSI_ID_WDT_EVENT_MAXIMUM, &info[index].maxEvent);
		if (status != SUSI_STATUS_SUCCESS)
			info[index].maxEvent = 0;
		if (info[index].maxEvent > 0)
		{
			status = SusiWDogGetCaps(id, SUSI_ID_WDT_EVENT_MINIMUM, &info[index].minEvent);
			if (status != SUSI_STATUS_SUCCESS)
				info[index].minEvent = 0;
		}

		info[index].timeDelay = 0;
		info[index].timeReset = 0;
		info[index].timeEvent= 0;
		info[index].eventType= evtypeNone;

		devids[index++] = id;
	}

	if (!index)
		return SUSIDEMO_DEVICE_UNAVAILALBE;
	
	while (index < maxdevice)
		devids[index++] = SUSIDEMO_DEVICEID_UNDEFINED;

	index = 0;	/* index for WatchDog functions */
	functions[index++] = SUSIDEMO_FUNCTIONS_GOBACK;

	for (i = 0; i < NumFunc; i++)
		functions[index++] = i;

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static void support_evtype_init(uint8_t iDevice)
{
	uint8_t index = 0;

	if (info[iDevice].eventFlag)
	{
		evtype[index++] = evtypeNone;

		if (info[iDevice].eventFlag & SUSI_WDT_FLAG_SUPPORT_IRQ)
			evtype[index++] = evtypeIRQ;

		if (info[iDevice].eventFlag & SUSI_WDT_FLAG_SUPPORT_SCI)
			evtype[index++] = evtypeSCI;

		if (info[iDevice].eventFlag & SUSI_WDT_FLAG_SUPPORT_PWRBTN)
			evtype[index++] = evtypePWBTN;

		if (info[iDevice].eventFlag & SUSI_WDT_FLAG_SUPPORT_PIN)
			evtype[index++] = evtypePIN;

		while (index < NumEventType)
			evtype[index++] = SUSIDEMO_ITEM_UNDEFINED;
	}
}

static void title(const char *name)
{
	printf(
		"**********************************************\n"
		"**               SUSI4.0 demo               **\n"
		"**********************************************\n\n");

	printf("%s\n\n", name);
}

static uint8_t wdog_timer(uint8_t *iDevice)
{
	if (*iDevice == 0 && devids[1] == SUSIDEMO_DEVICEID_UNDEFINED)
	{
		printf("Only a Watch Dog timer.\n");
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

static uint8_t wdog_evtype(uint32_t *EventType)
{
	uint8_t i;

	if (evtype[1] == SUSIDEMO_ITEM_UNDEFINED)
	{
		*EventType = evtype[0];
		printf("Only a control mode.\n");
		return SUSIDEMO_PRINT_SUCCESS;
	}

	for (i = 0; i < NumEventType; i++)
	{
		if (evtype[i] == *EventType)
			break;
	}

	if (i + 1 >= NumEventType)
	{
		*EventType = 0;
		return SUSIDEMO_PRINT_NONE;
	}
	
	if (evtype[i + 1] != SUSIDEMO_ITEM_UNDEFINED)
	{
		*EventType = i + 1;
		return SUSIDEMO_PRINT_NONE;
	}

	*EventType = 0;
	return SUSIDEMO_PRINT_NONE;
}

static void SUSI_API wdog_callback_print(void* context)
{
	printf(
		"\n"
		"================\n"
		"=Get IRQ Event!=\n"
		"================\n\n");
}

static uint8_t wdog_start(uint8_t iDevice)
{
	SusiStatus_t status;
	SusiId_t id = devids[iDevice];

	if (info[iDevice].eventType == evtypeIRQ && info[iDevice].timeEvent > 0)
		SusiWDogSetCallBack(id, (SUSI_WDT_INT_CALLBACK)&wdog_callback_print, NULL);

	status = SusiWDogStart(id, info[iDevice].timeDelay, info[iDevice].timeEvent, info[iDevice].timeReset, info[iDevice].eventType);

	if (status != SUSI_STATUS_SUCCESS)
	{
		if (status == SUSI_STATUS_RUNNING)
			printf("Watchdog is running. (0x%08X)\n", status);
		else if (status == SUSI_STATUS_UNSUPPORTED)
			printf("Unsupported this event type. (0x%08X)\n", status);
		else
			printf("SusiWDogStart() failed. (0x%08X)\n", status);

		return SUSIDEMO_PRINT_ERROR;
	}
	
	printf("SusiWDogStart() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t wdog_trigger(uint8_t iDevice)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status = SusiWDogTrigger(id);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiWDogTrigger() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiWDogTrigger() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static uint8_t wdog_stop(uint8_t iDevice)
{
	SusiId_t id = devids[iDevice];
	SusiStatus_t status = SusiWDogStop(id);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiWDogStop() failed. (0x%08X)\n", status);
		return SUSIDEMO_PRINT_ERROR;
	}

	printf("SusiWDogStop() succeed.\n");
	return SUSIDEMO_PRINT_SUCCESS;
}

static void menu_start(int8_t *manuItem, uint8_t numManuItem, struct WDogInfo info)
{
	uint8_t i;

	printf("Start Watchdog:\n\n");

	manuItem[0] = SUSIDEMO_FUNCTIONS_GOBACK;
	printf("0) Back to Watch Dog menu\n");

	i = 1;

	if (info.maxDelay > 0)
	{
		manuItem[i] = funcStartDelay;
		printf("%u) Delay time (%u to %u): %u\n", i, info.minDelay, info.maxDelay, info.timeDelay);
		i++;
	}

	if (info.maxReset > 0)
	{
		manuItem[i] = funcStartReset;
		printf("%u) Reset time (%u to %u): %u\n", i, info.minReset, info.maxReset, info.timeReset);
		i++;
	}

	if (info.maxEvent > 0 && info.eventFlag)
	{
		uint8_t j;

		manuItem[i] = funcStartEvType;
		printf("%u) Event type:", i);
		for (j = 0; j < NumEventType && evtype[j] > SUSIDEMO_ITEM_UNDEFINED; j++)
		{
			if (j > 0)
				printf("/");

			if (j == info.eventType)
				printf("[%s]", evtypeStr[j]);
			else
				printf(" %s ", evtypeStr[j]);
		}
		printf("\n");

		i++;
	}

	if (info.maxEvent > 0 && info.eventType != evtypeNone)
	{
		manuItem[i] = funcStartEvent;
		printf("%u) Event time (%u to %u): %u\n", i, info.minEvent, info.maxEvent, info.timeEvent);
		i++;
	}

	if (i > 1)
	{
		manuItem[i] = funcStartRun;
		printf("%u) Run\n", i++);
	}

	while (i < numManuItem)
		manuItem[i++] = SUSIDEMO_FUNCTIONS_UNDEFINED;

	printf("\nEnter your choice: ");
	fflush(stdout);
}

static uint8_t wdog_start_loop(uint8_t iDevice, const char *devName)
{
	uint32_t op;
	uint32_t tmp_u32;
	int8_t manuItem[NumFuncStart + 1];

	while (1)
	{
		clr_screen();
		title(devName);
		menu_start(manuItem, NELEMS(manuItem), info[iDevice]);

		if (input_uint(&op, 10, NELEMS(manuItem), 0))
			goto unknown;

		switch (manuItem[op])
		{
		case SUSIDEMO_FUNCTIONS_GOBACK:
			return SUSIDEMO_PRINT_NONE;

		case funcStartDelay:
			printf("Delay Time (unit: %u ms): ", info[iDevice].unit);
			fflush(stdout);
			if (input_uint(&tmp_u32, 10, info[iDevice].maxDelay, info[iDevice].minDelay))
			{
				printf("Invalid input\n");
				goto pause;
			}

			if ((info[iDevice].timeDelay = tmp_u32 - (tmp_u32 % info[iDevice].unit)) != tmp_u32)
			{
				printf("Not fit in %u unit, your input transfers to %u.\n", info[iDevice].unit, info[iDevice].timeDelay);
				goto pause;
			}
			continue;

		case funcStartReset:
			printf("Reset Time (unit: %u ms): ", info[iDevice].unit);
			fflush(stdout);
			if (input_uint(&tmp_u32, 10, info[iDevice].maxReset, info[iDevice].minReset))
			{
				printf("Invalid input\n");
				goto pause;
			}

			if ((info[iDevice].timeReset = tmp_u32 - (tmp_u32 % info[iDevice].unit)) != tmp_u32)
			{
				printf("Not fit in %u unit, your input transfers to %u.\n", info[iDevice].unit, info[iDevice].timeReset);
				goto pause;
			}
			continue;

		case funcStartEvType:
			if (wdog_evtype(&info[iDevice].eventType))
				goto pause;
			continue;

		case funcStartEvent:
			printf("Event Time (unit: %u ms): ", info[iDevice].unit);
			fflush(stdout);
			if (input_uint(&tmp_u32, 10, info[iDevice].maxEvent, info[iDevice].minEvent))
			{
				printf("Invalid input\n");
				goto pause;
			}

			if ((info[iDevice].timeEvent = tmp_u32 - (tmp_u32 % info[iDevice].unit)) != tmp_u32)
			{
				printf("Not fit in %u unit, your input transfers to %u.\n", info[iDevice].unit, info[iDevice].timeEvent);
				goto pause;
			}
			continue;

		case funcStartRun:
			return wdog_start(iDevice);
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
	uint8_t i;

	printf("0) Back to Main menu\n");

	printf("1) Select watchdog timer: ");
	for (i = 0; i < maxdevice && devids[i] != SUSIDEMO_DEVICEID_UNDEFINED; i++)
	{
		if (i > 0)
			printf("/");

		if (i == iDevice)
			printf("[%u]", i);
		else
			printf(" %u ", i);
	}
	printf("\n");

	printf("2) Start\n");
	printf("3) Trigger\n");
	printf("4) Stop\n");

	printf("\nEnter your choice: ");
	fflush(stdout);
}

void wdog_main(void)
{
	uint32_t op;
	uint8_t dev = 0;
	char devName[NAME_MAXIMUM_LENGTH];

	get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_WDT(devids[dev]), devName);
	support_evtype_init(dev);
	
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
			if (wdog_timer(&dev))
				goto pause;
			get_susi4_id_name(SUSI_ID_MAPPING_GET_NAME_WDT(devids[dev]), devName);
			support_evtype_init(dev);
			continue;

		case funcStart:
			if (wdog_start_loop(dev, devName))
				goto pause;
			continue;

		case funcTrigger:
			if (wdog_trigger(dev))
				goto pause;
			continue;

		case funcStop:
			if (wdog_stop(dev))
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
