using Modules.ObjectManagement.Scripts.Pools;
using SpaceInvaders.Enemies;

namespace SpaceInvaders.Transport
{
    public sealed class EnemyPool : ComponentPool<EnemyAI>
    {
        public EnemyPool(EnemyAI prefab) : base(prefab)
        {
        }
        
        protected override void OnSpawn(EnemyAI enemy)
        {
            base.OnSpawn(enemy);

            enemy.Reset();
            enemy.Destroyed += Return;
        }

        protected override void OnDespawn(EnemyAI enemy)
        {
            base.OnDespawn(enemy);
            
            enemy.Destroyed -= Return;
        }
    }
}