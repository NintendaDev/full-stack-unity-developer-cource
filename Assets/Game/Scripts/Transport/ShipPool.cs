using Modules.ObjectManagement.Scripts.Pools;

namespace SpaceInvaders.Transport
{
    public sealed class ShipPool : ComponentPool<Ship>
    {
        public ShipPool(Ship prefab) : base(prefab)
        {
        }
        
        protected override void OnSpawn(Ship ship)
        {
            base.OnSpawn(ship);

            ship.Reset();
            ship.Destroyed += Return;
        }

        protected override void OnDespawn(Ship ship)
        {
            base.OnDespawn(ship);
            
            ship.Destroyed -= Return;
        }
    }
}