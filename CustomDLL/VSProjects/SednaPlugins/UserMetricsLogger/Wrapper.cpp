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

void AddButtonPress(String str)
{
	logger.AddButtonPress(str);
}
