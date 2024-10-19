using System;
using Sirenix.OdinInspector;
using SpaceInvaders.Movement;
using SpaceInvaders.Attributes;
using UnityEngine;

namespace SpaceInvaders.Weapons.Bullets
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField, Required] private Mover _mover;
        [SerializeField] private Color _color = Color.red;
        [SerializeField, MinValue(0)] private float _damage;
        [SerializeField] private LayerMask _hitLayerMask = ~1;
        
        private SpriteRenderer _renderer;
        private bool _isInitialized;

        public event Action<Bullet> Hit;

        public void Initialize()
        {
            if (_isInitialized)
                return;
            
            _renderer = GetComponent<SpriteRenderer>();
            _mover.Initialize();
            _renderer.color = _color;

            _isInitialized = true;
        }

        public void Launch(Vector2 direction) => _mover.Move(direction);

        private void OnCollisionEnter2D(Collision2D collision) => ProcessColission(collision.gameObject);

        private void OnTriggerEnter2D(Collider2D collision) => ProcessColission(collision.gameObject);

        private void ProcessColission(GameObject colissionObject)
        {
            if ((_hitLayerMask.value & (1 << colissionObject.layer)) == 0)
                return;
            
            if (colissionObject.TryGetComponent(out IDamageable damageable)) 
                damageable.TakeDamage(_damage);
            
            Hit?.Invoke(this);
        }
    }
}