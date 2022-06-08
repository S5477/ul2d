using System;
using UnityEngine;
using UnityEngine.Events;

namespace Hero
{
    public class LayerCheck : MonoBehaviour
    {
        [SerializeField] private LayerMask _ground;
        [SerializeField] private LayerMask _outOfLevel;
        [SerializeField] private UnityEvent _event;
        private Collider2D _collider;

        public bool IsTouchingLayer;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            bool outOfLevel = TouchCollider(other, _outOfLevel);

            if (outOfLevel)
            {
                _event?.Invoke();
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            IsTouchingLayer = TouchCollider(other, _ground);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsTouchingLayer = TouchCollider(other, _ground);
        }

        private bool TouchCollider(Collider2D other, LayerMask layer)
        {
            return _collider.IsTouchingLayers(layer);
        }
    }

}
