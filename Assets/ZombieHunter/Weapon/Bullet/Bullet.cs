using System.Threading.Tasks;
using UnityEngine;
using Wave.Enemy;
using ZombieHunter.Player;

namespace Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int delayToDestroy;

        [SerializeField] private PlayerConfig playerConfig;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(playerConfig.Damage);
            }
        }
        private void Update()
        {
            transform.Translate(0, 0,speed);
        }
        
        private void Start()
        {
            DelayToDestroy();
        }

        private async void DelayToDestroy()
        {
            await Task.Delay(delayToDestroy*1000);
            Destroy(gameObject);
        }
    }
}
