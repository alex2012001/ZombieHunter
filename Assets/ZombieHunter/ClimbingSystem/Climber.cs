using System;
using UnityEngine;

namespace ZombieHunter.ClimbingSystem
{
    public class Climber : MonoBehaviour
    {
        public float Gravity = 45f;
        public float Sensivity = 45f;

        private Hand _currentHand = null;
        private CharacterController _controller = null;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        private void Update()
        {
            CalculateMovement();
        }

        private void CalculateMovement()
        {
            var movement = Vector3.zero;

            if (_currentHand)
            {
                movement += _currentHand.Delta * Sensivity;
            }

            if (movement == Vector3.zero)
            {
                movement.y -= Gravity * Time.deltaTime;
            }

            _controller.Move(movement * Time.deltaTime);
        }

        public void SetHand(Hand hand)
        {
            if (_currentHand)
            {
                _currentHand.RealisePoint();
            }

            _currentHand = hand;
        }

        public void ClearHand()
        {
            _currentHand = null;
        }
    }
}