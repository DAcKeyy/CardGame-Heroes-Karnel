namespace CardGame_Heroes.Kernel
{
    public abstract class GameState
    {
        public string Name {  get; protected set; }
        public bool IsFinished {  get; protected set; }

        public virtual void Init()
        {

        }

        public abstract void Run();  
    }
}
