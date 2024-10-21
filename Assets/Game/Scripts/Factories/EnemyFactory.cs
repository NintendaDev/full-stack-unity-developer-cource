using Modules.ObjectManagement.Factories;
using Modules.ObjectManagement.Scripts.Pools;
using SpaceInvaders.Enemies;
using SpaceInvaders.Transport;

namespace SpaceInvaders.Factories
{
    public sealed class EnemyFactory : ComponentFactory<EnemyAI>
    {
        protected override ComponentPool<EnemyAI> CreatePool() => new EnemyPool(Prefab);
    }
}