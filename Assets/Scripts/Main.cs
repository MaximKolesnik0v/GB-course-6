using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;


        private SpriteAnimatorController _playerAnimator;
        private PlayerController _playerController;
        private CameraController _cameraController;
        private CannonAimController _cannon;
        public BulletEmitterController _bulletEmitterController;

        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");

            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            _cameraController = new CameraController(_playerView, Camera.main.transform);
            _cannon = new CannonAimController(_cannonView._muzzleTransform, _playerView._transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
        }

        void Update()
        {
            _playerController.Update();
            _cameraController.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
        }
    }
}