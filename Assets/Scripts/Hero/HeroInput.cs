using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hero
{
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        private HeroAction _heroAction;

        private void Awake()
        {
            _heroAction = new HeroAction();
            _heroAction.Hero.HorizontalMovement.performed += OnHorizontalMovement;
            _heroAction.Hero.HorizontalMovement.canceled  += OnHorizontalMovement;
        }

        private void OnEnable()
        {
            _heroAction.Enable();
        }

        private void OnHorizontalMovement(InputAction.CallbackContext ctx)
        {
            var direction = ctx.ReadValue<Vector2>();
     
            _hero.SetDirection(direction);
        }
    }
}

