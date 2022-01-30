using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MinigamesScripts
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Current { get; private set; }

        [SerializeField] private AudioSource bgMusic;
        [SerializeField] private AudioSource firstSFX;
        [SerializeField] private AudioSource secondSFX;

        private void Awake()
        {
            Current = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        public void SwitchBGMusic(AudioClip clip, float volume)
        {
            StartCoroutine(Switch(clip, volume));
        }

        public void PlayFirstSFX(AudioClip clip, float volume)
        {
            firstSFX.PlayOneShot(clip, volume);
        }

        public void PlaySecondSFX(AudioClip clip, float volume)
        {
            secondSFX.PlayOneShot(clip, volume);
        }

        private IEnumerator Switch(AudioClip clip, float volume)
        {
            Tween tween = bgMusic.DOFade(0, .1f).SetEase(Ease.OutExpo);
            yield return tween.WaitForCompletion();
            bgMusic.Stop();
            bgMusic.clip = clip;
            bgMusic.DOFade(volume, .6f).SetEase(Ease.OutExpo);
            bgMusic.Play();
        }

    }
}
