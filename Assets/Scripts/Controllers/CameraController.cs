using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController : MonoBehaviour
    {
        private LevelObjectView _playerView;
        private Transform _playerTransform;
        private Transform _mCamTransform;

        private float _camSpeed = 1.2f;

        private float X;
        private float Y;

        private float offsetY;
        private float offsetX;

        private float _xAxisInput;
        private float _yAxisVelocity;

        public CameraController(LevelObjectView player, Transform camera)
        {
            _playerView = player;
            _playerTransform = _playerView._transform;
            _mCamTransform = camera;
        }

        public void Update()
        {
            _xAxisInput = Input.GetAxis("Horizontal");
            _yAxisVelocity = _playerView._rigidbody.velocity.y;

            if(_xAxisInput>0)
            {
                offsetX = 4;
            }
            else if(_xAxisInput < 0)
            {
                offsetX = -4;
            }
            else
            {
                offsetX = 0;
            }

            if (_yAxisVelocity > 0)
            {
                offsetY = 4;
            }
            else if (_yAxisVelocity < 0)
            {
                offsetY = -4;
            }
            else
            {
                offsetY = 0;
            }

            _mCamTransform.position = Vector3.Lerp(_mCamTransform.position,
                new Vector3(X + offsetX, Y + offsetY, _mCamTransform.position.z),
                Time.deltaTime * _camSpeed);
        }
    }
}
