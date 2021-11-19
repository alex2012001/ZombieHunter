using System;
using UnityEngine;

namespace User
{
    public class Player : MonoBehaviour
    {
        private void Awake()
        {
            PlayerParameters.PlayerTransform = transform;
        }
    }
}
