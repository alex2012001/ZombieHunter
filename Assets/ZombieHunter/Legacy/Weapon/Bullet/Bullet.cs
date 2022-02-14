using System.Threading.Tasks;
using UnityEngine;
using Wave.Enemy;

namespace Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int delayToDestroy;

        private float _damage;
        
        public void SetParameters(float damage)
        {
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(_damage);
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
