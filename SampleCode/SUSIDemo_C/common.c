#include "common.h"

void get_susi4_id_name(SusiId_t mapped_id, char *pname)
{
	/* the length of *pname must be NAME_MAXIMUM_LENGTH */
	uint32_t len = NAME_MAXIMUM_LENGTH;

	switch (SusiBoardGetStringA(mapped_id, pname, &len))
	{
	case SUSI_STATUS_MORE_DATA:
		pname[len - 2] = '*';
		pname[len - 1] = '\0';
	case SUSI_STATUS_SUCCESS:
		break;

	default:
		STRING_CP(pname, "UnknownName");
	}
}

int wait_enter(void)
{
	int c, i = 0;

	fflush(stdout);
	while ((c = getchar()) != '\n' && c != EOF)
		i++;

	return i; /* number of characters thrown off */
}

int input_uint(uint32_t *psetVal, uint8_t base, uint32_t maxVal, uint32_t minVal)
{
	int pass;

	fflush(stdout);

	if (psetVal == NULL)
		return -1;

	switch (base)
	{
	case 8:
		pass = SCANF_IN("%o", psetVal);
		break;
	case 10:
		pass = SCANF_IN("%u", psetVal);
		break;	
	case 16:
		pass = SCANF_IN("%x", psetVal);
		break;
	default:
		return -1;
	}

	if (wait_enter())
		return -1;	/* one or more invalid characters */

	if (pass <= 0)
		return -1;	/* no valid character */

	if (*psetVal > maxVal || *psetVal < minVal)
		return -1;

	return 0;
}

int input_byte_sequence(uint8_t *pbuffer, uint32_t length, uint8_t base, uint8_t maxVal, uint8_t minVal)
{
	int pass = -1;
	uint32_t tmp_u32, i;

	fflush(stdout);

	if (pbuffer == NULL || length == 0)
		return -1;

	for (i = 0; i < length; i++)
	{
		switch (base)
		{
		case 8:
			pass = SCANF_IN("%o", &tmp_u32);
			break;
		case 10:
			pass = SCANF_IN("%u", &tmp_u32);
			break;	
		case 16:
			pass = SCANF_IN("%x", &tmp_u32);
			break;
		default:			
			return -1;
		}

		if (pass <= 0)
			break;

		if (tmp_u32 > maxVal || tmp_u32 < minVal)
		{
			wait_enter();
			return -1;
		}

		pbuffer[i] = (uint8_t)tmp_u32;
	}

	if (wait_enter())
		return -1;

	if (pass <= 0)
		return -1;

	return 0;
}

int clr_screen(void)
{
	return system(CLRSCR);
}
