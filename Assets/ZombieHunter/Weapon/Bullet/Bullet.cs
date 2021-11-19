using System.Threading.Tasks;
using UnityEngine;

namespace Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int delayToDestroy;
        
        private void Update()
        {
            transform.Translate(transform.forward* speed);
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
