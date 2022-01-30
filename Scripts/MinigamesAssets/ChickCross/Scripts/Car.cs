using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MinigamesScripts.ChickCross
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Car : MonoBehaviour
    {

        [SerializeField] private Vector2 velocity;
        [SerializeField] private List<AudioClip> starts;
        [SerializeField] private AudioClip breakSound;
        [SerializeField] private AudioClip honk;
        private bool crashed;
        private Animator anim;
        private Rigidbody2D rb;

        public void SpeedUp(Vector2 sentVelocity)
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            SoundManager.Current.PlaySecondSFX(starts[Random.Range(0, starts.Count - 1)], .15f);
            rb.velocity = velocity = sentVelocity;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (crashed) return;
            if (!collision.transform.root.CompareTag("TrafficLight")) return;
            SoundManager.Current.PlaySecondSFX(breakSound, .4f);
            Sequence seq = DOTween.Sequence();
            seq.Append(DOTween.To(() => rb.velocity, x => rb.velocity = x, Vector2.zero, .3f));
            seq.AppendInterval(4);
            seq.Append(DOTween.To(() => rb.velocity, x => rb.velocity = x, velocity, .5f));
            seq.Play();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (crashed) return;
            if (!collision.transform.root.CompareTag("Car")) return;
            crashed = true;
            SoundManager.Current.PlaySecondSFX(breakSound, .25f);
            SoundManager.Current.PlaySecondSFX(honk, .15f);
            rb.velocity = Vector2.zero;
            anim.SetTrigger("Crash");
            StartCoroutine(FadeAway());
        }

        private IEnumerator FadeAway()
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(.5f);
            transform.Find("Collision").gameObject.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }

    }
}
