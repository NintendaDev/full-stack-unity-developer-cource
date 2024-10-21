using Modules.ObjectManagement.Scripts.Pools;

namespace SpaceInvaders.Weapons.Bullets
{
    public sealed class BulletPool : ComponentPool<Bullet>
    {
        public BulletPool(Bullet prefab) : base(prefab)
        {
        }

        protected override void OnSpawn(Bullet bullet)
        {
            base.OnSpawn(bullet);

            bullet.Hit += Return;
        }

        protected override void OnDespawn(Bullet bullet)
        {
            base.OnDespawn(bullet);
            
            bullet.Hit -= Return;
        }
    }
}