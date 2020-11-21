#include "UserMetricsLogger.h"
#include <fstream>
#include <cstdlib>
#include <time.h>

UserMetricsLogger::UserMetricsLogger()
{
	id = rand();
}

void UserMetricsLogger::WriteUserMetricsToFile()
{
	srand(time(0));
	id = rand();
	std::ofstream file(defaultPath + "LatestUserMetrics.txt");
	file.clear();

	file << "METRICS LOG ENTRY ID " + std::to_string(id) << "\n";
	file << "\Button Presses:\n";
	for (size_t i = 0; i < logData.size(); i++) {


		file << logData[i].data << "\n";

	}

	file.close();
}

void UserMetricsLogger::ClearUserMetricsFile(String str)
{
	std::ofstream file(str.data);
	file.clear();
	file.close();
}

void UserMetricsLogger::AddButtonPress(String srt)
{
	logData.push_back(MetricLog(id, srt.data));
}
