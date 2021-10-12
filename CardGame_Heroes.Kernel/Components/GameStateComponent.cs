using System.Timers;

namespace CardGame_Heroes.Kernel.Components
{
    public struct GameStateComponent
    {
        public GameStates State {  get; set; }
        public Timer stateTimer {  get; set; }
    }
}
