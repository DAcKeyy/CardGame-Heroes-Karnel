using System;

namespace CardGame_Heroes.Kernel.Logs
{
    public class Snapshot : IMomento
    {
        public string State { get; }
        public DateTime Date { get; }

        public Snapshot(string state)
        {
            State = state;
            Date = DateTime.Now;
        }

        public string GetMoment() => $"[{Date}] -- {State}.";
    }
}
