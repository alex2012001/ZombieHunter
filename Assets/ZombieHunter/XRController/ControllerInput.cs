using System;
using UnityEngine;

namespace ZombieHunter.VRController
{
    public class ControllerInput : MonoBehaviour
    {
        public Action RIndexTrigger;
        public Action LIndexTrigger;
        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                RIndexTrigger?.Invoke();
            }
            
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                LIndexTrigger?.Invoke();
            }
        }
    }
}
