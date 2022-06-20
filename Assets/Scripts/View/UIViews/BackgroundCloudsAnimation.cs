using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace View.UIViews
{
    public class BackgroundCloudsAnimation : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private float delay;
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 endPosition;
        
        private Sequence _animation;

        private void Awake()
        { 
            StartCoroutine(StartAnimation());
        }

        private IEnumerator StartAnimation()
        {
            yield return new WaitForSeconds(delay);
            _animation = DOTween.Sequence()
                .AppendCallback(() => transform.position = startPosition)
                .Append(transform.DOMove(endPosition, duration))
                .SetLoops(-1, LoopType.Restart);
        }

        private void OnDestroy()
        {
            _animation.Kill();
        }
    }
}