using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _CoinAnimatorCfg;
        [SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<LevelObjectView> _coinViews;
        [SerializeField] private GeneratorLevelView _genView;


        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private PlayerController _playerController;
        private CameraController _cameraController;
        private CannonAimController _cannon;
        public BulletEmitterController _bulletEmitterController;
        private CoinsManager _coinsManager;
        private GeneratorController _levelGenerator;

        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _CoinAnimatorCfg = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");

            _coinAnimator = new SpriteAnimatorController(_CoinAnimatorCfg);

            _playerAnimator = new SpriteAnimatorController(_playerConfig);
            _playerController = new PlayerController(_playerView, _playerAnimator);

            _cameraController = new CameraController(_playerView, Camera.main.transform);

            _cannon = new CannonAimController(_cannonView._muzzleTransform, _playerView._transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);

            _coinsManager = new CoinsManager(_playerView, _coinAnimator, _coinViews);

            _levelGenerator = new GeneratorController (_genView);
            _levelGenerator.Init();
        }

        void Update()
        {
            _playerController.Update();
            _cameraController.Update();
            _cannon.Update();
            _bulletEmitterController.Update();

            _coinAnimator.Update();
        }
    }
}