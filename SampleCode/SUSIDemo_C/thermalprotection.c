#include "common.h"

static const char *tempStr[] = {
	"CPU",
	"CHIPSET",
	"SYSTEM",
	"CPU2",
	"OEM0",
	"OEM1",
	"OEM2",
	"OEM3",
	"OEM4",
	"OEM5"
};

#define SUSIDEMO_THERMAL_EVENT_MAX 4

typedef struct {
	uint32_t id;
	uint32_t source;
} TEMPInfo, *PTEMPInfo;

typedef struct {
	SusiThermalProtect config;
	uint32_t supportFlags;
	uint32_t triggerMaximum;   /* 0.1 Kelvins */
	uint32_t triggerMinimum;
	uint32_t clearMaximum;
	uint32_t clearMinimum;
	TEMPInfo tmlSource[SUSI_ID_HWM_TEMP_MAX];
} ThermalInfo, *PThermalInfo;

static ThermalInfo info[SUSI_ID_THERMAL_MAX];
static int8_t tmlprot[SUSI_ID_THERMAL_MAX];

#define SUSIDEMO_THERMAL_FUNCTION_MAX 7
static int8_t func[SUSIDEMO_THERMAL_FUNCTION_MAX];
enum funcRank{
	funcTmlProt,
	funcSource,
	funcType,
	funcTrigger,
	funcClear,
	funcGet,
	funcSet
};

uint8_t thmprot_init(void)
{
	uint32_t status, tmlprot_id, tmlsrc_id;
	uint8_t tmlprot_index, tmlsrc_index, i, j;

	tmlprot_index = 0;
	for (i = 0; i < SUSI_ID_THERMAL_MAX; i++)
	{
		tmlprot_id = i;

		status = SusiThermalProtectionGetConfig(tmlprot_id, &info[i].config);
		if (status != SUSI_STATUS_SUCCESS)
			continue;

		SusiThermalProtectionGetCaps(tmlprot_id, SUSI_ID_TP_EVENT_SUPPORT_FLAGS, &info[i].supportFlags);
		SusiThermalProtectionGetCaps(tmlprot_id, SUSI_ID_TP_EVENT_TRIGGER_MAXIMUM, &info[i].triggerMaximum);
		SusiThermalProtectionGetCaps(tmlprot_id, SUSI_ID_TP_EVENT_TRIGGER_MINIMUM, &info[i].triggerMinimum);
		SusiThermalProtectionGetCaps(tmlprot_id, SUSI_ID_TP_EVENT_CLEAR_MAXIMUM, &info[i].clearMaximum);
		SusiThermalProtectionGetCaps(tmlprot_id, SUSI_ID_TP_EVENT_CLEAR_MINIMUM, &info[i].clearMinimum);

		tmlsrc_index = 0;
		for (j = 0; j < SUSI_ID_HWM_TEMP_MAX; j++)
		{
			tmlsrc_id = SUSI_ID_HWM_TEMP_BASE + j;
			status = SusiThermalProtectionGetCaps(tmlprot_id, tmlsrc_id, &info[i].tmlSource[tmlsrc_index].source);
			if (status == SUSI_STATUS_SUCCESS)
			{
				info[i].tmlSource[tmlsrc_index].id = tmlsrc_id;
				tmlsrc_index++;
			}
		}

		for (j = tmlsrc_index; j < SUSI_ID_HWM_TEMP_MAX; j++)
			info[i].tmlSource[j].id = (uint8_t)-1;

		tmlprot[tmlprot_index] = i;
		tmlprot_index++;
	}

	if (tmlprot_index == 0)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	for (i = tmlprot_index; i < SUSI_ID_THERMAL_MAX; i++)
		tmlprot[i] = -1;

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static uint8_t title(uint8_t iTmlProt)
{
	printf("**********************************************\n");
	printf("**               SUSI4.0 demo               **\n");
	printf("**********************************************\n");

	if (iTmlProt >= SUSI_ID_THERMAL_MAX)
	{
		printf("ERROR: The thermal protection is not exist.\n");
		return 1;
	}

	printf("\nThermal Protection: Zone %u\n\n", iTmlProt + 1);

	return 0;
}

static uint8_t select_tmlprot(uint8_t *piTmlProt)
{
	uint32_t tmp_u32;
	uint8_t i;

	printf("\nThermal Protection:\n");
	for (i = 0; i < SUSI_ID_THERMAL_MAX && tmlprot[i] > -1; i++)
	{
		if (tmlprot[i] == *piTmlProt)
			printf("%u) [Zone %d]\n", i, tmlprot[i] + 1);
		else
			printf("%u) Zone %d\n", i, tmlprot[i] + 1);
	}

	if (i == 1)
	{
		*piTmlProt = tmlprot[0];
		printf("Only Zone %u is available.\n", *piTmlProt);
		printf("\nPress ENTER to continue. ");
		wait_enter();
		return 0;
	}

	tmp_u32 = 0;
	do {
		printf("\nEnter your choice (0 to %u): ", i - 1);
		fflush(stdout);
	} while (input_uint(&tmp_u32, 10, i - 1, 0) != 0);

	*piTmlProt = tmlprot[tmp_u32];

	return 0;
}

static uint8_t select_source(uint8_t iTmlProt, uint32_t *psourceId)
{
	uint32_t tmp_u32;
	uint8_t i;

	printf("\nThermal Source:\n");
	for (i = 0; i < SUSI_ID_HWM_TEMP_MAX && info[iTmlProt].tmlSource[i].id != (uint8_t)-1; i++)
	{
		if (info[iTmlProt].tmlSource[i].id == *psourceId)
			printf("%u) [%s]\n", i, tempStr[info[iTmlProt].tmlSource[i].id - SUSI_ID_HWM_TEMP_BASE]);
		else
			printf("%u) %s\n", i, tempStr[info[iTmlProt].tmlSource[i].id - SUSI_ID_HWM_TEMP_BASE]);
	}

	tmp_u32 = 0;
	do {
		printf("\nEnter your choice (0 to %u): ", i - 1);
		fflush(stdout);
	} while (input_uint(&tmp_u32, 10, i - 1, 0) != 0);

	*psourceId = info[iTmlProt].tmlSource[tmp_u32].id;

	return 0;
}

static uint8_t select_event_type(uint8_t iTmlProt, uint32_t *peventType)
{
	uint32_t indexConv[SUSIDEMO_THERMAL_EVENT_MAX], tmp_u32;
	uint8_t i;

	printf("\nEvent Type:\n");
	printf("0) None\n");
	indexConv[0] = SUSI_THERMAL_EVENT_NONE;

	i = 1;
	if ((info[iTmlProt].supportFlags & SUSI_THERMAL_FLAG_SUPPORT_SHUTDOWN) != 0)
	{
		printf("%u) Shutdown\n", i);
		indexConv[i] = SUSI_THERMAL_EVENT_SHUTDOWN;
		i++;
	}

	if ((info[iTmlProt].supportFlags & SUSI_THERMAL_FLAG_SUPPORT_THROTTLE) != 0)
	{
		printf("%u) Throttle\n", i);
		indexConv[i] = SUSI_THERMAL_EVENT_THROTTLE;
		i++;
	}

	if ((info[iTmlProt].supportFlags & SUSI_THERMAL_FLAG_SUPPORT_POWEROFF) != 0)
	{
		printf("%u) Power OFF\n", i);
		indexConv[i] = SUSI_THERMAL_EVENT_POWEROFF;
		i++;
	}

	tmp_u32 = 0;
	do {
		printf("\nEnter your choice: ");
		fflush(stdout);
	} while (input_uint(&tmp_u32, 10, i - 1, 0) != 0);
	
	*peventType = indexConv[tmp_u32];

	return 0;
}

static uint8_t input_trigger(uint8_t iTmlProt, uint32_t *psendEventTemp)
{
	int32_t result;
	uint32_t maxTemp, minTemp, tempVal;

	maxTemp = SUSI_DECODE_CELCIUS(info[iTmlProt].triggerMaximum);
	minTemp = SUSI_DECODE_CELCIUS(info[iTmlProt].triggerMinimum);

	do {
		printf("\nTrigger Temperature (%u to %u): ", minTemp, maxTemp);
		result = SCANF_IN("%u", &tempVal);
		wait_enter();
	} while (result <= 0 || tempVal > maxTemp || tempVal < minTemp);

	*psendEventTemp = (uint32_t)SUSI_ENCODE_CELCIUS(tempVal);

	return 0;
}

static uint8_t input_clear(uint8_t iTmlProt, uint32_t *pclearEventTemp)
{
	int32_t result;
	uint32_t maxTemp, minTemp, tempVal;

	maxTemp = SUSI_DECODE_CELCIUS(info[iTmlProt].clearMaximum);
	minTemp = SUSI_DECODE_CELCIUS(info[iTmlProt].clearMinimum);

	do {
		printf("\nClear Temperature (%u to %u): ", minTemp, maxTemp);
		result = SCANF_IN("%u", &tempVal);
		wait_enter();
	} while (result <= 0 || tempVal > maxTemp || tempVal < minTemp);

	*pclearEventTemp = (uint32_t)SUSI_ENCODE_CELCIUS(tempVal);

	return 0;
}

static uint8_t get_config(uint32_t tmlprot_id, PSusiThermalProtect pconfig)
{
	uint32_t status;

	status = SusiThermalProtectionGetConfig(tmlprot_id, pconfig);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiThermalProtectionGetConfig() failed. (0x%08X)\n", status);
		return 1;
	}

	return 0;
}

static uint8_t sfan_set_config(uint32_t tmlprot_id, SusiThermalProtect config)
{
	uint32_t status;

	status = SusiThermalProtectionSetConfig(tmlprot_id, &config);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiThermalProtectionSetConfig() failed. (0x%08X)\n", status);
		return 1;
	}

	return 0;
}

static uint8_t show_menu(uint8_t iTmlProt, SusiThermalProtect getConf, SusiThermalProtect setConf)
{
	uint8_t i;

	printf("0) Back to Main menu\n");
	printf("1) Select thermal protection zone\n");
	func[0] = funcTmlProt;

	if ((getConf.SourceId & 0x000FF000) == SUSI_ID_HWM_TEMP_BASE && getConf.SourceId < SUSI_ID_HWM_TEMP_BASE + SUSI_ID_HWM_TEMP_MAX)
		printf("2) Thermal Source    : Temperature %s", tempStr[getConf.SourceId - SUSI_ID_HWM_TEMP_BASE]);
	else
		printf("2) Thermal Source    : N/A");

	if (setConf.SourceId != getConf.SourceId)
	{
		if ((setConf.SourceId & 0x000FF000) == SUSI_ID_HWM_TEMP_BASE && setConf.SourceId < SUSI_ID_HWM_TEMP_BASE + SUSI_ID_HWM_TEMP_MAX)
			printf(" -> %s", tempStr[setConf.SourceId - SUSI_ID_HWM_TEMP_BASE]);
		else
			setConf.SourceId = getConf.SourceId;
	}
	printf("\n");		
	func[1] = funcSource;

	printf("3) Event Type        : ");
	if (getConf.EventType == SUSI_THERMAL_EVENT_NONE)
		printf("[None]");
	else
		printf(" None ");

	if ((info[iTmlProt].supportFlags & SUSI_THERMAL_FLAG_SUPPORT_SHUTDOWN) != 0)
	{
		if (getConf.EventType == SUSI_THERMAL_EVENT_SHUTDOWN)
			printf("/[Shutdown]");
		else
			printf("/ Shutdown ");
	}
	if ((info[iTmlProt].supportFlags & SUSI_THERMAL_FLAG_SUPPORT_THROTTLE) != 0)
	{
		if (getConf.EventType == SUSI_THERMAL_EVENT_THROTTLE)
			printf("/[Throttle]");
		else
			printf("/ Throttle ");
	}
	if ((info[iTmlProt].supportFlags & SUSI_THERMAL_FLAG_SUPPORT_POWEROFF) != 0)
	{
		if (getConf.EventType == SUSI_THERMAL_EVENT_POWEROFF)
			printf("/[Power OFF]");
		else
			printf("/ Power OFF ");
	}

	if (setConf.EventType != getConf.EventType)
	{
		if (setConf.EventType == SUSI_THERMAL_EVENT_NONE)
			printf(" -> None");
		else if (setConf.EventType == SUSI_THERMAL_EVENT_SHUTDOWN)
			printf(" -> Shutdown");
		else if (setConf.EventType == SUSI_THERMAL_EVENT_THROTTLE)
			printf(" -> Throttle");
		else if (setConf.EventType == SUSI_THERMAL_EVENT_POWEROFF)
			printf(" -> Power OFF");
	}
	printf("\n");
	func[2] = funcType;

	i = 3;
	if (setConf.EventType != SUSI_THERMAL_EVENT_NONE)
	{
		printf("%u) Trigger Temperature: %u", i + 1, SUSI_DECODE_CELCIUS(getConf.SendEventTemperature));
		setConf.SendEventTemperature != getConf.SendEventTemperature ?
			printf(" -> %u Celsius\n", SUSI_DECODE_CELCIUS(setConf.SendEventTemperature)) : printf(" Celsius\n");
		func[i] = funcTrigger;
		i++;

		printf("%u) Clear Temperature : %u", i + 1, SUSI_DECODE_CELCIUS(getConf.ClearEventTemperature));
		setConf.ClearEventTemperature != getConf.ClearEventTemperature ?
			printf(" -> %u Celsius\n", SUSI_DECODE_CELCIUS(setConf.ClearEventTemperature)) : printf(" Celsius\n");
		func[i] = funcClear;
		i++;
	}

	printf("%u) Get/Refresh all values\n", i + 1);
	func[i] = funcGet;
	i++;

	if ((setConf.SourceId & 0x000FF000) == SUSI_ID_HWM_TEMP_BASE && setConf.SourceId < SUSI_ID_HWM_TEMP_BASE + SUSI_ID_HWM_TEMP_MAX)
	{
		printf("%u) Save and apply setting\n", i + 1);
		func[i] = funcSet;
		i++;
	}

	printf("\nSelect the item you want to set: ");
	fflush(stdout);

	while (i < SUSIDEMO_THERMAL_FUNCTION_MAX)
	{
		func[i] = -1;
		i++;
	}

	return 0;
}

void thmprot_main(void)
{
	int32_t op;
	uint32_t tmlprot_id;
	uint8_t iTmlProt, result;
	SusiThermalProtect setConf;

	iTmlProt = tmlprot[0];
	tmlprot_id = iTmlProt;
	setConf = info[iTmlProt].config;
	
	for (;;)
	{
		clr_screen();
		if (title(iTmlProt) != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
			break;
		}

		if (get_config(tmlprot_id, &info[iTmlProt].config) != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
			return;
		}

		if (show_menu(iTmlProt, info[iTmlProt].config, setConf) != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
			break;
		}

		if (SCANF_IN("%d", &op) <= 0)
			op = -1;

		wait_enter();

		if (op == 0)
		{
			clr_screen();
			break;
		}

		if (op < 1 || op > SUSIDEMO_THERMAL_FUNCTION_MAX)
		{
			printf("Unknown choice!\n");
			printf("\nPress ENTER to continue. ");
			wait_enter();
			continue;
		}

		switch (func[op - 1])
		{
		case funcTmlProt:
			result = select_tmlprot(&iTmlProt);
			tmlprot_id = iTmlProt;
			setConf = info[iTmlProt].config;
			break;

		case funcSource:
			result = select_source(iTmlProt, &setConf.SourceId);
			break;

		case funcType:
			result = select_event_type(iTmlProt, &setConf.EventType);
			break;

		case funcTrigger:
			result = input_trigger(iTmlProt, &setConf.SendEventTemperature);
			break;

		case funcClear:
			result = input_clear(iTmlProt, &setConf.ClearEventTemperature);
			break;

		case funcGet:
			continue;

		case funcSet:
			result = sfan_set_config(tmlprot_id, setConf);
			break;

		default:
			result = 1;
			printf("Unknown choice!\n");
			break;
		}

		if (result != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
		}
	}

	clr_screen();
}
