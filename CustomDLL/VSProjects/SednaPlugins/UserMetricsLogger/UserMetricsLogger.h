#pragma once
#include "PluginSettings.h"

#include "Structs.h"

#include <vector>

#define NUM_LOGGERS 2
class PLUGIN_API UserMetricsLogger
{
public:

	UserMetricsLogger();

	void WriteUserMetricsToFile();
	void ClearUserMetricsFile(String str);

	void AddButtonPress(String srt);

	void SetDefaultWritePath(String str) {defaultPath = str.data;}
private:

	int id = 0;

	std::vector<MetricLog> logData;
	std::string defaultPath = "LatestUserMetrics.txt";

};

