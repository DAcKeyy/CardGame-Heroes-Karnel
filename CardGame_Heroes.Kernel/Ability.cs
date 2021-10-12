using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Mechanics;

namespace CardGame_Heroes.Kernel
{
    public abstract class Ability
    {
        public readonly int Id, ManaCost;
        public readonly Mechanic mechanic;

        protected Ability(int id, int manaCost, Mechanic mechanic)
        {
            Id = id;
            ManaCost = manaCost;
            this.mechanic = mechanic;
        }

        public virtual void Resolve(EcsEntity user, EcsEntity target) { }
        public virtual void Resolve(EcsEntity user, EcsEntity[] targets) { }
    }
}
