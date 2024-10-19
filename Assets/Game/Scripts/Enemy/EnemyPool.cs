using Modules.ObjectManagement.Scripts.Pools;

namespace SpaceInvaders.Enemies
{
    public sealed class EnemyPool : ComponentPool<Enemy>
    {
        public EnemyPool(Enemy prefab) : base(prefab)
        {
        }
        
        protected override void OnSpawn(Enemy enemy)
        {
            base.OnSpawn(enemy);

            enemy.Reset();
            enemy.Died += Return;
        }

        protected override void OnDespawn(Enemy enemy)
        {
            base.OnDespawn(enemy);
            
            enemy.Died -= Return;
        }
    }
}