using System;

namespace WPFTest.Infraestructure.Common
{
    public static class Logger
    {
        public static void Log(MessageType messageType, string msg, int statusCode)
        {
            Log(messageType, msg, statusCode);
        }

        public static void Log(MessageType messageType, Exception ex, string msg, int statusCode)
        {
            Log(messageType, ex, msg, statusCode);
        }

        public static void Log(MessageType messageType, Exception ex, int statusCode)
        {
            Log(messageType, ex, string.Empty, statusCode);
        }

        public static void Log(MessageType messageType, string msg)
        {
            Log(messageType, msg, 0);
        }

        public static void Log(MessageType messageType, Exception ex)
        {
            Log(messageType, ex, 0);
        }

        public static void Log(MessageType messageType, Exception ex, string msg)
        {
            Log(messageType, ex, msg, 0);
        }

        public static void LogMsg(MessageType messageType, string msg)
        {
            Log(messageType, msg);
        }

        public static void LogError(Exception ex)
        {
            Log(MessageType.Unexpected, ex);
        }

        public static void LogError(string msg, Exception ex)
        {
            Log(MessageType.Unexpected, ex, msg);
        }

        public static void LogInfo(string msg)
        {
            Log(MessageType.Expected, msg);
        }

        public static void LogErrorDB(Exception ex)
        {
            Log(MessageType.DB_Unexpected, ex);
        }

        public static void LogInfoDB(string msg)
        {
            Log(MessageType.DB_Expected, msg);
        }

        public static void LogErrorEmail(Exception ex)
        {
            Log(MessageType.Email_Unexpected, ex);
        }

        public static void LogErrorEmail(string msg, Exception ex)
        {
            Log(MessageType.Email_Unexpected, ex, msg);
        }

        public static void LogInfoEmail(string msg)
        {
            Log(MessageType.Email_Monitorable, msg);
        }

        public static void LogErrorLogin(string msg, Exception ex)
        {
            Log(MessageType.Login_Unexpected, ex, msg);
        }

        public static void LogInfoLogin(string msg)
        {
            Log(MessageType.Login_Expected, msg);
        }

        public static void LogMonitorableLogin(string msg, Exception ex)
        {
            Log(MessageType.Login_Monitorable, ex, msg);
        }

    }

}
