using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MinigamesScripts.ChickCross
{
    public class Chick : MonoBehaviour
    {

        [SerializeField] private float movementCheck;
        [SerializeField] private float returnIncrease;
        [SerializeField] private float endPointStep;
        [SerializeField] private Vector2 endPoint;
        [SerializeField] private AudioClip dieSound;

        private bool shouldntMove;
        private float accum;
        private float nextChance;
        private float progress;
        private Vector2 startPoint;
        private Animator anim;
        private Tween jumpTween;

        private void Start()
        {
            anim = GetComponent<Animator>();
            startPoint = transform.position;
        }

        private void Update()
        {
            if (shouldntMove) return;
            accum += Time.deltaTime;
            if (accum >= movementCheck)
            {
                accum = 0;
                if (nextChance >= Random.value)
                {
                    Move(false);
                    nextChance = 0;
                }
                else
                {
                    Move(true);
                    nextChance += returnIncrease;
                }
            }
        }

        private void Move(bool forward)
        {
            Vector2 pos = Vector2.Lerp(startPoint, endPoint, progress += (forward ? 1 : -1) * endPointStep);
            transform.eulerAngles = new Vector3(0, forward ? 0 : 180, 0);
            jumpTween = transform.DOJump(pos, .065f, 2, movementCheck * .8f).OnComplete(() => CheckWin());

        }

        private void CheckWin()
        {
            if (!shouldntMove && progress >= 1)
            {
                shouldntMove = true;
                GameplayManager.Current.FinishGame(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.transform.root.CompareTag("Car")) return;
            Die();
        }

        private void Die()
        {
            if (shouldntMove) return;
            shouldntMove = true;
            SoundManager.Current.PlaySecondSFX(dieSound, .3f);
            anim.ResetTrigger("Die");
            anim.SetTrigger("Die");
            jumpTween.Pause();
            GameplayManager.Current.FinishGame(false);
        }

    }
}
