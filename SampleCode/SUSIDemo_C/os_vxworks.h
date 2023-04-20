#ifndef _OS_VXWORKS_H_
#define _OS_VXWORKS_H_

#if defined(__VXWORKS__)

#include "susi4_version.h"

#define main	susiDemo

#include <stdlib.h>
#define CLRSCR		"\33[2J"
#define system(cmd)	printf(cmd)

#include <stdio.h>
#define SCANF_IN(format, pvalue)	scanf(format, pvalue)
#define SCANF2_IN(format, pvalue)	SCANF_IN(format, pvalue)

#include <string.h>
#define STRING_CP(pdest, psrc)		strcpy(pdest, psrc)

#define SLEEP_USEC(ms)

#endif /* VxWorks */
#endif /* _OS_VXWORKS_H_ */
