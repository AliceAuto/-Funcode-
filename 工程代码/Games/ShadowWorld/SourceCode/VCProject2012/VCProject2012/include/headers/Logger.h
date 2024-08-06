#ifndef LOGGER_H
#define LOGGER_H

#include <fstream>
#include <string>

class LogManager {
public:
    static void StartLogging(const std::string& filename);
    static void StopLogging();
    static void Log(const std::string& message);

private:
    static std::ofstream logFile;
    static bool isLogging;
};

#endif
