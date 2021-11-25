using UnityEngine;
using UnityEngine.AI;
using ZombieHunter.Player;

public class EnemyAi : MonoBehaviour
{
   private NavMeshAgent _navMeshAgent;

   private void Awake()
   {
       _navMeshAgent = GetComponent<NavMeshAgent>();
   }

   private void Update()
   {
       _navMeshAgent.destination = PlayerParameters.PlayerTransform.position;
   }
}

