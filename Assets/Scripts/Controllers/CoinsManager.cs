using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CoinsManager : IDisposable
    {
        private float _animationSpeed = 10;

        private LevelObjectView _playerView;
        private SpriteAnimatorController _spriteAnimator;
        private List<LevelObjectView> _coinViews;


        public CoinsManager(LevelObjectView PlayerView,SpriteAnimatorController spriteAnimator, List<LevelObjectView> coinViews)
        {
            _playerView = PlayerView;
            _spriteAnimator = spriteAnimator;
            _coinViews = coinViews;

            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (LevelObjectView coinView in coinViews)
            {
                _spriteAnimator.StartAnimation(coinView._spriteRenderer, AnimState.Run, true, _animationSpeed);
            }

        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_coinViews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }

        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
