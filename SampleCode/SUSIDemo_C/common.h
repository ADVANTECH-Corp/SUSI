#ifndef _SUSI_COMMON_H_
#define _SUSI_COMMON_H_

/* SUSI include */
#include "OsDeclarations.h"
#include "Susi4.h"

/* OS */
#include "os_windows.h"
#include "os_wince.h"
#include "os_linux.h"
#include "os_vxworks.h"
#include "os_qnx.h"

/* Public */
#define STRING_MAXIMUM_LENGTH		64
#define NAME_MAXIMUM_LENGTH			32

#define SUSIDEMO_FUNCTIONS_GOBACK		(-1)
#define SUSIDEMO_FUNCTIONS_UNDEFINED	(-2)
#define SUSIDEMO_DEVICEID_UNDEFINED		((SusiId_t)0xFFFFFFFF)
#define SUSIDEMO_ITEM_UNDEFINED			(-1)

#define SUSIDEMO_PRINT_NONE		0
#define SUSIDEMO_PRINT_SUCCESS	1
#define SUSIDEMO_PRINT_ERROR	2

#define SUSIDEMO_DEVICE_AVAILALBE	1
#define SUSIDEMO_DEVICE_UNAVAILALBE	0

#define NELEMS(_array)	(uint32_t)(sizeof(_array) / sizeof(_array[0]))

uint8_t wdog_init(void);
uint8_t hwm_init(void);
uint8_t sfan_init(void);
uint8_t gpio_init(void);
uint8_t vga_init(void);
uint8_t smb_init(void);
uint8_t iic_init(void);
uint8_t storage_init(void);
uint8_t thmprot_init(void);
uint8_t info_init(void);

void wdog_main(void);
void hwm_main(void);
void sfan_main(void);
void gpio_main(void);
void vga_main(void);
void smb_main(void);
void iic_main(void);
void storage_main(void);
void thmprot_main(void);
void info_main(void);

void get_susi4_id_name(SusiId_t mapped_id, char *pname);
int input_uint(uint32_t *psetVal, uint8_t base, uint32_t maxVal, uint32_t minVal);
int input_byte_sequence(uint8_t *pbuffer, uint32_t length, uint8_t base, uint8_t maxVal, uint8_t minVal);
int wait_enter(void);
int clr_screen(void);

#endif /*_SUSI_COMMON_H_*/
