#include "common.h"

typedef struct {
	uint32_t totalSize;
	uint32_t blockSize;
	uint32_t maxKeySize;
	uint32_t wpStatus;
} StorageInfo, *PStorageInfo;

static StorageInfo info[SUSI_ID_STORAGE_MAX];
static int8_t storage[SUSI_ID_STORAGE_MAX];

#define SUSIDEMO_STORAGE_FUNCTION_MAX 6
static int8_t func[SUSIDEMO_STORAGE_FUNCTION_MAX];
enum funcRank{
	funcDevice,
	funcRead,
	funcWrite,
	funcStatus,
	funcLock,
	funcUnlock
};

uint8_t storage_init(void)
{
	uint32_t status, id;
	uint8_t index, i;

	index = 0;
	for (i = 0; i < SUSI_ID_STORAGE_MAX; i++)
	{
		id = i;
		status = SusiStorageGetCaps(id, SUSI_ID_STORAGE_TOTAL_SIZE, &info[index].totalSize);
		if (status != SUSI_STATUS_SUCCESS)
			continue;

		status = SusiStorageGetCaps(id, SUSI_ID_STORAGE_BLOCK_SIZE, &info[index].blockSize);
		if (status != SUSI_STATUS_SUCCESS)
			info[index].blockSize = 0;

		status = SusiStorageGetCaps(id, SUSI_ID_STORAGE_PSW_MAX_LEN, &info[index].maxKeySize);
		if (status != SUSI_STATUS_SUCCESS)
			info[index].maxKeySize = 0;

		storage[index] = i;
		index++;
	}

	if (index == 0)
		return SUSIDEMO_DEVICE_UNAVAILALBE;

	for (i = index; i < SUSI_ID_STORAGE_MAX; i++)
		storage[i] = -1;

	return SUSIDEMO_DEVICE_AVAILALBE;
}

static uint8_t title(uint8_t iStorage)
{
	printf("**********************************************\n");
	printf("**               SUSI4.0 demo               **\n");
	printf("**********************************************\n");

	if (iStorage >= SUSI_ID_STORAGE_MAX)
	{
		printf("ERROR: The storage device is not exist.\n");
		return 1;
	}

	printf("\nStorage %u\n\n", iStorage + 1);

	return 0;
}

static uint8_t select_storage(uint8_t *piStorage)
{
	uint32_t tmp_u32;
	uint8_t i;

	printf("\nStorage Device:\n");
	for (i = 0; i < SUSI_ID_STORAGE_MAX && storage[i] > -1; i++)
	{
		if (storage[i] == *piStorage)
			printf("%u) [Storage %d]\n", i, storage[i]);
		else
			printf("%u) Storage %d\n", i, storage[i]);
	}

	if (i == 1)
	{
		*piStorage = storage[0];
		printf("Only Storage %u is available.\n", *piStorage);
		printf("\nPress ENTER to continue. ");
		wait_enter();
		return 0;
	}

	tmp_u32 = 0;
	do {		
		printf("\nEnter your choice (0 to %u): ", i - 1);
		fflush(stdout);
	} while (input_uint(&tmp_u32, 10, i - 1, 0) != 0);

	*piStorage = storage[tmp_u32];

	return 0;
}

static uint8_t read_data(uint32_t storage_id, uint32_t totalSize)
{
	uint32_t status, offset, length, maxLength;
	uint8_t *pdataBuffer, i;

	printf("\nRead:\n");

#ifdef _RISC
	offset = 0;
	maxLength = 128;
	length = maxLength;
#else
	offset = 0;
	do {
		printf("\nOffset (0x00 to 0x%02X): 0x", totalSize - 1);
		fflush(stdout);
	} while (input_uint(&offset, 16, totalSize - 1, 0) != 0);

	maxLength = totalSize - offset;
	length = 0;
	do {
		printf("\nLength (1 to %u): ", maxLength);
		fflush(stdout);
	} while (input_uint(&length, 10, maxLength, 1) != 0);
#endif

	pdataBuffer = (uint8_t*)malloc(length * sizeof(uint8_t));
	status = SusiStorageAreaRead(storage_id, offset, pdataBuffer, length);
	if (status != SUSI_STATUS_SUCCESS)
	{
		free(pdataBuffer);
		printf("SusiStorageAreaRead() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("Result: (HEX)\n");
	for (i = 0; i < length; i++)
	{
		if (i == length - 1)
			printf("%02X\n", pdataBuffer[i]);
		else
			printf("%02X ", pdataBuffer[i]);
	}

	free(pdataBuffer);
	return 0;
}

static uint8_t write_data(uint32_t storage_id, uint32_t totalSize, uint32_t blockSize)
{
#ifdef _RISC
	uint32_t status, offset, length;
	uint8_t *pdataBuffer;
	char* end;
	
	printf("\nWrite:\n");

	offset = 0;
	length = 128;

	pdataBuffer = (uint8_t*)malloc(length * sizeof(uint8_t));

	if ( fgets((char*)pdataBuffer, length, stdin ) == NULL )
	{
		printf("write_data: fgets error!\n");
		return 1;
	}
	
	end = strchr((char*)pdataBuffer, '\n');
	if (end != NULL) *end = '\0';
#else
	uint32_t status, offset, length;
	uint8_t *pdataBuffer, i;

	printf("\nWrite:\n");

	offset = 0;
	do {
		printf("\nOffset (0x00 to 0x%02X): 0x", totalSize - 1);
		fflush(stdout);
	} while (input_uint(&offset, 16, totalSize - 1, 0) != 0);

	if (blockSize > totalSize - offset)
		blockSize = totalSize - offset;

	length = 0;
	do {
		printf("\nLength (1 to %u): ", blockSize);
		fflush(stdout);
	} while (input_uint(&length, 10, blockSize, 1) != 0);

	pdataBuffer = (uint8_t*)malloc(length * sizeof(uint8_t));

	printf("\nInput %u-byte data (Hex):\n ", length);
	if (input_byte_sequence(pdataBuffer, length, 16, 0xFF, 0) != 0)
	{
		if (pdataBuffer > 0)
			free(pdataBuffer);

		printf("Input invalid value.\n");
		return 1;
	}

	printf("\nWrite Data (Hex):\n");
	for (i = 0; i < length; i++)
		printf(" %02X", pdataBuffer[i]);
	printf("\n\n");
#endif

	status = SusiStorageAreaWrite(storage_id, offset, pdataBuffer, length);
	free(pdataBuffer);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiStorageAreaWrite() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("SusiStorageAreaWrite() succeed.\n");

	return 0;
}

static uint8_t get_status(uint32_t storage_id, uint32_t *pwtprot_status)
{
	uint32_t status, value;

	status = SusiStorageGetCaps(storage_id, SUSI_ID_STORAGE_LOCK_STATUS, &value);

	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiStorageGetCaps() failed. (0x%08X)\n", status);
		return 1;
	}

	if (value != SUSI_STORAGE_STATUS_LOCK && value != SUSI_STORAGE_STATUS_UNLOCK)
	{
		printf("Unknow Status\n");
		return 1;
	}

	if (value == SUSI_STORAGE_STATUS_LOCK)
		printf("Status is \"Locked\".\n");
	else
		printf("Status is \"Unlocked\".\n");

	*pwtprot_status = value;

	return 0;
}

static uint8_t wtprot_lock(uint32_t storage_id, uint32_t maxLength)
{	
	SusiStatus_t status;
	uint32_t length;
	uint8_t passwd[STRING_MAXIMUM_LENGTH] = {0};

	printf("\nLock:\n\n");
	printf("Note: maximum length of password is %u-word\n", maxLength);
	printf("Type new password: ");

	if (SCANF2_IN("%s", passwd) <= 0)
	{
		wait_enter();
		printf("Error: input invalid value.\n");
		return 1;
	}
	wait_enter();

	length = (uint32_t)strlen((char *)passwd);

	if (length > maxLength)
	{
		printf("Error: too many words.\n");
		return 1;
	}

	status = SusiStorageAreaSetLock(storage_id, passwd, length);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiStorageAreaSetLock() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("New password: %s\n", passwd);

	return 0;
}

static uint8_t wtprot_unlock(uint32_t storage_id)
{
	SusiStatus_t status;
	uint32_t length;
	uint8_t passwd[STRING_MAXIMUM_LENGTH] = {0};

	printf("\nUnlock:\n\n");

	printf("Type password: ");

	if (SCANF2_IN("%s", passwd) <= 0)
	{
		wait_enter();
		printf("Error: input invalid value.\n");
		return 1;
	}
	wait_enter();

	length = (uint32_t)strlen((char *)passwd);
	status = SusiStorageAreaSetUnlock(storage_id, passwd, length);
	if (status != SUSI_STATUS_SUCCESS)
	{
		printf("SusiStorageAreaSetUnlock() failed. (0x%08X)\n", status);
		return 1;
	}

	printf("Cancel password succeed.\n");

	return 0;
}

static uint8_t show_menu(uint8_t iStorage, uint32_t wtprot_status)
{
	uint8_t i;

	printf("0) Back to Main menu\n");
	
	printf("1) Select storage device\n");
	func[0] = funcDevice;
	printf("2) Read data\n");
	func[1] = funcRead;
	printf("3) Write data\n");
	func[2] = funcWrite;

	i = 3;
	if (info[iStorage].maxKeySize > 0)
	{
		if (wtprot_status == SUSI_STORAGE_STATUS_LOCK)
		{
			printf("%u) Get/Refresh write protection status: Locked\n", i + 1);
			func[i] = funcStatus;
			i++;

			printf("%u) Write protection unlock\n", i + 1);
			func[i] = funcUnlock;
			i++;
		}
		else
		{
			printf("%u) Get/Refresh write protection status: Unlocked\n", i + 1);
			func[i] = funcStatus;
			i++;

			printf("%u) Write protection lock\n", i + 1);
			func[i] = funcLock;
			i++;
		}
	}

	while (i < SUSIDEMO_STORAGE_FUNCTION_MAX)
	{
		func[i] = -1;
		i++;
	}

	printf("\nSelect the item you want to do: ");
	fflush(stdout);

	return 0;
}

void storage_main(void)
{
	int32_t op;
	uint8_t iStorage, result;
	uint32_t storage_id;

	iStorage = storage[0];
	storage_id = iStorage;

	if (info[iStorage].maxKeySize > 0)
		get_status(storage_id, &info[iStorage].wpStatus);

	for (;;)
	{
		clr_screen();
		if (title(iStorage) != 0)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
			break;
		}

		if (show_menu(iStorage, info[iStorage].wpStatus) != 0)
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

		if (op < 1 || op > SUSIDEMO_STORAGE_FUNCTION_MAX)
		{
			printf("Unknown choice!\n");
			printf("\nPress ENTER to continue. ");
			wait_enter();
			continue;
		}

		switch (func[op - 1])
		{
		case funcDevice:
			result = select_storage(&iStorage);
			storage_id = iStorage;
			break;

		case funcRead:
			result = read_data(storage_id, info[iStorage].totalSize);
			break;

		case funcWrite:
			result = write_data(storage_id, info[iStorage].totalSize, info[iStorage].blockSize);
			break;

		case funcStatus:
			result = get_status(storage_id, &info[iStorage].wpStatus);
			break;

		case funcLock:
			result = wtprot_lock(storage_id, info[iStorage].maxKeySize);
			break;

		case funcUnlock:
			result = wtprot_unlock(storage_id);
			break;

		default:
			result = 1;
			printf("Unknown choice!\n");
			break;
		}

		if (result != 0 || func[op - 1] != funcDevice)
		{
			printf("\nPress ENTER to continue. ");
			wait_enter();
		}
	}

	clr_screen();
}
