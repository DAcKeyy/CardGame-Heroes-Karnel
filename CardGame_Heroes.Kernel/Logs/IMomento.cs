using System;

namespace CardGame_Heroes.Kernel.Logs
{
    public interface IMomento
    {
        public string State { get; }
        public DateTime Date { get; }
        public string GetMoment();
    }
}
