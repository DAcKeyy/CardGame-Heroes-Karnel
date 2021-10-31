using System;

namespace CardGame_Heroes.Kernel.Logs
{
    public static class Logger
    {
        public static event Action<string> LogRecorded = delegate { };
        private static uint logStep;

        public static void WriteLog(IMomento momento)
        {
            LogRecorded($"{momento.GetMoment}");
            //System.IO.Write $"[{logStep++}] - {momento.GetMoment}"
        }
    }
}
