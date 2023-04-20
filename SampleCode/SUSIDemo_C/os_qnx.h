#ifndef _OS_QNX_H_
#define _OS_QNX_H_

#if defined(__QNX__)

#include "version.h"

#include <stdlib.h>
#define CLRSCR "clear"

#include <stdio.h>
#define SCANF_IN(format, pvalue)	scanf(format, pvalue)
#define SCANF2_IN(format, pvalue)	SCANF_IN(format, pvalue)

#include <string.h>
#define STRING_CP(pdest, psrc)		strcpy(pdest, psrc)

#include <unistd.h>
#define SLEEP_USEC(ms)				usleep(1000 * (unsigned long)ms)

#endif /* QNX */
#endif /* _OS_QNX_H_ */
