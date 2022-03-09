using UnityEngine;

namespace ZombieHunter.ZInputSystem
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "Configs/InputConfig")]
    public class InputConfig : ScriptableObject
    {
        public int RotateModifier;
        public int DelayPerRotate;
        public float TopPrimaryThumbstickRotateLim;
        public float LowPrimaryThumbstickRotateLim;
    }
}
