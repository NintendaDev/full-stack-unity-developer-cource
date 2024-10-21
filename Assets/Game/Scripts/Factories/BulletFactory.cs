using Modules.ObjectManagement.Factories;
using Modules.ObjectManagement.Scripts.Pools;
using SpaceInvaders.Weapons.Bullets;

namespace SpaceInvaders.Factories
{
    public sealed class BulletFactory : ComponentFactory<Bullet>
    {
        protected override ComponentPool<Bullet> CreatePool() => new BulletPool(Prefab);
    }
}