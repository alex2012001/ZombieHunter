using UnityEngine.AI;
using Wave.Enemy;

namespace ZombieHunter.Wave.Enemy
{
    public class EnemyFollowPlayer 
    {
        private readonly NavMeshAgent _navMeshAgent;
        private readonly EnemyConfig _config;

        public EnemyFollowPlayer(NavMeshAgent navMeshAgent, EnemyConfig config)
        {
            _navMeshAgent = navMeshAgent;
            _config = config;
            
            SetParametrs();     
        }

        private void SetParametrs()
        {
            _navMeshAgent.speed = _config.Speed;
            _navMeshAgent.angularSpeed = _config.AngularSpeed;
            _navMeshAgent.stoppingDistance = _config.StoppingDistance;
        }

        public void FollowPlayer()
        { 
            //_navMeshAgent.destination = PlayerParameters.PlayerTransform.position;
        }
        
    }
}

