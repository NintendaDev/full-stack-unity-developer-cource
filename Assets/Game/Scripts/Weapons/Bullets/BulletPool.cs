using Modules.ObjectManagement.Scripts.Pools;

namespace SpaceInvaders.Weapons.Bullets
{
    public sealed class BulletPool : ComponentPool<Bullet>
    {
        public BulletPool(Bullet prefab) : base(prefab)
        {
        }

        protected override void OnSpawn(Bullet enemy)
        {
            base.OnSpawn(enemy);

            enemy.Hit += Return;
        }

        protected override void OnDespawn(Bullet enemy)
        {
            base.OnDespawn(enemy);
            
            enemy.Hit -= Return;
        }
    }
}