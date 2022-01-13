using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class BulletEmitterController
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;

        private int _currentindex;
        private float _timeTillNextBullet;

        private float _delay = 1;
        private float _startSpeed = 20;

        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach(LevelObjectView bulletView in bulletViews)
            {
                _bullets.Add(new BulletController(bulletView));
            }
        }

        public void Update()
        {
            if(_timeTillNextBullet >0)
            {
                _bullets[_currentindex].Active(false);
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentindex].Throw(_transform.position, -_transform.up * _startSpeed);
                _currentindex++;

                if(_currentindex>=_bullets.Count)
                {
                    _currentindex = 0;
                }    
            }
        }
    }
}