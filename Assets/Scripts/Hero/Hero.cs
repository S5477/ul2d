using UnityEngine;

namespace Hero
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speedX;
        [SerializeField] private float _jumpForce;
        [SerializeField] private LayerCheck _layerCheck;
        
        private Vector2 _direction;

        private Rigidbody2D _rb;
    
        // Update is called once per frame

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            _rb.velocity = new Vector2(_direction.x * _speedX, _rb.velocity.y);
        }

        private void Jump()
        {
            bool isJump = _direction.y > 0f;

            if (isJump)
            {
                if (_layerCheck.IsTouchingLayer)
                {
                    _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse );
                }
            } else if (_rb.velocity.y > 0)
            {
                var velocity = _rb.velocity;
                _rb.velocity = new Vector2(velocity.x, velocity.y * 0.5f);
            }
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
  
    }

}
