using Leopotam.Ecs;

namespace ZombieHunter.PlayerInputSystem
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private float _moveX;
        private float _moveZ;
        
        private readonly EcsStartup.DevelopMode _devMode = null;
        
        public void Run()
        {
            SetDirection();
            GetControllerAction();
        }

        private void GetControllerAction()
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                ShootRightHand();
            } 
            
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                ShootLeftHand();
            }

            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                Jump();
            }
        }
        private void SetDirection()
        {
            var axis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
            _moveX = axis.x;
            _moveZ = axis.y;
        }
    }
}