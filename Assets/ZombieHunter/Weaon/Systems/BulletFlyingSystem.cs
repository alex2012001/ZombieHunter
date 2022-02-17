using System.Threading.Tasks;
using Leopotam.Ecs;
using UnityEngine;

namespace ZombieHunter.Weaon
{
    public class BulletFlyingSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<BulletData> _bulletFilter = null;
        

        private float _speed;
        private int _timeToDestroy;

        private GameObject _entity;
       
        private Transform _transform;

        public void Init()
        {
            foreach (var i in _bulletFilter)
            {
                _speed = _bulletFilter.Get1(i).Speed;
                _timeToDestroy = _bulletFilter.Get1(i).DelayToDestroy;
                _transform = _bulletFilter.Get1(i).Transform; 
                _entity = _transform.gameObject;
                
                DelayToDestroy();
            }
        }

        public void Run()
        {
            foreach (var i in _bulletFilter)
            {
                ref var transform = ref _bulletFilter.Get1(i).Transform;
                transform.Translate(0,0,_speed);
            }
        }
        
        private async void DelayToDestroy()
        {
            await Task.Delay(_timeToDestroy * 1000);
            GameObject.Destroy(_entity);
        }
    }
}