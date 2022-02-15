using UnityEngine;

namespace ZombieHunter.PlayerInputSystem
{
    [CreateAssetMenu(fileName = "PlayerInputConfig", menuName = "Configs/PlayerInputConfig")]
    public class PlayerInputConfig : ScriptableObject
    {
        public int RotateModifier;
        public int DelayPerRotate;
        public float TopPrimaryThumbstickRotateLim;
        public float LowPrimaryThumbstickRotateLim;
    }
}
