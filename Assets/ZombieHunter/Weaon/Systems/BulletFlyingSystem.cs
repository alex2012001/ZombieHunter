using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;
using ZombieHunter.MovementSystem.Components;

namespace ZombieHunter.Weaon
{
    public class BulletFlyingSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<ModelData, BulletData> _bulletFilter = null;
        
        private readonly BulletConfig _bulletConfig = null;

        private float _damage;
        private float _speed;
        private int _timeToDestroy;

        private GameObject _entity;
       
        
        private bool _timerIsStart;
       
        public void Init()
        {
           foreach (var i in _bulletFilter)
            {
                _damage = _bulletConfig.Damage;
                _speed = _bulletConfig.Speed;
                _timeToDestroy = _bulletConfig.DestroyDelay;
                DelayToDestroy();
            }
        }

        public void Run()
        {
            foreach (var i in _bulletFilter)
            {
                ref var transform = ref _bulletFilter.Get1(i).ModelTransform;
                _speed = _bulletConfig.Speed;
                transform.Translate(new Vector3(0,0,_speed) * Time.deltaTime);
                if (!_timerIsStart)
                {
                    _timerIsStart = true;
                    _entity = transform.gameObject;
                    DelayToDestroy();
                }
            }
        }
        
        private async void DelayToDestroy()
        {
            Debug.Log("start");
            await Task.Delay(_bulletConfig.DestroyDelay * 1000);
            _timerIsStart = false;
            GameObject.Destroy(_entity);
            Debug.Log("end");
           
        }
    }
}