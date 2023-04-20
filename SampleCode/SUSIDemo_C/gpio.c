#include "common.h"

#ifdef _RISC
#define SUSIDEMO_BANK_MAX 40
#else
#define SUSIDEMO_BANK_MAX 4
#endif

typedef struct
{
	uint8_t supPinNum;	/* 0 ~ 31 */
	uint32_t supInput;
	uint32_t supOutput;
	uint32_t supIRQ;
} GPIOInfo, *PGPIOInfo;
static GPIOInfo info[SUSIDEMO_BANK_MAX];

typedef struct {
	uint32_t idType;
	uint32_t directionVal;
	uint32_t levelVal;
	uint32_t pinVal;
	uint32_t edgeVal;
} GPIOConfig, *PGPIOConfig;

static char GPIOName[NAME_MAXIMUM_LENGTH];

#define SUSIDEMO_GPIO_ID_TYPE_MAX 2
enum idtypeRank{
	idtypeSingle,
	idtypeMulti
};

#define SUSIDEMO_GPIO_FUNCTION_MAX 9
static int8_t func[SUSIDEMO_GPIO_FUNCTION_MAX];
enum funcRank{
	funcPin,
	funcIdType,
	funcDirection,
	funcLevel,	
	funcIrqPin,
	funcIrqEdge,
	funcIrqTest,
	funcGet,
};

uint8_t gpio_init(void)
{
	uint32_t status, supportPin, id;
	uint8_t index, i, j;

	index = 0;
	for (i = 0; i < SUSIDEMO_BANK_MAX; i++)
	{
		id = SUSI_ID_GPIO_BANK(i);

		status = SusiGPIOGetCaps(id, SUSI_ID_GPIO_INPUT_SUPPORT, &info[i].supInput);
		if (status != SUSI_STATUS_SUCCESS)
			continue;

		status = SusiGPIOGetCaps(id, SUSI_ID_GPIO_OUTPUT_SUPPORT, &info[i].supOutput);
		if (status != SUSI_STATUS_SUCCESS)
			continue;

		status = SusiGPIOGetCaps(id, SUSI_ID_GPIO_INTERRUPT_SUPPORT, &info[i].supIRQ);

		supportPin = info[i].supInput | info[i].supOutput;

		if (supportPin > 0)
		{
			for (j = 32; (supportPin & (1 << (j - 1))) == 0; j--);
			info[i].supPinNum = j;
		}
		else
		{
			info[i].supPinNum = 0;
		}

		index++;
	}

	if (index == 0)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	func[funcPin] = funcPin;
	func[funcIdType] = funcIdType;
	func[funcDirection] = funcDirection;
	func[funcLevel] = funcLevel;
	func[funcIrqPin] = funcIrqPin;
	func[funcIrqEdge] = funcIrqEdge;
	func[funcIrqTest] = funcIrqTest;
	func[funcGet] = funcGet;	

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static uint8_t gpio_get_name(SusiId_t based_id, char *pName)
{
	uint32_t length = NAME_MAXIMUM_LENGTH, tmpLength = length;	/* include '\0': strlen + 1 */
	SusiId_t mapped_id = SUSI_ID_MAPPING_GET_NAME_GPIO(based_id);
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

static void show_information(uint8_t iPin, uint32_t idTypeVal)
{
	uint8_t iBank;

	iBank = iPin >> 5;

	if (idTypeVal == idtypeSingle)
	{
		printf("support input : %d\n", (info[iBank].supInput >> (iPin & 0x1F)) & 0x1);
		printf("support output: %d\n", (info[iBank].supOutput >> (iPin & 0x1F)) & 0x1);
		if (info[iBank].supIRQ) printf("support interrupt: %d\n", (info[iBank].supIRQ >> (iPin & 0x1F)) & 0x1);
	}
	else
	{
		printf("support input(s) : ");
		if (info[iBank].supPinNum > 24)
			printf("0x%02X ", (info[iBank].supInput & 0xFF000000) >> 24);
		if (info[iBank].supPinNum > 16)
			printf("0x%02X ", (info[iBank].supInput & 0x00FF0000) >> 16);
		if (info[iBank].supPinNum > 8)
			printf("0x%02X ", (info[iBank].supInput & 0x0000FF00) >> 8);
		if (info[iBank].supPinNum > 0)
			printf("0x%02X ", (info[iBank].supInput & 0x000000FF) >> 0);
		printf("\n");

		printf("support output(s): ");
		if (info[iBank].supPinNum > 24)
			printf("0x%02X ", (info[iBank].supOutput & 0xFF000000) >> 24);
		if (info[iBank].supPinNum > 16)
			printf("0x%02X ", (info[iBank].supOutput & 0x00FF0000) >> 16);
		if (info[iBank].supPinNum > 8)
			printf("0x%02X ", (info[iBank].supOutput & 0x0000FF00) >> 8);
		if (info[iBank].supPinNum > 0)
			printf("0x%02X ", (info[iBank].supOutput & 0x000000FF) >> 0);
		printf("\n");

		if (info[iBank].supIRQ)
		{
			printf("support interrupt(s): ");
			if (info[iBank].supPinNum > 24)
				printf("0x%02X ", (info[iBank].supIRQ & 0xFF000000) >> 24);
			if (info[iBank].supPinNum > 16)
				printf("0x%02X ", (info[iBank].supIRQ & 0x00FF0000) >> 16);
			if (info[iBank].supPinNum > 8)
				printf("0x%02X ", (info[iBank].supIRQ & 0x0000FF00) >> 8);
			if (info[iBank].supPinNum > 0)
				printf("0x%02X ", (info[iBank].supIRQ & 0x000000FF) >> 0);
			printf("\n");
		}
	}
}

static uint8_t title(uint8_t iPin, uint32_t idTypeVal)
{
	printf("**********************************************\n");
	printf("**               SUSI4.0 demo               **\n");
	printf("**********************************************\n");

	if (idTypeVal == idtypeSingle)
	{
		printf("\nGPIO: Pin %u", iPin);
		if (GPIOName[0] != '\0')
			printf(" (%s)", GPIOName);
		printf("\n");
	}
	else
	{
		printf("\nGPIO: Bank %u\n", iPin >> 5);
	}
		
	show_information(iPin, idTypeVal);
	printf("\n");

	return 0;
}

static uint8_t select_pin(uint8_t *piPin, uint32_t idTypeVal)
{
	uint32_t tmp_u32;
	uint8_t bank[SUSIDEMO_BANK_MAX], iBank, maxChoice;

	if (idTypeVal == idtypeSingle)
	{
		iBank = SUSIDEMO_BANK_MAX - 1;
		while (info[iBank].supPinNum == 0)
		{
			if (iBank == 0)
			{
				printf("Found no GPIO.\n");
				return 1;
			}

			iBank--;
		}

		maxChoice = iBank * 32 + (info[iBank].supPinNum - 1);

		tmp_u32 = 0;
		do {
			printf("\nPin Number (0 ~ %u): ", maxChoice);
		} while (input_uint(&tmp_u32, 10, maxChoice, 0) != 0);

		*piPin = tmp_u32 & 0xFF;
	}
	else
	{
		maxChoice = 0;
		for (iBank = 0; iBank < SUSIDEMO_BANK_MAX; iBank++)
		{
			if (info[iBank].supPinNum > 0)
			{
				bank[maxChoice] = iBank;
				printf("%u) Bank %u\n", maxChoice, iBank);
				maxChoice++;
			}
		}

		if (maxChoice == 0)
		{
			printf("Found no GPIO.\n");
			return 1;
		}
		
		if (maxChoice == 1)
		{
			iBank--;
			printf("Only Bank %u is available.\n", bank[0]);
			printf("\nPress ENTER to continue. ");
			wait_enter();
			return 0;
		}

		maxChoice--;

		tmp_u32 = 0;
		do {
			printf("\nBank (0 ~ %u): ", maxChoice);
		} while (input_uint(&tmp_u32, 10, maxChoice, 0) != 0);

		iBank = bank[tmp_u32];

		*piPin = iBank << 5;
	}

	return 0;
}

static uint8_t change_id_type(uint32_t *pvalue)
{
	if (*pvalue == idtypeSingle)
		*pvalue = idtypeMulti;
	else
		*pvalue = idtypeSingle;

	return 0;
}

static uint8_t get_direction(uint8_t iPin, uint32_t idTypeVal, uint32_t *pvalue)
{
	uint32_t status, id, mask;
	uint8_t iBank;

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supInput | info[iBank].supOutput;
	}

	status = SusiGPIOGetDirection(id, mask, pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOGetDirection() failed. (0x%08X)\n", status);
		return 1;
	}

	return 0;
}

static uint8_t set_direction(uint8_t iPin, uint32_t idTypeVal)
{
	uint32_t status, id, mask, setVal;
	uint8_t iBank;

	show_information(iPin, idTypeVal);

	printf("\nSet Direction:\n\n");

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;

		do
		{
			printf("\nSet Value (0 or 1): ");
		} while (input_uint(&setVal, 10, 1, 0) != 0);
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supInput | info[iBank].supOutput;

		if (info[iBank].supPinNum == 32)
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", 0xFFFFFFFF);
			} while (input_uint(&setVal, 16, 0xFFFFFFFF, 0) != 0);
		}
		else
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", (1 << info[iBank].supPinNum) - 1);
			} while (input_uint(&setVal, 16, (1 << info[iBank].supPinNum) - 1, 0) != 0);
		}		
	}

	status = SusiGPIOSetDirection(id, mask, setVal);

	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOSetDirection() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("SusiGPIOSetDirection() succeed.\n");
	return 0;
}

static uint8_t get_level(uint8_t iPin, uint32_t idTypeVal, uint32_t *pvalue)
{
	uint32_t status, id, mask;
	uint8_t iBank;

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supInput | info[iBank].supOutput;
	}

	status = SusiGPIOGetLevel(id, mask, pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOGetLevel() failed. (0x%08X)\n", status);
		return 1;
	}

	return 0;
}

static uint8_t get_pin(uint8_t iPin, uint32_t idTypeVal, uint32_t *pvalue)
{
	uint32_t status, id, mask ;
	uint8_t iBank;

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supIRQ ;
	}

	status = SusiGPIOIntGetPin(id, mask, pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOIntGetPin() failed. (0x%08X)\n", status); 
		return 1;
	}

	return 0;
}

static uint8_t get_edge(uint8_t iPin, uint32_t idTypeVal, uint32_t *pvalue)
{
	uint32_t status, id, mask ;
	uint8_t iBank;

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supIRQ;
	}

	status = SusiGPIOIntGetEdge(id, mask, pvalue);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("get_edge() failed. (0x%08X)\n", status);
		return 1;
	}

	return 0;
}

static uint8_t set_level(uint8_t iPin, uint32_t idTypeVal)
{
	uint32_t status, id, mask, setVal;
	uint8_t iBank;

	show_information(iPin, idTypeVal);

	printf("\nSet Level:\n\n");

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;

		do
		{
			printf("\nSet Value (0 or 1): ");
		} while (input_uint(&setVal, 10, 1, 0) != 0);
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supInput | info[iBank].supOutput;

		if (info[iBank].supPinNum == 32)
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", 0xFFFFFFFF);
			} while (input_uint(&setVal, 16, 0xFFFFFFFF, 0) != 0);
		}
		else
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", (1 << info[iBank].supPinNum) - 1);
			} while (input_uint(&setVal, 16, (1 << info[iBank].supPinNum) - 1, 0) != 0);
		}		
	}

	status = SusiGPIOSetLevel(id, mask, setVal);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOSetLevel() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("SusiGPIOSetLevel() succeed.\n");
	return 0;
}

static uint8_t set_irq_pin(uint8_t iPin, uint32_t idTypeVal)
{
	uint32_t status, id, mask, setVal;
	uint8_t iBank;

	show_information(iPin, idTypeVal);

	printf("\nSet Trigger Pin:\n\n");

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;

		do
		{
			printf("\nSet Value (0 or 1): ");
		} while (input_uint(&setVal, 10, 1, 0) != 0);
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supIRQ;

		if (info[iBank].supPinNum == 32)
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", 0xFFFFFFFF);
			} while (input_uint(&setVal, 16, 0xFFFFFFFF, 0) != 0);
		}
		else
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", (1 << info[iBank].supPinNum) - 1);
			} while (input_uint(&setVal, 16, (1 << info[iBank].supPinNum) - 1, 0) != 0);
		}
	}

	status = SusiGPIOIntSetPin(id, mask, setVal);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOIntSetPin() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("SusiGPIOIntSetPin() succeed.\n");
	return 0;
}

static uint8_t set_irq_edge(uint8_t iPin, uint32_t idTypeVal)
{
	uint32_t status, id, mask, setVal;
	uint8_t iBank;

	show_information(iPin, idTypeVal);

	printf("\nSet Trigger Edge:\n\n");

	if (idTypeVal == idtypeSingle)
	{
		id = SUSI_ID_GPIO(iPin);
		mask = 1;

		do
		{
			printf("\nSet Value (0 or 1): ");
		} while (input_uint(&setVal, 10, 1, 0) != 0);
	}
	else
	{
		iBank = iPin >> 5;
		id = SUSI_ID_GPIO_BANK(iBank);
		mask = info[iBank].supIRQ;

		if (info[iBank].supPinNum == 32)
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", 0xFFFFFFFF);
			} while (input_uint(&setVal, 16, 0xFFFFFFFF, 0) != 0);
		}
		else
		{
			do
			{
				printf("\nSet Value (0x0 to 0x%X): 0x", (1 << info[iBank].supPinNum) - 1);
			} while (input_uint(&setVal, 16, (1 << info[iBank].supPinNum) - 1, 0) != 0);
		}
	}

	status = SusiGPIOIntSetEdge(id, mask, setVal);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiGPIOIntSetPin() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("SusiGPIOIntSetPin() succeed.\n");
	return 0;
}

static uint8_t set_irq_stop()
{
	SusiStatus_t status = SusiGPIOIntUnRegister();

	if (status == SUSI_STATUS_SUCCESS)
		printf("\nSusiGPIOIntUnRegister() succeed.\n");
	else {
		printf("\nSusiGPIOIntUnRegister() fail : %08X.\n", status);

		printf("\nPress ENTER to continue. ");
		wait_enter();
	}

	return status;
}

static void SUSI_API gpio_callback_print(void* context)
{
	printf("\n=== Get GPIO[%ld] IRQ Event ===\n", (long) context);
}

static uint8_t set_irq_start()
{
	SusiStatus_t status = SusiGPIOIntRegister(gpio_callback_print);

	if (status == SUSI_STATUS_SUCCESS) 
		printf("\nWaiting trigger. \n\nPress ENTER to stop testing. \n");
	else 
		printf("\nSusiGpioIntRegister() fail : %08X.\n", status);

	wait_enter();
	set_irq_stop();

	return status;
}

static uint8_t show_menu(uint8_t iPin, GPIOConfig config)
{
	uint8_t iBank;

	printf("0) Back to Main menu\n");

	switch (config.idType)
	{
	case idtypeSingle:
		printf("1) Select GPIO pin\n");
		printf("2) Type     \t: [Single Pin]/ Multi-Pin\n");
		printf("3) Direction\t: %X\n", config.directionVal);
		printf("4) Level    \t: %X\n", config.levelVal);
		if (info[0].supIRQ) printf("5) Trigger Pin\t: %X\n", config.pinVal);
		if (info[0].supIRQ) printf("6) Trigger Level: %X\n", config.edgeVal);

		break;

	case idtypeMulti:
		printf("1) Select bank\n");

		iBank = iPin >> 5;
		printf("2) Type     \t:  Single Pin /[Multi-Pin]\n");

		printf("3) Direction\t: ");
		if (info[iBank].supPinNum > 24)
			printf("0x%02X ", (config.directionVal & 0xFF000000) >> 24);
		if (info[iBank].supPinNum > 16)
			printf("0x%02X ", (config.directionVal & 0x00FF0000) >> 16);
		if (info[iBank].supPinNum > 8)
			printf("0x%02X ", (config.directionVal & 0x0000FF00) >> 8);
		if (info[iBank].supPinNum > 0)
			printf("0x%02X ", (config.directionVal & 0x000000FF) >> 0);
		printf("\n");

		printf("4) Level    \t: ");
		if (info[iBank].supPinNum > 24)
			printf("0x%02X ", (config.levelVal & 0xFF000000) >> 24);
		if (info[iBank].supPinNum > 16)
			printf("0x%02X ", (config.levelVal & 0x00FF0000) >> 16);
		if (info[iBank].supPinNum > 8)
			printf("0x%02X ", (config.levelVal & 0x0000FF00) >> 8);
		if (info[iBank].supPinNum > 0)
			printf("0x%02X ", (config.levelVal & 0x000000FF) >> 0);
		printf("\n");		

		if (info[0].supIRQ)
		{
			printf("5) Trigger Pin\t: ");
			if (info[iBank].supPinNum > 8)
				printf("0x%02X ", (config.pinVal & 0x0000FF00) >> 8);
			if (info[iBank].supPinNum > 0)
				printf("0x%02X ", (config.pinVal & 0x000000FF) >> 0);
			printf("\n");

			printf("6) Trigger Level: ");
			if (info[iBank].supPinNum > 8)
				printf("0x%02X ", (config.edgeVal & 0x0000FF00) >> 8);
			if (info[iBank].supPinNum > 0)
				printf("0x%02X ", (config.edgeVal & 0x000000FF) >> 0);
			printf("\n");
		}

		break;

	default:
		printf("No such ID type\n");
		return 1;
	}
	
	if (info[0].supIRQ)
	{
		printf("7) Trigger Testing\n");
		printf("8) Get/Refresh all values\n");
	} else
	printf("5) Get/Refresh all values\n");
	printf("\nSelect the item you want to set: ");
	fflush(stdout);

	return 0;
}

void gpio_main(void)
{
	int32_t op;
	uint8_t iBank, iPin = 0, result ; 
	GPIOConfig config;

	for (iBank = 0; iBank < SUSIDEMO_BANK_MAX; iBank++)
	{
		uint32_t supportPin = info[iBank].supInput | info[iBank].supOutput;
		if (supportPin > 0)
		{
			for (iPin = 0; (supportPin & (1 << iPin)) == 0; iPin++);
			iPin += iBank * 32;		// Get the first pin, 32 pins per bank
			break;
		}
	}

	gpio_get_name((SusiId_t)iPin, GPIOName);

	config.idType = idtypeSingle;

	for (;;)
	{
		uint8_t bIRQ = info[iBank].supIRQ;
		clr_screen();
		if (title(iPin, config.idType) != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
			break;
		}

		if (  (get_direction(iPin, config.idType, &config.directionVal) != 0)
		   || (get_level    (iPin, config.idType, &config.levelVal)     != 0) )
		{			
			printf("\nPress ENTER to continue. ");
			wait_enter();
			break;
		}

		if (bIRQ)
		   if (  (get_pin      (iPin, config.idType, &config.pinVal)       != 0)
		      || (get_edge     (iPin, config.idType, &config.edgeVal)      != 0) )
		{			
			   printf("\nPress ENTER to continue..");
			wait_enter();
			break;
		}

		while (show_menu(iPin, config) != 0)
		{
			printf("\nPress ENTER to continue. ... ");
			wait_enter();
			break;
		}

		if (SCANF_IN("%d", &op) <= 0)			
			op = -1;

		wait_enter();

		if (op == 0)
			break;

		if (bIRQ == 0)
		{
			if (op >= funcIrqEdge + 1)
				op = -1;

			if (op == funcIrqPin +1)
				op = funcGet + 1;
		}

		if (op < 1 || op > SUSIDEMO_GPIO_FUNCTION_MAX)
		{
			printf("Unknown choice!\n");
			printf("\nPress ENTER to continue. ");
			wait_enter();
			continue;
		}

		result = 1;
		switch (func[op - 1])
		{
		case funcPin:
			result = select_pin(&iPin, config.idType);
			if (config.idType == idtypeSingle)
				gpio_get_name((SusiId_t)iPin, GPIOName);
			break;

		case funcIdType:
			result = change_id_type(&config.idType);
			break;

		case funcDirection:
			result = set_direction(iPin, config.idType);
			break;

		case funcLevel:
			result = set_level(iPin, config.idType);
			break;
		
		case funcIrqPin:
			if (bIRQ)
				result = set_irq_pin(iPin, config.idType);
			else
				printf("Device doesn't support GPIO IRQ!\n");

			break;

		case funcIrqEdge:
			if (bIRQ)
				result = set_irq_edge(iPin, config.idType);
			else
				printf("Device doesn't support GPIO IRQ!\n");
			break;

		case funcIrqTest:
			if (bIRQ)
				result = set_irq_start();
			else
				printf("Device doesn't support GPIO IRQ!\n");
			break;

		case funcGet:
			continue;

		default:
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
