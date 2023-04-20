#ifndef _OS_WINDOWS_H_
#define _OS_WINDOWS_H_

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

#if defined(WIN32) && !defined(WINCE) || defined(_WIN64)

#include "version.h"

#if defined(_WIN64)
#pragma comment(lib,"lib/x64/Susi4.lib")
#elif defined(WIN32) && !defined(_WIN32ONECORE)
#pragma comment(lib,"lib/Win32/Susi4.lib")
#elif defined(_WIN32ONECORE)
#pragma comment(lib,"lib/WinOC/Susi4.lib")
#endif

#include <stdlib.h>
#define CLRSCR "cls"

#include <stdio.h>
#define SCANF_IN(format, pvalue)	scanf_s(format, pvalue)
#define SCANF2_IN(format, pvalue)	scanf_s(format, pvalue, STRING_MAXIMUM_LENGTH)

#include <string.h>
#define STRING_CP(pdest, psrc)		strcpy_s(pdest, NAME_MAXIMUM_LENGTH - 1, psrc)

#include <windows.h>
#define SLEEP_USEC(ms)	Sleep((DWORD)ms)

#endif /* WIN32 or _WIN64 or _WIN32ONECORE */
#endif /* _OS_WINDOWS_H_ */
