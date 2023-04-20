/*******************************************************************************
* Advantech SUSI4 Driver License
* Copyright c 2018 Advantech Co., Ltd. All rights reserved.

* This Software can only be used on Advantech Products.
* You may use and distribute this Software under the terms of Advantech Software License Agreement.
* You should have received the license from Advantech. If not, please write to buy@advantech.com.
* Advantech has the right to review all the modifications of this Software.
* Redistribution and use in source forms, with or without modification, are permitted provided that the following conditions are met: 
* Redistributions of source code must retain the above copyright notice and the following disclaimer. 
*Advantech Co., Ltd. may not be used to endorse or promote products derived from this Software without specific prior written permission.

*THIS SOFTWARE IS PROVIDED ¡§AS IS¡¨, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR *OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THIS SOFTWARE OR THE USE OR OTHER *DEALINGS IN THIS SOFTWARE. 

*******************************************************************************/ 

#ifndef _SUSI4_H_
#define _SUSI4_H_

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once

#ifndef SUSI_API
	#define SUSI_API __stdcall
#endif
#else
	#define SUSI_API
#endif

#ifdef __cplusplus
extern "C" {
#endif

/*
 *  Susi Types
 */
typedef uint32_t SusiStatus_t;
typedef uint32_t SusiId_t;


/*-----------------------------------------------------------------------------
//
//	Status codes
//
//-----------------------------------------------------------------------------*/
/* Description
 *   The SUSI API library is not yet or unsuccessfully initialized. 
 *   SusiLibInitialize needs to be called prior to the first access of any 
 *   other SUSI API function.
 * Actions
 *   Call SusiLibInitialize..
 */
#define SUSI_STATUS_NOT_INITIALIZED				((SusiStatus_t)0xFFFFFFFF)

/* Description
 *   Library is initialized.
 * Actions
 *   none.
 */
#define SUSI_STATUS_INITIALIZED					((SusiStatus_t)0xFFFFFFFE)

/* Description
 *   Memory Allocation Error.
 * Actions
 *   Free memory and try again..
 */
#define SUSI_STATUS_ALLOC_ERROR					((SusiStatus_t)0xFFFFFFFD)

/* Description 
 *   Time out in driver. This is Normally caused by hardware/software 
 *   semaphore timeout. 
 * Actions
 *   Retry.
 */
#define SUSI_STATUS_DRIVER_TIMEOUT				((SusiStatus_t)0xFFFFFFFC)

/* Description 
 *  One or more of the SUSI API function call parameters are out of the 
 *  defined range.
 * Actions
 *   Verify Function Parameters.
 */
#define SUSI_STATUS_INVALID_PARAMETER			((SusiStatus_t)0xFFFFFEFF)

/* Description
 *   The Block Alignment is incorrect.
 * Actions
 *   Use Inputs and Outputs to correctly select input and outputs. 
 */
#define SUSI_STATUS_INVALID_BLOCK_ALIGNMENT		((SusiStatus_t)0xFFFFFEFE)

/* Description
 *   This means that the Block length is too long.
 * Actions
 *   Use Alignment Capabilities information to correctly align write access.
 */
#define SUSI_STATUS_INVALID_BLOCK_LENGTH		((SusiStatus_t)0xFFFFFEFD)

/* Description
 *   The current Direction Argument attempts to set GPIOs to a unsupported 
 *   directions. I.E. Setting GPI to Output.
 * Actions
 *   Use Inputs and Outputs to correctly select input and outputs. 
 */
#define SUSI_STATUS_INVALID_DIRECTION			((SusiStatus_t)0xFFFFFEFC)

/* Description
 *   The Bitmask Selects bits/GPIOs which are not supported for the current ID.
 * Actions
 *   Use Inputs and Outputs to probe supported bits..
 */
#define SUSI_STATUS_INVALID_BITMASK				((SusiStatus_t)0xFFFFFEFB)

/* Description
 *   Watchdog timer already started.
 * Actions
 *   Call SusiWDogStop, before retrying.
 */
#define SUSI_STATUS_RUNNING						((SusiStatus_t)0xFFFFFEFA)

/* Description
 *   This function or ID is not supported at the actual hardware environment.
 * Actions
 *   none.
 */
#define SUSI_STATUS_UNSUPPORTED					((SusiStatus_t)0xFFFFFCFF)

/* Description
 *   Selected device was not found
 * Actions
 *   none.
 */
#define SUSI_STATUS_NOT_FOUND					((SusiStatus_t)0xFFFFFBFF)

 /* Description
 *    Device has no response.
 * Actions
 *   none.
 */
#define SUSI_STATUS_TIMEOUT						((SusiStatus_t)0xFFFFFBFE)

 /* Description
 *    Device has no response.
 * Actions
 *   none.
 */
#define SUSI_STATUS_NORESPONSE					((SusiStatus_t)0xFFFFFBFD)

 /* Description
 *    Device has no ACK.
 * Actions
 *   none.
 */
#define SUSI_STATUS_NOACK						((SusiStatus_t)0xFFFFFBFA)

 /* Description
 *    Device lock fail.
 * Actions
 *   none.
 */
#define SUSI_STATUS_LOCKFAIL					((SusiStatus_t)0xFFFFFBFB)

 /* Description
 *    Device status not correct.
 * Actions
 *   none.
 */
#define SUSI_STATUS_DEVICE_ERROR				((SusiStatus_t)0xFFFFFBFC)


/* Description
 *   The selected device or ID is busy or a data collision was detected.
 * Actions
 *   Retry.
 */
#define SUSI_STATUS_BUSY_COLLISION				((SusiStatus_t)0xFFFFFBFD)

/* Description
 *   An error was detected during a read operation.
 * Actions
 *   Retry.
 */
#define SUSI_STATUS_READ_ERROR					((SusiStatus_t)0xFFFFFAFF)

 /* Description
 *   An error was detected during a write operation.
 * Actions
 *   Retry.
 */
#define SUSI_STATUS_WRITE_ERROR					((SusiStatus_t)0xFFFFFAFE)

 /* Description
 *   An error was detected during an access operation.
 * Actions
 *   Retry.
 */
#define SUSI_STATUS_ACCESS_ERROR					((SusiStatus_t)0xFFFFFAFD)


/* Description
 *   The amount of available data exceeds the buffer size. Storage buffer 
 *   overflow was prevented. Read count was larger than the defined buffer
 *   length.
 * Actions
 *   Either increase the buffer size or reduce the block length.
 */
#define SUSI_STATUS_MORE_DATA					((SusiStatus_t)0xFFFFF9FF)

/* Description
 *   Generic error message. No further error details are available.
 * Actions
 *   none.
 */
#define SUSI_STATUS_ERROR						((SusiStatus_t)0xFFFFF0FF)

/* Description
 *   The operation was successful.
 * Actions
 *   none.
 */
#define SUSI_STATUS_SUCCESS						((SusiStatus_t)0)


/*-----------------------------------------------------------------------------
//
//	APIs
//
//-----------------------------------------------------------------------------
//=============================================================================
// Library
//=============================================================================
// Should be called before calling any other API function is called.
//
// Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Already initialized				| SUSI_STATUS_INITIALIZED
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiLibInitialize(void);

/* Should be called before program exit 
//
// Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiLibUninitialize(void);

/*=============================================================================
// Board
//=============================================================================
// Board information values
*/
#define SUSI_ID_GET_INDEX(Id)					(Id & 0xFF)
#define SUSI_ID_GET_TYPE(Id)					(Id & 0x000FF000)

#define SUSI_ID_BOARD_INFO_BASE					((SusiId_t)0x00000000)
#define SUSI_ID_GET_SPEC_VERSION				((SusiId_t)0x00000000)
#define SUSI_ID_BOARD_BOOT_COUNTER_VAL			((SusiId_t)0x00000001)		/* Units: Boot count*/
#define SUSI_ID_BOARD_RUNNING_TIME_METER_VAL	((SusiId_t)0x00000002)		/* Units = Minutes*/
#define SUSI_ID_BOARD_PNPID_VAL					((SusiId_t)0x00000003)
#define SUSI_ID_BOARD_PLATFORM_REV_VAL			((SusiId_t)0x00000004)
#define SUSI_ID_BOARD_LAST_SHUTDOWN_STATUS_VAL	((SusiId_t)0x00000005)
#define SUSI_ID_BOARD_LAST_SHUTDOWN_EVENT_VAL	((SusiId_t)0x00000006)

#define SUSI_ID_BOARD_VER_BASE					((SusiId_t)0x00010000)
#define SUSI_ID_BOARD_DRIVER_VERSION_VAL		((SusiId_t)0x00010000)
#define SUSI_ID_BOARD_LIB_VERSION_VAL			((SusiId_t)0x00010001)
#define SUSI_ID_BOARD_FIRMWARE_VERSION_VAL		((SusiId_t)0x00010002)
#define SUSI_ID_BOARD_DOCUMENT_VERSION_VAL		((SusiId_t)0x00010005)

#define SUSI_ID_HWM_TEMP_GET(Id)				(Id | 0x00020000)

#define SUSI_ID_HWM_TEMP_MAX					11									/* Maximum temperature item number */
#define SUSI_ID_HWM_TEMP_BASE					0x00020000
#define SUSI_ID_HWM_TEMP_CPU					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 0))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_CHIPSET				((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 1))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_SYSTEM					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 2))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_CPU2					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 3))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_OEM0					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 4))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_OEM1					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 5))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_OEM2					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 6))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_OEM3					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 7))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_OEM4					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 8))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_OEM5					((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 9))			/* 0.1 Kelvins */
#define SUSI_ID_HWM_TEMP_SYSTEM2				((SusiId_t)(SUSI_ID_HWM_TEMP_BASE + 10))		/* 0.1 Kelvins */

#define SUSI_ID_HWM_VOLTAGE_MAX					24									/* Maximum voltage item number */
#define SUSI_ID_HWM_VOLTAGE_BASE				0x00021000
#define SUSI_ID_HWM_VOLTAGE_VCORE				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 0))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_VCORE2				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 1))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_2V5					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 2))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_3V3					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 3))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_5V					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 4))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_12V					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 5))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_5VSB				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 6))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_3VSB				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 7))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_VBAT				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 8))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_5NV					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 9))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_12NV				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 10))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_VTT					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 11))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_24V					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 12))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_DC					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 13))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_DCSTBY				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 14))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_VBATLI				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 15))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_OEM0				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 16))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_OEM1				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 17))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_OEM2				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 18))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_OEM3				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 19))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_1V05				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 20))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_1V5					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 21))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_1V8					((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 22))		/* millivolts */
#define SUSI_ID_HWM_VOLTAGE_12VS5				((SusiId_t)(SUSI_ID_HWM_VOLTAGE_BASE + 23))		/* millivolts */


#define SUSI_ID_HWM_FAN_MAX						13									/* Maximum fan item number */
#define SUSI_ID_HWM_FAN_BASE					0x00022000
#define SUSI_ID_HWM_FAN_CPU						((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 0))			/* RPM */
#define SUSI_ID_HWM_FAN_SYSTEM					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 1))			/* RPM */
#define SUSI_ID_HWM_FAN_CPU2					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 2))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM0					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 3))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM1					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 4))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM2					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 5))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM3					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 6))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM4					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 7))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM5					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 8))			/* RPM */
#define SUSI_ID_HWM_FAN_OEM6					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 9))			/* RPM */
#define SUSI_ID_HWM_FAN_SYSTEM2					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 10))			/* RPM */
#define SUSI_ID_HWM_FAN_SYSTEM3					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 11))			/* RPM */
#define SUSI_ID_HWM_FAN_SYSTEM4					((SusiId_t)(SUSI_ID_HWM_FAN_BASE + 12))			/* RPM */

#define SUSI_ID_HWM_CURRENT_MAX					3									/* Maximum current item number */
#define SUSI_ID_HWM_CURRENT_BASE				0x00023000
#define SUSI_ID_HWM_CURRENT_OEM0				((SusiId_t)(SUSI_ID_HWM_CURRENT_BASE + 0))		/* milliampere */
#define SUSI_ID_HWM_CURRENT_OEM1				((SusiId_t)(SUSI_ID_HWM_CURRENT_BASE + 1))		/* milliampere */
#define SUSI_ID_HWM_CURRENT_OEM2				((SusiId_t)(SUSI_ID_HWM_CURRENT_BASE + 2))		/* milliampere */

#define SUSI_ID_HWM_CASEOPEN_MAX				3									/* Maximum caseopen item number */
#define SUSI_ID_HWM_CASEOPEN_BASE				0x00024000
#define SUSI_ID_HWM_CASEOPEN_OEM0				((SusiId_t)(SUSI_ID_HWM_CASEOPEN_BASE + 0))
#define SUSI_ID_HWM_CASEOPEN_OEM1				((SusiId_t)(SUSI_ID_HWM_CASEOPEN_BASE + 1))
#define SUSI_ID_HWM_CASEOPEN_OEM2				((SusiId_t)(SUSI_ID_HWM_CASEOPEN_BASE + 2))
#define CASEOPEN_CLEAR_CMD						0x55AA55AA		

#define SUSI_ID_HWM_CONSUMPTION_CPU             0x00025000

#define SUSI_ID_SUPPORTED_BASE					0x00030000
#define SUSI_ID_SMBUS_SUPPORTED					((SusiId_t)0x00030000)							/* Get Support information */
#define SUSI_SMBUS_EXTERNAL_SUPPORTED			(1 << 0)
#define SUSI_SMBUS_OEM0_SUPPORTED				(1 << 1)
#define SUSI_SMBUS_OEM1_SUPPORTED				(1 << 2)
#define SUSI_SMBUS_OEM2_SUPPORTED				(1 << 3)
#define SUSI_SMBUS_OEM3_SUPPORTED				(1 << 4)
#define SUSI_ID_I2C_SUPPORTED					((SusiId_t)0x00030100)							/* Get Support information */
#define SUSI_I2C_EXTERNAL_SUPPORTED				(1 << 0)
#define SUSI_I2C_OEM0_SUPPORTED					(1 << 1)
#define SUSI_I2C_OEM1_SUPPORTED					(1 << 2)
#define SUSI_I2C_OEM2_SUPPORTED					(1 << 3)
#define SUSI_I2C_OEM3_SUPPORTED					(1 << 4)
#define SUSI_I2C_OEM4_SUPPORTED					(1 << 5)
#define SUSI_I2C_OEM5_SUPPORTED					(1 << 6)

#define SUSI_KELVINS_OFFSET						2731
#define SUSI_ENCODE_CELCIUS(Celsius)			(((Celsius) * 10) + SUSI_KELVINS_OFFSET)
#define SUSI_DECODE_CELCIUS(Celsius)			(((Celsius) - SUSI_KELVINS_OFFSET) / 10)

/* Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Unknown ID								| SUSI_STATUS_UNSUPPORTED
// Else										| SUSI_STATUS_SUCCESS
*/		
SusiStatus_t SUSI_API SusiBoardGetValue(
    SusiId_t Id,		/* IN	Value Id */
    uint32_t *pValue    /* OUT	Return Value */
    );

/* Board information string */
#define SUSI_ID_GET_NAME_MASK							(0xF0000000)
#define SUSI_ID_GET_NAME_BASE(Id)						(Id & SUSI_ID_GET_NAME_MASK)

#define SUSI_ID_BASE_GET_NAME_HWM						(0x00000000)
#define SUSI_ID_BASE_GET_NAME_HWM_FANCONTROL			(0x10000000)
#define SUSI_ID_BASE_GET_NAME_I2C						(0x20000000)
#define SUSI_ID_BASE_GET_NAME_SMB						(0x30000000)
#define SUSI_ID_BASE_GET_NAME_GPIO						(0x40000000)
#define SUSI_ID_BASE_GET_NAME_WDT						(0x50000000)
#define SUSI_ID_BASE_GET_NAME_VGA_BACKLIGHT				(0x60000000)
#define SUSI_ID_BASE_GET_NAME_STORAGE					(0x70000000)
#define SUSI_ID_BASE_GET_NAME_TML						(0x80000000)
#define SUSI_ID_BASE_GET_NAME_INFO						(0x90000000)

#define SUSI_ID_MAPPING_GET_NAME_HWM(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_HWM))
#define SUSI_ID_MAPPING_GET_NAME_HWM_FANCONTROL(Id)		((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_HWM_FANCONTROL))
#define SUSI_ID_MAPPING_GET_NAME_I2C(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_I2C))
#define SUSI_ID_MAPPING_GET_NAME_SMB(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_SMB))
#define SUSI_ID_MAPPING_GET_NAME_GPIO(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_GPIO))
#define SUSI_ID_MAPPING_GET_NAME_WDT(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_WDT))
#define SUSI_ID_MAPPING_GET_NAME_VGA_BACKLIGHT(Id)		((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_VGA_BACKLIGHT))
#define SUSI_ID_MAPPING_GET_NAME_STORAGE(Id)			((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_STORAGE))
#define SUSI_ID_MAPPING_GET_NAME_TML(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_TML))
#define SUSI_ID_MAPPING_GET_NAME_INFO(Id)				((SusiId_t)(Id | SUSI_ID_BASE_GET_NAME_INFO))

#define SUSI_ID_BOARD_MANUFACTURER_STR					((SusiId_t)0)
#define SUSI_ID_BOARD_NAME_STR							((SusiId_t)1)
#define SUSI_ID_BOARD_REVISION_STR						((SusiId_t)2)
#define SUSI_ID_BOARD_SERIAL_STR						((SusiId_t)3)
#define SUSI_ID_BOARD_BIOS_REVISION_STR					((SusiId_t)4)
#define SUSI_ID_BOARD_HW_REVISION_STR					((SusiId_t)5)
#define SUSI_ID_BOARD_PLATFORM_TYPE_STR					((SusiId_t)6)
#define SUSI_ID_BOARD_EC_FW_STR							((SusiId_t)7)
#define SUSI_ID_BOARD_BIOS_FW_STR						((SusiId_t)8)

#define SUSI_ID_BOARD_OEM0_STR							((SusiId_t)0x10)
#define SUSI_ID_BOARD_OEM1_STR							((SusiId_t)0x11)
#define SUSI_ID_BOARD_OEM2_STR							((SusiId_t)0x12)

/* Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pBufLen==NULL							| SUSI_STATUS_INVALID_PARAMETER
// pBufLen!=NULL&&*pBufLen&&pBuffer==NULL	| SUSI_STATUS_INVALID_PARAMETER
// Unknown ID								| SUSI_STATUS_UNSUPPORTED
// strlength + 1 > *pBufLen					| SUSI_STATUS_MORE_DATA
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiBoardGetStringA(
	SusiId_t Id,		/* IN		Name Id */
	char *pBuffer,		/* OUT		Destination pBuffer */
	uint32_t *pBufLen	/* INOUT	pBuffer Length */
    );

/* Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pBufLen == NULL							| SUSI_STATUS_INVALID_PARAMETER
// Length != 1, 2 or 4						| SUSI_STATUS_INVALID_PARAMETER
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiBoardReadIO(
	uint16_t Port,		/* IN	IO port address */
	uint32_t *pValue,	/* OUT	Value point */
	uint32_t Length		/* IN	Value length, should be 1, 2 or 4 */
	);

SusiStatus_t SUSI_API SusiBoardWriteIO(
	uint16_t Port,		/* IN	IO port address */
	uint32_t Value,		/* IN	Value */
	uint32_t Length		/* IN	Value length, should be 1, 2 or 4 */
	);

/* Resume Type */
#define SUSI_ID_PWR_RESUME_TYPE_NA				0x0		//Function is off
#define SUSI_ID_PWR_RESUME_TYPE_S3				0x3		//Sleep
#define SUSI_ID_PWR_RESUME_TYPE_S4				0x4		//Hibernation
#define SUSI_ID_PWR_RESUME_TYPE_G5				0x5		//Power off
#define SUSI_ID_PWR_RESUME_TYPE_G3				0x6		//Mechanical off

SusiStatus_t SUSI_API SusiBoardSetPWRCycle(
	uint32_t Delaytime,	/* IN	Power resume alarm time */
	uint8_t Eventype	/* IN	Power resume type */
	);

SusiStatus_t SUSI_API SusiBoardGetPWRCycle(
	uint32_t *Delaytime,	/* OUT	Power resume alarm time */
	uint8_t *Eventype		/* OUT	Power resume type */
	);

SusiStatus_t SUSI_API SusiBoardReadPCI(
	uint8_t Bus,		/* IN	PCI Bus number */
	uint8_t Device,		/* IN	PCI Device number */
	uint8_t Function,	/* IN	PCI Function number */
	uint32_t Offset,	/* IN	Configuration space offset */
	uint8_t *pData,		/* OUT	Data point */
	uint32_t Length		/* IN	Data length */
	);

SusiStatus_t SUSI_API SusiBoardWritePCI(
	uint8_t Bus,		/* IN	PCI Bus number */
	uint8_t Device,		/* IN	PCI Device number */
	uint8_t Function,	/* IN	PCI Function number */
	uint32_t Offset,	/* IN	Configuration space offset */
	uint8_t *pData,		/* IN	Data point */
	uint32_t Length		/* IN	Data length */
	);

SusiStatus_t SUSI_API SusiBoardReadMemory(
	uint32_t Address,	/* IN	Memory address */
	uint8_t *pData,		/* OUT	Data point */
	uint32_t Length		/* IN	Data length */
	);

SusiStatus_t SUSI_API SusiBoardWriteMemory(
	uint32_t Address,	/* IN	Memory address */
	uint8_t *pData,		/* IN	Data point */
	uint32_t Length		/* IN	Data length */
	);

SusiStatus_t SUSI_API SusiBoardReadMSR(
	uint32_t index,		/* IN	CPU MSR index */
	uint32_t *EAX_reg,	/* OUT	CPU register EAX */
	uint32_t *EDX_reg	/* OUT	CPU register EFX */
	);

SusiStatus_t SUSI_API SusiBoardWriteMSR(
	uint32_t index,	/* IN	CPU MSR index */
	uint32_t EAX_reg,	/* IN	CPU register EAX */
	uint32_t EDX_reg	/* IN	CPU register EDX */
	);

/*=============================================================================
// SMBus
//=============================================================================
*/
#define SUSI_SMBUS_MAX_DEVICE			5
#define SUSI_ID_SMBUS_EXTERNAL			((SusiId_t)0)	/* Baseboard SMBus Interface */
#define SUSI_ID_SMBUS_OEM0				((SusiId_t)1)
#define SUSI_ID_SMBUS_OEM1				((SusiId_t)2)
#define SUSI_ID_SMBUS_OEM2				((SusiId_t)3)
#define SUSI_ID_SMBUS_OEM3				((SusiId_t)4)

/* Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pBufLen == NULL							| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id								| SUSI_STATUS_UNSUPPORTED
// Bus Busy  SDA/SDC low					| SUSI_STATUS_BUSY_COLLISION
// Arbitration Error/Collision Error		| SUSI_STATUS_BUSY_COLLISION
//	On Write 1 write cycle					|
//	SDA Remains low							|
// Time-out due to clock stretching			| SUSI_STATUS_TIMEOUT
// start<Addr Byte 1><R>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<CMD Byte 1>Nak  | SUSI_STATUS_WRITE_ERROR
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiSMBReadByte(
	SusiId_t Id,		/* IN	Bus Id */
	uint8_t Addr,		/* IN	Encoded 7-Bit device address */
	uint8_t Cmd,		/* IN	Offset / Command */
	uint8_t *pBuffer	/* OUT	Transfer Byte Data pBuffer */
	);

/* Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pBufLen == NULL							| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id								| SUSI_STATUS_UNSUPPORTED
// Bus Busy  SDA/SDC low					| SUSI_STATUS_BUSY_COLLISION
// Arbitration Error/Collision Error		| SUSI_STATUS_BUSY_COLLISION
//	On Write 1 write cycle					|
//	SDA Remains low							|
// Time-out due to clock stretching			| SUSI_STATUS_TIMEOUT
// start<Addr Byte 1><W>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<CMD Byte 1>Nak  | SUSI_STATUS_WRITE_ERROR
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiSMBWriteByte(
	SusiId_t Id,		/* IN	Bus Id */
	uint8_t Addr,		/* IN	Encoded 7-Bit device address */
	uint8_t Cmd,		/* IN	Offset / Command */
	uint8_t Data		/* IN	Transfer Byte Data */
	);

SusiStatus_t SUSI_API SusiSMBReadWord(
	SusiId_t Id,		/* IN */	
	uint8_t Addr,		/* IN */	
	uint8_t Cmd,		/* IN */	
	uint16_t *pBuffer	/* OUT */	
	);

SusiStatus_t SUSI_API SusiSMBWriteWord(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t Cmd,		/* IN */
	uint16_t Data		/* IN */
	);

SusiStatus_t SUSI_API SusiSMBReceiveByte(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t *pData		/* OUT */
	);

SusiStatus_t SUSI_API SusiSMBSendByte(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t Data		/* IN */
	);

SusiStatus_t SUSI_API SusiSMBReadQuick(
	SusiId_t Id,		/* IN */
	uint8_t Addr		/* IN */
	);

SusiStatus_t SUSI_API SusiSMBWriteQuick(
	SusiId_t Id,		/* IN */
	uint8_t Addr		/* IN */
	);

SusiStatus_t SUSI_API SusiSMBReadBlock(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t Cmd,		/* IN */
	uint8_t *pBuffer,	/* OUT */
	uint32_t *pLength	/* INOUT */
	);

SusiStatus_t SUSI_API SusiSMBWriteBlock(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t Cmd,		/* IN */
	uint8_t *pBuffer,	/* IN */
	uint32_t Length		/* IN */
	);

SusiStatus_t SUSI_API SusiSMBI2CReadBlock(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t Cmd,		/* IN */
	uint8_t *pBuffer,	/* OUT */
	uint32_t Length		/* IN */
	);

SusiStatus_t SUSI_API SusiSMBI2CWriteBlock(
	SusiId_t Id,		/* IN */
	uint8_t Addr,		/* IN */
	uint8_t Cmd,		/* IN */
	uint8_t *pBuffer,	/* IN */
	uint32_t Length		/* IN */
	);

/*=============================================================================
// I2C
//=============================================================================
*/
#define SUSI_I2C_MAX_DEVICE			7
#define SUSI_ID_I2C_EXTERNAL		((SusiId_t)0)		/* Baseboard I2C Interface */
#define SUSI_ID_I2C_OEM0			((SusiId_t)1)
#define SUSI_ID_I2C_OEM1			((SusiId_t)2)
#define SUSI_ID_I2C_OEM2			((SusiId_t)3)
#define SUSI_ID_I2C_OEM3			((SusiId_t)4)
#define SUSI_ID_I2C_OEM4			((SusiId_t)5)
#define SUSI_ID_I2C_OEM5			((SusiId_t)6)

/* I2C Address Format 
//
// L = Set to 0   
// H = Set to 1   
// X = Don't Care(Direction Bit)
// 0-F Address Bit 
//
// Bits 31-16 are Reserved and should be set to 0
//
// Bit Offset      | F E D C B A 9 8 7 6 5 4 3 2 1 0
// ----------------+--------------------------------
// 7  Bit Address  | L L L L L L L L 6 5 4 3 2 1 0 X
// 10 Bit Address  | H H H H L 9 8 X 7 6 5 4 3 2 1 0
//
// Examples where Don't Care bits set to 0
//				Encoded	Encoded
//  Address		7Bit    10Bit
//  0x01		0x02	0xF001
//  0x58		0xA0	0xF058
//  0x59		0xA2	0xF059
//  0x77		0xEE	0xF077
//  0x3FF				0xF6FF
*/
#define SUSI_I2C_ENC_7BIT_ADDR(x)		(((x) & 0x07F) << 1)
#define SUSI_I2C_DEC_7BIT_ADDR(x)		(((x) >> 1) & 0x07F)
#define SUSI_I2C_ENC_10BIT_ADDR(x)		(((x) & 0xFF) | (((x) & 0x0300) << 1) | 0xF000)
#define SUSI_I2C_DEC_10BIT_ADDR(x)		(((x) & 0xFF) | (((x) >> 1) & 0x300))
#define SUSI_I2C_IS_10BIT_ADDR(x)		(((x) & 0xF800) == 0xF000)
#define SUSI_I2C_IS_7BIT_ADDR(x)		(!SUSI_I2C_IS_10BIT_ADDR(x))


/* Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// (WriteLen>1)&&(pWBuffer==NULL)			| SUSI_STATUS_INVALID_PARAMETER
// (RBufLen>1)&&(pRBuffer==NULL) 			| SUSI_STATUS_INVALID_PARAMETER
// ((WriteLen==0)&&(RBufLen==0))			| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id								| SUSI_STATUS_UNSUPPORTED
// Bus Busy  SDA/SDC low					| SUSI_STATUS_BUSY_COLLISION
// Arbitration Error/Collision Error		| SUSI_STATUS_BUSY_COLLISION
//	On Write 1 write cycle					|
//	SDA Remains low							|
// Time-out due to clock stretching			| SUSI_STATUS_TIMEOUT
// start<Addr Byte 1><W>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><R>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<CMD Byte 1>Nak  | SUSI_STATUS_WRITE_ERROR
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CWriteReadCombine(
	SusiId_t Id,		/* IN		I2C Bus Id */
	uint8_t Addr,		/* IN		Encoded 7Bit I2C Device Address */
	uint8_t *pWBuffer,	/* INOPT	Write Data pBuffer */
	uint32_t WriteLen,	/* IN		Number of Bytes to write */
	uint8_t *pRBuffer,	/* OUTOPT	Read Data pBuffer */
	uint32_t ReadLen	/* IN		Number of Bytes to Read */
    );

#define SusiI2CWrite(Id, Addr, pBuffer, ByteCnt) \
          SusiI2CWriteReadCombine(Id, Addr, pBuffer, ByteCnt, NULL, 0)
#define SusiI2CRead(Id, Addr, pBuffer, ByteCnt) \
          SusiI2CWriteReadCombine(Id, Addr, NULL, 0, pBuffer, ByteCnt)

/* Bits 31 & 30 Selects Command Type */
#define SUSI_I2C_STD_CMD				(uint32_t)(0 << 30)
#define SUSI_I2C_EXT_CMD				(uint32_t)(2 << 30)
#define SUSI_I2C_NO_CMD					(uint32_t)(1 << 30)    
#define SUSI_I2C_CMD_TYPE_MASK			(uint32_t)(3 << 30)    

#define SUSI_I2C_ENC_STD_CMD(x)			(((x) & 0xFF) | SUSI_I2C_STD_CMD)
#define SUSI_I2C_ENC_EXT_CMD(x)			(((x) & 0xFFFF) | SUSI_I2C_EXT_CMD)
#define SUSI_I2C_ENC_NO_CMD(x)			((x) | SUSI_I2C_NO_CMD)
#define SUSI_I2C_IS_EXT_CMD(x)			(((x) & SUSI_I2C_CMD_TYPE_MASK) == SUSI_I2C_EXT_CMD)
#define SUSI_I2C_IS_STD_CMD(x)			(((x) & SUSI_I2C_CMD_TYPE_MASK) == SUSI_I2C_STD_CMD)
#define SUSI_I2C_IS_NO_CMD(x)			(((x) & SUSI_I2C_CMD_TYPE_MASK) == SUSI_I2C_NO_CMD)

/* Addr Byte 1 Below Designates Addr MSB in a 10bit address transfer and 
// the complete address in an 7bit address transfer.
//
// Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pBuffer==NULL							| SUSI_STATUS_INVALID_PARAMETER
// ReadLen==0					 			| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id								| SUSI_STATUS_UNSUPPORTED
// Bus Busy  SDA/SDC low					| SUSI_STATUS_BUSY_COLLISION
// Arbitration Error/Collision Error		| SUSI_STATUS_BUSY_COLLISION
//	On Write 1 write cycle					|
//	SDA Remains low							|
// Time-out due to clock stretching			| SUSI_STATUS_TIMEOUT
// start<Addr Byte 1><R>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<Addr Byte 2>Nak | SUSI_STATUS_WRITE_ERROR or
//											| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<CMD Byte 1>Nak  | SUSI_STATUS_WRITE_ERROR
// start<Addr Byte 1><W>Ack<Data Byte 1>Nak | SUSI_STATUS_WRITE_ERROR
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CReadTransfer(
	SusiId_t Id,		/* IN	I2C Bus Id */
	uint32_t Addr,		/* IN	Encoded 7/10Bit I2C Device Address */
	uint32_t Cmd,		/* IN	I2C Command / Offset */
	uint8_t *pBuffer,	/* OUT	Transfer Data pBuffer */
	uint32_t ReadLen	/* IN	Byte Count to read */
    );

/* Addr Byte 1 Below Designates Addr MSB in a 10bit address transfer and 
// the complete address in an 7bit address transfer.
//
// Condition								| Return Values 
// -----------------------------------------+------------------------------
// Library Uninitialized					| SUSI_STATUS_NOT_INITIALIZED
// pBuffer==NULL							| SUSI_STATUS_INVALID_PARAMETER
// ByteCnt==0					 			| SUSI_STATUS_INVALID_PARAMETER
// ByteCnt > MaxLength			            | SUSI_STATUS_INVALID_BLOCK_LENGTH
// Unknown Id								| SUSI_STATUS_UNSUPPORTED
// Bus Busy  SDA/SDC low					| SUSI_STATUS_BUSY_COLLISION
// Arbitration Error/Collision Error		| SUSI_STATUS_BUSY_COLLISION
//	On Write 1 write cycle					|
//	SDA Remains low							|
// Time-out due to clock stretching			| SUSI_STATUS_TIMEOUT
// start<Addr Byte 1><W>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<Addr Byte 2>Nak | SUSI_STATUS_WRITE_ERROR or
//											| SUSI_STATUS_NOT_FOUND
// start<Addr Byte 1><W>Ack<CMD Byte 1>Nak  | SUSI_STATUS_WRITE_ERROR
// start<Addr Byte 1><W>Ack<Data Byte 1>Nak | SUSI_STATUS_WRITE_ERROR
// Else										| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CWriteTransfer(
	SusiId_t Id,		/* IN	I2C Bus Id */
	uint32_t Addr,		/* IN	Encoded 7/10Bit I2C Device Address */
	uint32_t Cmd,		/* IN	I2C Command / Offset */
	uint8_t *pBuffer,	/* IN	Transfer Data pBuffer */ 
	uint32_t ByteCnt	/* IN	Byte Count to write */
    );


/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Bus Busy  SDA/SDC low						| SUSI_STATUS_BUSY_COLLISION
// Arbitration Error/Collision Error			| SUSI_STATUS_BUSY_COLLISION
//	On Write 1 write cycle						|
//	SDA Remains low								|
// Time-out due to clock stretching				| SUSI_STATUS_TIMEOUT
//												|
// 7Bit Address									|
// start<Addr Byte><W>Nak						| SUSI_STATUS_NOT_FOUND
//												|
// 10Bit Address								|
// start<Addr Byte MSB><W>Nak					| SUSI_STATUS_NOT_FOUND
// start<Addr Byte MSB><W>Ack<Addr Byte LSB>Nak | SUSI_STATUS_NOT_FOUND
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CProbeDevice(
	SusiId_t Id,		/* IN	I2C Bus Id */
	uint32_t Addr		/* IN	Encoded 7/10Bit I2C Device Address */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// pFreq == NULL								| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CGetFrequency(
	SusiId_t Id,		/* IN	I2C Bus Id */
	uint32_t *pFreq		/* OUT	I2C Bus Frequency (KHz) */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Freq > 100 && Freq != 400					| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CSetFrequency(
	SusiId_t Id,		/* IN	I2C Bus Id */
	uint32_t Freq		/* IN	I2C Bus Frequency (KHz) */
	);

/* I2C value item IDs */
#define SUSI_ID_I2C_MAXIMUM_BLOCK_LENGTH	0x00000000

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Unknown Item Id								| SUSI_STATUS_UNSUPPORTED
// pValue == NULL								| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiI2CGetCaps(
	SusiId_t Id,		/* IN	I2C Bus Id */
	uint32_t ItemId,	/* IN	I2C Item Id */
	uint32_t *pValue	/* OUT	I2C Item value */
	);


/*=============================================================================
// GPIO -  32 GPIOs Per Bank
//=============================================================================
*/
/* Single GPIO ID Mapping */
#define SUSI_ID_GPIO_BASE					0
#define SUSI_ID_GPIO(GPIO_NUM)				((SusiId_t)(SUSI_ID_GPIO_BASE + GPIO_NUM))

/* Multiple GPIOs ID Mapping */
#define SUSI_ID_GPIO_BANK_BASE				0x00010000
#define SUSI_ID_GPIO_BANK(BANK_NUM)			((SusiId_t)(SUSI_ID_GPIO_BANK_BASE + BANK_NUM))
#define SUSI_ID_GPIO_PIN_BANK(GPIO_NUM)		((SusiId_t)(SUSI_ID_GPIO_BANK_BASE | ((GPIO_NUM) >> 5)))
#define SUSI_GPIO_PIN_BANK_MASK(GPIO_NUM)	((1 << ((GPIO_NUM) & 0x1F))

/* Levels */
#define SUSI_GPIO_LOW     0
#define SUSI_GPIO_HIGH    1

/* Directions */
#define SUSI_GPIO_INPUT   1
#define SUSI_GPIO_OUTPUT  0

/* Item ID */
#define SUSI_ID_GPIO_INPUT_SUPPORT			0x00000000
#define SUSI_ID_GPIO_OUTPUT_SUPPORT			0x00000001
#define SUSI_ID_GPIO_INTERRUPT_SUPPORT		0x00000002

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL)								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOGetCaps(
	SusiId_t Id,		/* IN		GPIO ID or Bank ID */
	uint32_t ItemId,	/* IN		Item ID */
	uint32_t *pValue	/* OUT		Item value */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// pDirection==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// (Bitmask&~(Inputs|Outputs))					| SUSI_STATUS_INVALID_BITMASK
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOGetDirection(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t *pDirection	/* OUT		Current Direction */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// (Bitmask&~(Inputs|Outputs))					| SUSI_STATUS_INVALID_BITMASK
// (Bitmask&Direction)&Inputs					| SUSI_STATUS_INVALID_DIRECTION
// (Bitmask&Direction)&Outputs					| SUSI_STATUS_INVALID_DIRECTION
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOSetDirection(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t Direction		/* IN		Direction */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// pLevel==NULL									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// (Bitmask&~(Inputs|Outputs))					| SUSI_STATUS_INVALID_BITMASK
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOGetLevel(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t *pLevel		/* OUT		Current Level */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOSetLevel(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t Level			/* IN		Level */
    );

/* Condition									| Return Values
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOIntGetEdge(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t *pEdge);		/* OUT		Interrupt trigger edge */

/* Condition									| Return Values
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOIntSetEdge(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t edge);			/* IN		Interrupt trigger edge */

/* Condition									| Return Values
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOIntGetPin(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t *pPin);		/* OUT		Interrupt pin selected */

/* Condition									| Return Values
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOIntSetPin(
	SusiId_t Id,			/* IN		GPIO ID or Bank ID */
	uint32_t Bitmask,		/* INOPT	Bit mask of Affected Bits */
	uint32_t pin);			/* IN		Interrupt pin selected */

typedef void (SUSI_API *SUSI_INT_CALLBACK)(void*);

/* Condition									| Return Values
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Bitmask==0 when Bank mode					| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOIntRegister(
	SUSI_INT_CALLBACK pfnCallback);   /* IN	GPIO interrupt event callback */


/* Condition									| Return Values
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiGPIOIntUnRegister(void);

/*=============================================================================
// VGA
//=============================================================================
*/
#define SUSI_ID_BACKLIGHT_MAX			4
#define SUSI_ID_BACKLIGHT_1				((SusiId_t)0)
#define SUSI_ID_BACKLIGHT_2				((SusiId_t)1)
#define SUSI_ID_BACKLIGHT_3				((SusiId_t)2)
#define SUSI_ID_BACKLIGHT_4				((SusiId_t)3)

#define SUSI_BACKLIGHT_SET_ON			1
#define SUSI_BACKLIGHT_SET_OFF			0

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pEnable==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaGetBacklightEnable( 
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t *pEnable	/* OUT	Backlight enable status */
						/*		0 = Disable, others = Enable */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaSetBacklightEnable(
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t Enable		/* IN	Control backlight enable */
						/*		0 = Disable, others = Enable */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// pBright==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaGetBacklightBrightness( 
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t *pBright   /* OUT	Backlight Brightness */
    );

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Bright > MAX value							| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaSetBacklightBrightness(
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t Bright		/* IN	Backlight Brightness */
    );

#define SUSI_BACKLIGHT_LEVEL_MAXIMUM			9
#define SUSI_BACKLIGHT_LEVEL_MINIMUM			0

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// pBright==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaGetBacklightLevel(
	SusiId_t Id,
	uint32_t *pLevel
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// pBright==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaSetBacklightLevel(
	SusiId_t Id,
	uint32_t Level
	);


#define SUSI_BACKLIGHT_POLARITY_ON		1
#define SUSI_BACKLIGHT_POLARITY_OFF		0
/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pPolarity==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaGetPolarity( 
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t *pPolarity	/* OUT	Backlight PWM invert */
						/*		0 = Non-invert, 1 = Invert */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaSetPolarity( 
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t Polarity	/* IN	Control backlight PWM invert */
						/*		0 = Non-invert, 1 = Invert */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pFrequency==NULL								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaGetFrequency( 
	SusiId_t Id,			/* IN	Backlight Id */
	uint32_t *pFrequency	/* OUT	Backlight PWM frequency */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaSetFrequency( 
	SusiId_t Id,			/* IN	Backlight Id */
	uint32_t Frequency		/* IN	Control backlight PWM frequency */
	);

/* VGA value item IDs */
#define SUSI_ID_VGA_BRIGHTNESS_MAXIMUM		0x00010000
#define SUSI_ID_VGA_BRIGHTNESS_MINIMUM		0x00010001

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiVgaGetCaps( 
	SusiId_t Id,		/* IN	Backlight Id */
	uint32_t ItemId,	/* IN	Value item Id */
	uint32_t *pValue	/* OUT	Return Value */
	);


/*=============================================================================
// Storage
//=============================================================================
*/
#define SUSI_ID_STORAGE_MAX				12
#define SUSI_ID_STORAGE_STD				((SusiId_t)0x00000000)
#define SUSI_ID_STORAGE_OEM0			((SusiId_t)0x00000001)
#define SUSI_ID_STORAGE_OEM1			((SusiId_t)0x00000002)
#define SUSI_ID_STORAGE_OEM2			((SusiId_t)0x00000003)
#define SUSI_ID_STORAGE_OEM3			((SusiId_t)0x00000004)
#define SUSI_ID_STORAGE_OEM4			((SusiId_t)0x00000005)
#define SUSI_ID_STORAGE_OEM5			((SusiId_t)0x00000006)
#define SUSI_ID_STORAGE_OEM6			((SusiId_t)0x00000007)
#define SUSI_ID_STORAGE_OEM7			((SusiId_t)0x00000008)
#define SUSI_ID_STORAGE_OEM8			((SusiId_t)0x00000009)
#define SUSI_ID_STORAGE_OEM9			((SusiId_t)0x0000000A)
#define SUSI_ID_STORAGE_OEM10			((SusiId_t)0x0000000B)

/* Storage value item IDs */
#define SUSI_ID_STORAGE_TOTAL_SIZE		0x00000000
#define SUSI_ID_STORAGE_BLOCK_SIZE		0x00000001
#define SUSI_ID_STORAGE_LOCK_STATUS		0x00010000
#define SUSI_ID_STORAGE_PSW_MAX_LEN		0x00010001

#define SUSI_STORAGE_STATUS_LOCK		1
#define SUSI_STORAGE_STATUS_UNLOCK		0
/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiStorageGetCaps(
	SusiId_t Id,		/* IN	Storage Id */
	uint32_t ItemId,	/* IN	Value item Id */
	uint32_t *pValue	/* OUT	Return Value */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pBuffer==NULL								| SUSI_STATUS_INVALID_PARAMETER
// BufLen==0									| SUSI_STATUS_INVALID_PARAMETER
// Offset+BufLen>TotalSize						| SUSI_STATUS_INVALID_BLOCK_LENGTH
// Read error									| SUSI_STATUS_READ_ERROR
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiStorageAreaRead(
	SusiId_t Id,		/* IN	Storage Area Id */
	uint32_t Offset,	/* IN	Byte Offset */
	uint8_t *pBuffer, 	/* OUT	Pointer to Data pBuffer */
	uint32_t BufLen  	/* IN	Read Data count */ 
);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pBuffer==NULL								| SUSI_STATUS_INVALID_PARAMETER
// BufLen==0									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiStorageAreaWrite(
	SusiId_t Id,		/* IN	Storage Area Id */
	uint32_t Offset,	/* IN	Byte Offset */
	uint8_t *pBuffer, 	/* IN	Pointer to Data pBuffer */
	uint32_t BufLen  	/* IN	Write Data count */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pBuffer==NULL								| SUSI_STATUS_INVALID_PARAMETER
// BufLen==0									| SUSI_STATUS_INVALID_PARAMETER
// Unlock error									| SUSI_STATUS_WRITE_ERROR
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiStorageAreaSetUnlock(
	SusiId_t Id,		/* IN	Storage Area Id */
	uint8_t *pBuffer, 	/* IN	Pointer to Data pBuffer */
	uint32_t BufLen  	/* IN	Buffer length */ 
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pBuffer==NULL								| SUSI_STATUS_INVALID_PARAMETER
// BufLen==0									| SUSI_STATUS_INVALID_PARAMETER
// Lock error									| SUSI_STATUS_WRITE_ERROR
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiStorageAreaSetLock(
	SusiId_t Id,		/* IN	Storage Area Id */
	uint8_t *pBuffer, 	/* IN	Pointer to Data pBuffer */
	uint32_t BufLen  	/* IN	Buffer length */ 
	);


/*=============================================================================
// Fan Control
//=============================================================================
*/

/* Fan control value item IDs */
#define SUSI_ID_FC_CONTROL_SUPPORT_FLAGS		0x00000000	/* Reference "Control Support Flags" */
#define SUSI_ID_FC_AUTO_SUPPORT_FLAGS			0x00000001	/* Reference "Auto Support Flags" */

/* Control Support Flags */
#define SUSI_FC_FLAG_SUPPORT_OFF_MODE			(1 << 0)	/* Support OFF mode */
#define SUSI_FC_FLAG_SUPPORT_FULL_MODE			(1 << 1)	/* Support FULL mode */
#define SUSI_FC_FLAG_SUPPORT_MANUAL_MODE		(1 << 2)	/* Support Manual mode */
#define SUSI_FC_FLAG_SUPPORT_AUTO_MODE			(1 << 3)	/* Support Auto mode */

/* Auto Support Flags */
#define SUSI_FC_FLAG_SUPPORT_AUTO_LOW_STOP		(1 << 0)	/* Support Low Stop Behavior (Depend on Auto mode) */
#define SUSI_FC_FLAG_SUPPORT_AUTO_LOW_LIMIT		(1 << 1)	/* Support Low Limit Behavior (Depend on Auto mode) */
#define SUSI_FC_FLAG_SUPPORT_AUTO_HIGH_LIMIT	(1 << 2)	/* Support High Limit Behavior (Depend on Auto mode) */
#define SUSI_FC_FLAG_SUPPORT_AUTO_PWM			(1 << 8)	/* Support PWM operate mode (Depend on Auto mode) */
#define SUSI_FC_FLAG_SUPPORT_AUTO_RPM			(1 << 9)	/* Support RPM operate mode (Depend on Auto mode) */

/* Note:
//	Item ID also can use SUSI_ID_HWM_TEMP_XXX to get is it support in this function or not.

// Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiFanControlGetCaps( 
	SusiId_t Id,		/* IN	Thermal Id */
	uint32_t ItemId,	/* IN	Value item Id */
	uint32_t *pValue	/* OUT	Return Value */
	);


#define SUSI_FAN_AUTO_CTRL_OPMODE_PWM	0
#define SUSI_FAN_AUTO_CTRL_OPMODE_RPM	1

/* For TmlSource member of AutoFan struct
//	Bits 31 Selects Thermal Source Type
//		- Set this flag means the source is original code for target chip not a SUSI ID.
*/
#define THERMAL_TYPE_ORG_FLAG			(uint32_t)(1 << 31)	

#define SUSI_TMLSRC_ORG(x)				(((x) & 0xFF) | THERMAL_TYPE_ORG_FLAG)
#define SUSI_TMLSRC_IS_ORG(x)			(((x) & THERMAL_TYPE_ORG_FLAG) == THERMAL_TYPE_ORG_FLAG)
															
typedef struct _AutoFan {
	uint32_t TmlSource;		/* Thermal Source (Mapping to SUSI_ID_HWM_FAN_XXX) */
	uint32_t OpMode;
	uint32_t LowStopLimit;	/* Temperature (0.1 Kelvins) */
	uint32_t LowLimit;		/* Temperature (0.1 Kelvins) */
	uint32_t HighLimit;		/* Temperature (0.1 Kelvins) */
	uint32_t MinPWM;		/* Enable when OpMode == FAN_AUTO_CTRL_OPMODE_PWM */
	uint32_t MaxPWM;		/* Enable when OpMode == FAN_AUTO_CTRL_OPMODE_PWM */
	uint32_t MinRPM;		/* Enable when OpMode == FAN_AUTO_CTRL_OPMODE_RPM */
	uint32_t MaxRPM;		/* Enable when OpMode == FAN_AUTO_CTRL_OPMODE_RPM */
} AutoFan , *PAutoFan ;

/* Mode */
#define SUSI_FAN_CTRL_MODE_OFF			0
#define SUSI_FAN_CTRL_MODE_FULL			1
#define SUSI_FAN_CTRL_MODE_MANUAL		2
#define SUSI_FAN_CTRL_MODE_AUTO			3
typedef struct _SusiFanControl {
	uint32_t Mode;
	uint32_t PWM;			/* Manual mode only (0 - 100%) */
	AutoFan AutoControl;	/* Auto mode only */
} SusiFanControl, *PSusiFanControl;

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pConfig==NULL								| SUSI_STATUS_INVALID_PARAMETER
// pConfig->Size Invalid						| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiFanControlGetConfig(
	SusiId_t Id,				/* IN	Fan Id */
	SusiFanControl *pConfig		/* OUT	Fan config */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pConfig==NULL								| SUSI_STATUS_INVALID_PARAMETER
// pConfig->Size Invalid						| SUSI_STATUS_INVALID_PARAMETER
// Config Invalid								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiFanControlSetConfig(
	SusiId_t Id,				/* IN	Fan Id */
	SusiFanControl *pConfig		/* IN	Fan config */
	);


/*=============================================================================
// Thermal Protect
//=============================================================================
*/
#define SUSI_ID_THERMAL_MAX						4		
#define SUSI_ID_THERMAL_PROTECT_1				((SusiId_t)0)
#define SUSI_ID_THERMAL_PROTECT_2				((SusiId_t)1)
#define SUSI_ID_THERMAL_PROTECT_3				((SusiId_t)2)
#define SUSI_ID_THERMAL_PROTECT_4				((SusiId_t)3)

/* Thermal Protection value item IDs */
#define SUSI_ID_TP_EVENT_SUPPORT_FLAGS			0x00000000	/* Reference "Support Flags" */
#define SUSI_ID_TP_EVENT_TRIGGER_MAXIMUM		0x00000001	/* Send Event */
#define SUSI_ID_TP_EVENT_TRIGGER_MINIMUM		0x00000002
#define SUSI_ID_TP_EVENT_CLEAR_MAXIMUM			0x00000003
#define SUSI_ID_TP_EVENT_CLEAR_MINIMUM			0x00000004

/* Support Flags */
#define SUSI_THERMAL_FLAG_SUPPORT_SHUTDOWN		(1 << 0)
#define SUSI_THERMAL_FLAG_SUPPORT_THROTTLE		(1 << 1)
#define SUSI_THERMAL_FLAG_SUPPORT_POWEROFF		(1 << 2)

/* Note:
//	Item ID also can use SUSI_ID_HWM_TEMP_XXX to get is it support in this function or not.

// Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiThermalProtectionGetCaps( 
	SusiId_t Id,		/* IN	Thermal Id */
	uint32_t ItemId,	/* IN	Value item Id */
	uint32_t *pValue	/* OUT	Return Value */
	);


/* Thermal Protection Event type */
#define SUSI_THERMAL_EVENT_SHUTDOWN				0x00
#define SUSI_THERMAL_EVENT_THROTTLE				0x01
#define SUSI_THERMAL_EVENT_POWEROFF				0x02
#define SUSI_THERMAL_EVENT_NONE					0xFF

typedef struct _SusiThermalProtect{
	uint32_t SourceId;					/* Reference SUSI_ID_HWM_TEMP_XXX */
	uint32_t EventType;
	uint32_t SendEventTemperature;		/* 0.1 Kelvins */
	uint32_t ClearEventTemperature;		/* 0.1 Kelvins */
} SusiThermalProtect, *PSusiThermalProtect;

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pConfig==NULL								| SUSI_STATUS_INVALID_PARAMETER
// pConfig->Size Invalid						| SUSI_STATUS_INVALID_PARAMETER
// Config Invalid								| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiThermalProtectionSetConfig(
	SusiId_t Id,				/* IN	Thermal Id */
	SusiThermalProtect *pConfig	/* IN	Thermal config */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pConfig==NULL								| SUSI_STATUS_INVALID_PARAMETER
// pConfig->Size Invalid						| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiThermalProtectionGetConfig(
	SusiId_t Id,				/* IN	Thermal Id */
	SusiThermalProtect *pConfig	/* OUT	Thermal config */
	);


/*=============================================================================
// WDT
//=============================================================================
*/
#define SUSI_ID_WATCHDOG_MAX				4
#define SUSI_ID_WATCHDOG_1					((SusiId_t)0)
#define SUSI_ID_WATCHDOG_2					((SusiId_t)1)
#define SUSI_ID_WATCHDOG_3					((SusiId_t)2)
#define SUSI_ID_WATCHDOG_4					((SusiId_t)3)

/* WDT value item IDs */
#define SUSI_ID_WDT_SUPPORT_FLAGS			0x00000000	/* Reference "Support Flags" */
#define SUSI_ID_WDT_DELAY_MAXIMUM			0x00000001
#define SUSI_ID_WDT_DELAY_MINIMUM			0x00000002
#define SUSI_ID_WDT_EVENT_MAXIMUM			0x00000003
#define SUSI_ID_WDT_EVENT_MINIMUM			0x00000004
#define SUSI_ID_WDT_RESET_MAXIMUM			0x00000005
#define SUSI_ID_WDT_RESET_MINIMUM			0x00000006
#define SUSI_ID_WDT_UNIT_MINIMUM			0x0000000F
#define SUSI_ID_WDT_DELAY_TIME				0x00010001
#define SUSI_ID_WDT_EVENT_TIME				0x00010002
#define SUSI_ID_WDT_RESET_TIME				0x00010003
#define SUSI_ID_WDT_EVENT_TYPE				0x00010004

/* Support Flags */
#define SUSI_WDT_FLAG_SUPPORT_IRQ			(1 << 1)
#define SUSI_WDT_FLAG_SUPPORT_SCI			(1 << 2)
#define SUSI_WDT_FLAG_SUPPORT_PWRBTN		(1 << 3)
#define SUSI_WDT_FLAG_SUPPORT_PIN			(1 << 4)

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// pValue==NULL									| SUSI_STATUS_INVALID_PARAMETER
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiWDogGetCaps( 
	SusiId_t Id,		/* IN	WDog Id */
	uint32_t ItemId,	/* IN	Value item Id */
	uint32_t *pValue	/* OUT	Return Value */
	);


/* Event Types */
#define SUSI_WDT_EVENT_TYPE_NONE			0x00000000
#define SUSI_WDT_EVENT_TYPE_IRQ				0x00000001
#define SUSI_WDT_EVENT_TYPE_SCI				0x00000002
#define SUSI_WDT_EVENT_TYPE_PWRBTN			0x00000003
#define SUSI_WDT_EVENT_TYPE_PIN				0x00000004

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Running										| SUSI_STATUS_RUNNING
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiWDogStart( 
	SusiId_t Id,		/* IN	WDog Id */
	uint32_t DelayTime,	/* IN	Value delay time */
	uint32_t EventTime,	/* IN	Value event time */
	uint32_t ResetTime,	/* IN	Value reset time */
	uint32_t EventType	/* IN	Determine event type */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiWDogStop( 
	SusiId_t Id		/* IN	WDog Id */
	);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiWDogTrigger( 
	SusiId_t Id		/* IN	WDog Id */
	);


typedef void (SUSI_API *SUSI_WDT_INT_CALLBACK)(void*);

/* Condition									| Return Values 
// ---------------------------------------------+------------------------------
// Library Uninitialized						| SUSI_STATUS_NOT_INITIALIZED
// Unknown Id									| SUSI_STATUS_UNSUPPORTED
// Else											| SUSI_STATUS_SUCCESS
*/
SusiStatus_t SUSI_API SusiWDogSetCallBack( 
	SusiId_t Id,						/* IN	WDog Id */
	SUSI_WDT_INT_CALLBACK pfnCallback,	/* IN	WDog INT event callback */
	void *Context						/* IN	WDog INT event callback context */
	);

#ifdef __cplusplus
}
#endif

#endif /* _SUSI4_H_ */
