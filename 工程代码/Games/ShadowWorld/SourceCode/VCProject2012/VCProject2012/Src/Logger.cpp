#include "Logger.h"

std::ofstream LogManager::logFile;
bool LogManager::isLogging = false;

void LogManager::StartLogging(const std::string& filename) {
    if (isLogging) {
        StopLogging(); // ����Ѿ��ڼ�¼��־����ֹͣ��¼
    }
    logFile.open(filename, std::ios::out | std::ios::trunc); // ʹ�� std::ios::trunc ����ļ�����
    if (!logFile) {
        throw std::runtime_error("�޷����ļ�: " + filename);
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
