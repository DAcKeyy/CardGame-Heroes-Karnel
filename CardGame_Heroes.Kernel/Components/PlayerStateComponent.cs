namespace CardGame_Heroes.Kernel.Components
{
    public struct PlayerStateComponent : IPlayerState
    {
        public PlayerStates PlayerState { get; set; }
        public int MoveOrder {  get; set; }
    }
}
