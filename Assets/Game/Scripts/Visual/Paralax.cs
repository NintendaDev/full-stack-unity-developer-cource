using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceInvaders.Visual
{
    public sealed class Paralax : MonoBehaviour
    {
        [SerializeField, Required] private RawImage _image;
        [SerializeField] private Vector2 _speed = new Vector2(2, 2);

        private Rect _currentRect;

        private void Update()
        {
            _currentRect = _image.uvRect;
            _currentRect.x += _speed.x * Time.deltaTime;
            _currentRect.y += _speed.y * Time.deltaTime;
            _image.uvRect = _currentRect;
        }
    }
}