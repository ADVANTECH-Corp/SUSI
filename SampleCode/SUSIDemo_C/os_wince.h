#ifndef _OS_WINCE_H_
#define _OS_WINCE_H_

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

#if defined(WINCE)

#define main _tmain

#include "version.h"
#include <winioctl.h>
#include <TCHAR.h>
#include "winbase.h"

#pragma comment(lib,"lib/WINCE/Susi4.lib")
#pragma comment(linker, "/nodefaultlib:libc.lib")

#include <stdlib.h>
#define CLRSCR "\f"
#define system(cmd)	printf(cmd)

#include <stdio.h>
#define SCANF_IN(format, pvalue)	scanf(format, pvalue)
#define SCANF2_IN(format, pvalue)	SCANF_IN(format, pvalue)

#include <string.h>
#define STRING_CP(pdest, psrc)		strcpy(pdest, psrc)

#include <windows.h>
#define SLEEP_USEC(ms)	Sleep((DWORD)ms)

#endif /* WINCE */
#endif /* _OS_WINCE_H_ */
