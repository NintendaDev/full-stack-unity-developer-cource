using Modules.ObjectManagement.Factories;
using Modules.ObjectManagement.Scripts.Pools;
using SpaceInvaders.Transport;

namespace SpaceInvaders.Factories
{
    public sealed class ShipFactory : ComponentFactory<Ship>
    {
        protected override ComponentPool<Ship> CreatePool() => new ShipPool(Prefab);
    }
}