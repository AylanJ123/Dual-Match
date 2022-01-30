using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MinigamesScripts
{
    public class CutManager : MonoBehaviour
    {
        public static CutManager Current { get; private set; }

        [SerializeField] private GameObject canvas;
        [SerializeField] private RectTransform rightSide;
        [SerializeField] private RectTransform leftSide;

        private void Awake()
        {
            Current = this;
            GameObject.DontDestroyOnLoad(gameObject);
            GameObject.DontDestroyOnLoad(canvas);
        }

        public void Open()
        {
            TweenTo(rightSide, 1, true);
            TweenTo(leftSide, 0, true);
        }

        public void Close()
        {
            TweenTo(rightSide, 0, false);
            TweenTo(leftSide, 1, false);
        }

        private void TweenTo(RectTransform t, float anchorEnd, bool goingOut)
        {
            DOTween.Complete(t);
            t.DOPivotY(anchorEnd, .5f).SetEase(goingOut ? Ease.OutQuad : Ease.InQuad);
        }

    }
}
