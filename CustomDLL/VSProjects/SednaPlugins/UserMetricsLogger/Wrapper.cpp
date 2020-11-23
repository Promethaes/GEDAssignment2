#include "Wrapper.h"

UserMetricsLogger logger;


void WriteUserMetricsToFile()
{
	logger.WriteUserMetricsToFile();
}

void SetDefaultWritePath(String str)
{
	logger.SetDefaultWritePath(str);
}

void AddButtonPress(String str,float time)
{
	logger.AddButtonPress(str,time);
}
