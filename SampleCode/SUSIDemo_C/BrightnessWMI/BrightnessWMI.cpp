#define _WIN32_DCOM
#include <iostream>
using namespace std;
#include <comdef.h>
#include <Wbemidl.h>
#include <string> 
#pragma comment(lib, "wbemuuid.lib")

IWbemLocator  *pLoc = NULL;
IWbemServices *pSvc = NULL;
BSTR bstrWmiPath = NULL;

IWbemClassObject *brightnessObj = NULL;
IWbemClassObject *brightnessObjInstant = NULL;
IWbemClassObject *pclsObj = NULL;
IWbemClassObject *brightnessMethodInstant = NULL;
IWbemClassObject *brightnessClassObject = NULL;

IEnumWbemClassObject *pEnumerator = NULL;
IEnumWbemClassObject *brightnessClassEnum = NULL;

BSTR bstrClassPath = NULL;
BSTR brightnessMethodName = NULL;
BSTR bstrArgTimeout = NULL;
BSTR bstrArgBrightness = NULL;
BSTR bstrQuery = NULL;
BSTR brightnessClassPath = NULL;
BSTR brightnessVariableName = NULL;
BSTR brightnessQuery = NULL;

int Init()
{
	HRESULT hres = S_OK;
	if (bstrWmiPath == NULL)
		bstrWmiPath = SysAllocString(L"ROOT\\WMI");
	if (bstrClassPath == NULL)
		bstrClassPath = SysAllocString(L"WmiMonitorBrightnessMethods");
	if (brightnessMethodName == NULL)
		brightnessMethodName = SysAllocString(L"WmiSetBrightness");
	if (bstrArgTimeout == NULL)
		bstrArgTimeout = SysAllocString(L"Timeout");
	if (bstrArgBrightness == NULL)
		bstrArgBrightness = SysAllocString(L"Brightness");
	if (bstrQuery == NULL)
		bstrQuery = SysAllocString(L"SELECT * FROM WmiMonitorBrightnessMethods");
	if (brightnessClassPath == NULL)
		brightnessClassPath = SysAllocString(L"WmiMonitorBrightness");
	if (brightnessVariableName == NULL)
		brightnessVariableName = SysAllocString(L"CurrentBrightness");
	if (brightnessQuery == NULL)
		brightnessQuery = SysAllocString(L"SELECT * FROM WmiMonitorBrightness");

	hres = CoInitializeEx(0, COINIT_MULTITHREADED);
	if (FAILED(hres))
	{
		printf("Failed to initialize COM library. Error code = 0x%X\n", hres);
		return -1;
	}
	hres = CoInitializeSecurity(NULL, -1, NULL, NULL, RPC_C_AUTHN_LEVEL_DEFAULT, RPC_C_IMP_LEVEL_IMPERSONATE, NULL, EOAC_NONE, NULL);
	if (FAILED(hres))
	{
		printf("Failed to initialize security. Error code = 0x%X\n", hres);
		return -1;
	}
	if (pLoc != NULL)
	{
		pLoc->Release();
		pLoc = NULL;
	}
	hres = CoCreateInstance(CLSID_WbemLocator, 0, CLSCTX_INPROC_SERVER, IID_IWbemLocator, (LPVOID *)&pLoc);
	if (FAILED(hres))
	{
		printf("Failed to create IWbemLocator object. Error code = 0x%X\n", hres);
		return -1;
	}
	if (pSvc != NULL)
	{
		pSvc->Release();
		pSvc = NULL;
	}
	if (pLoc != NULL)
		hres = pLoc->ConnectServer(bstrWmiPath, NULL, NULL, NULL, 0, NULL, NULL, &pSvc);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("Could not connect server. Error code = 0x%X\n", hres);
		return -1;
	}
	if (pSvc != NULL)
		hres = CoSetProxyBlanket(pSvc, RPC_C_AUTHN_WINNT, RPC_C_AUTHZ_NONE, NULL, RPC_C_AUTHN_LEVEL_CALL, RPC_C_IMP_LEVEL_IMPERSONATE, NULL, EOAC_NONE);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("Could not set proxy blanket. Error code = 0x%X\n", hres);
		return -1;
	}
	if (pEnumerator != NULL)
	{
		pEnumerator->Release();
		pEnumerator = NULL;
	}
	if (pSvc != NULL)
		hres = pSvc->ExecQuery(_bstr_t(L"WQL"), bstrQuery, WBEM_FLAG_FORWARD_ONLY | WBEM_FLAG_RETURN_IMMEDIATELY, NULL, &pEnumerator);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("Query for processes failed. Error code = 0x%X\n", hres);
		return -1;
	}
	if (pclsObj != NULL)
	{
		pclsObj->Release();
		pclsObj = NULL;
	}
	ULONG uReturn = 0;
	if (pEnumerator != NULL)
		hres = pEnumerator->Next(WBEM_INFINITE, 1, &pclsObj, &uReturn);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("pEnumerator failed. Error code = 0x%X\n", hres);
		return -1;
	}
	if (brightnessObj != NULL)
	{
		brightnessObj->Release();
		brightnessObj = NULL;
	}
	if (pSvc != NULL)
		hres = pSvc->GetObject(bstrClassPath, 0, NULL, &brightnessObj, NULL);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("GetObject failed. Error code = 0x%X\n", hres);
		return -1;
	}
	if (brightnessObjInstant != NULL)
	{
		brightnessObjInstant->Release();
		brightnessObjInstant = NULL;
	}
	if (brightnessObj != NULL)
		hres = brightnessObj->GetMethod(brightnessMethodName, 0, &brightnessObjInstant, NULL);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("GetMethod failed. Error code = 0x%X\n", hres);
		return -1;
	}
	if (brightnessMethodInstant != NULL)
	{
		brightnessMethodInstant->Release();
		brightnessMethodInstant = NULL;
	}
	if (brightnessObjInstant != NULL)
		hres = brightnessObjInstant->SpawnInstance(0, &brightnessMethodInstant);
	else
		hres = -1;
	if (FAILED(hres))
	{
		printf("SpawnInstance failed. Error code = 0x%X\n", hres);
		return -1;
	}

	if (brightnessMethodInstant == NULL)
		return -1;
	if (pSvc == NULL)
		return -1;
	return 0;
}

int GetBrightness()
{
	int brightness = 0;
	HRESULT hr = S_OK;
	if (brightnessClassEnum != NULL)
	{
		brightnessClassEnum->Release();
		brightnessClassEnum = NULL;
	}
	if (brightnessClassObject != NULL)
	{
		brightnessClassObject->Release();
		brightnessClassObject = NULL;
	}
	if (pSvc != NULL)
		hr = pSvc->ExecQuery(_bstr_t(L"WQL"), brightnessQuery, WBEM_FLAG_FORWARD_ONLY | WBEM_FLAG_RETURN_IMMEDIATELY, NULL, &brightnessClassEnum);
	else
		return -1;
	if (hr != WBEM_S_NO_ERROR)
		return -1;

	DWORD ret = 0;
	if (brightnessClassEnum != NULL)
		hr = brightnessClassEnum->Next(WBEM_INFINITE, 1, &brightnessClassObject, &ret);
	else
		return -1;

	if (hr != WBEM_S_NO_ERROR)
		return -1;

	VARIANT brightnessValue;
	VariantInit(&brightnessValue);
	if (brightnessClassObject != NULL)
		hr = brightnessClassObject->Get(brightnessVariableName, 0, &brightnessValue, 0, 0);
	else
		hr = -1;
	if (hr != WBEM_S_NO_ERROR)
	{
		VariantClear(&brightnessValue);
		return -1;
	}
	brightness = brightnessValue.uintVal;
	VariantClear(&brightnessValue);
	return brightness;
}

int SetBrightness(int brightness)
{
	HRESULT hr = S_OK;
	brightness = min(max(brightness, 0), 100);

	VARIANT var, var1;
	VariantInit(&var);
	VariantInit(&var1);
	V_VT(&var) = VT_BSTR;
	V_VT(&var1) = VT_BSTR;

	V_BSTR(&var) = SysAllocString(L"0");
	hr = brightnessMethodInstant->Put(bstrArgTimeout, 0, &var, CIM_UINT32);
	SysFreeString(V_BSTR(&var));
	VariantClear(&var);
	if (hr != WBEM_S_NO_ERROR)
		return -1;

	V_BSTR(&var1) = SysAllocString(to_wstring(brightness).c_str());
	hr = brightnessMethodInstant->Put(bstrArgBrightness, 0, &var1, CIM_UINT8);
	SysFreeString(V_BSTR(&var1));
	VariantClear(&var1);
	if (hr != WBEM_S_NO_ERROR)
		return -1;

	VARIANT pathVariable;
	VariantInit(&pathVariable);
	hr = pclsObj->Get(_bstr_t(L"__PATH"), 0, &pathVariable, NULL, NULL);
	if (hr != WBEM_S_NO_ERROR)
	{
		VariantClear(&pathVariable);
		return -1;
	}

	hr = pSvc->ExecMethod(pathVariable.bstrVal, brightnessMethodName, 0, NULL, brightnessMethodInstant, NULL, NULL);
	VariantClear(&pathVariable);
	if (hr != WBEM_S_NO_ERROR)
		return -1;
	return 0;
}

void Cleanup()
{
	if (bstrWmiPath != NULL)
	{
		SysFreeString(bstrWmiPath);
		bstrWmiPath = NULL;
	}
	if (bstrClassPath != NULL)
	{
		SysFreeString(bstrClassPath);
		bstrClassPath = NULL;
	}
	if (brightnessMethodName != NULL)
	{
		SysFreeString(brightnessMethodName);
		brightnessMethodName = NULL;
	}
	if (bstrArgTimeout != NULL)
	{
		SysFreeString(bstrArgTimeout);
		bstrArgTimeout = NULL;
	}
	if (bstrArgBrightness != NULL)
	{
		SysFreeString(bstrArgBrightness);
		bstrArgBrightness = NULL;
	}
	if (bstrQuery != NULL)
	{
		SysFreeString(bstrQuery);
		bstrQuery = NULL;
	}
	if (brightnessClassPath != NULL)
	{
		SysFreeString(brightnessClassPath);
		brightnessClassPath = NULL;
	}
	if (brightnessVariableName != NULL)
	{
		SysFreeString(brightnessVariableName);
		brightnessVariableName = NULL;
	}
	if (brightnessQuery != NULL)
	{
		SysFreeString(brightnessQuery);
		brightnessQuery = NULL;
	}
	if (brightnessObj != NULL)
	{
		brightnessObj->Release();
		brightnessObj = NULL;
	}
	if (brightnessMethodInstant != NULL)
	{
		brightnessMethodInstant->Release();
		brightnessMethodInstant = NULL;
	}
	if (brightnessObjInstant != NULL)
	{
		brightnessObjInstant->Release();
		brightnessObjInstant = NULL;
	}
	if (pclsObj != NULL)
	{
		pclsObj->Release();
		pclsObj = NULL;
	}
	if (pEnumerator != NULL)
	{
		pEnumerator->Release();
		pEnumerator = NULL;
	}
	if (brightnessClassObject != NULL)
	{
		brightnessClassObject->Release();
		brightnessClassObject = NULL;
	}
	if (brightnessClassEnum != NULL)
	{
		brightnessClassEnum->Release();
		brightnessClassEnum = NULL;
	}
	if (pSvc != NULL)
	{
		pSvc->Release();
		pSvc = NULL;
	}
	if (pLoc != NULL)
	{
		pLoc->Release();
		pLoc = NULL;
	}
	CoUninitialize();
}

static void title()
{
	printf(
		"**********************************************\n"
		"**               SUSI4.0 demo               **\n"
		"**********************************************\n\n");

	printf("WMI brightness\n\n");
}
int main()
{
	int op = 0, value = 0;

	if (Init() != 0)
	{
		printf("Initialize failed.\n");
		printf("Exit the program...\n");
		system("pause");
		return -1;
	}
	value = GetBrightness();
	while (1)
	{
		system("cls");
		title();
		printf("0) Terminate this program\n");
		printf("1) Brightness value (0 to 100): %u\n", value);
		printf("2) Get/Refresh value\n");
		printf("\nEnter your choice: ");
		scanf_s("%u", &op);
		switch (op)
		{
		case 0:
			goto exit;

		case 1:
			printf("\nBrightness value (0 to 100): ");
			scanf_s("%u", &value);
			SetBrightness(value);
			break;

		case 2:
			value = GetBrightness();
			printf("Refreshed.\n\n");
			break;

		default:
			printf("Unknown choice!\n\n");
			break;
		}
		system("pause");
	}
exit:
	Cleanup();
    return 0;
}

