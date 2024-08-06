#include "Logger.h"

std::ofstream LogManager::logFile;
bool LogManager::isLogging = false;

void LogManager::StartLogging(const std::string& filename) {
    if (isLogging) {
        StopLogging(); // 如果已经在记录日志，先停止记录
    }
    logFile.open(filename, std::ios::out | std::ios::trunc); // 使用 std::ios::trunc 清空文件内容
    if (!logFile) {
        throw std::runtime_error("无法打开文件: " + filename);
    }
    isLogging = true;
}

void LogManager::StopLogging() {
    if (!isLogging) return;
    logFile.close();
    isLogging = false;
}

void LogManager::Log(const std::string& message) {
    if (isLogging) {
        logFile << message << std::endl;
    }
}
