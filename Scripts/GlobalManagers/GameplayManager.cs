using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using MyBox;
using DG.Tweening;

namespace MinigamesScripts
{
    public class GameplayManager : MonoBehaviour
    {

        public UnityEvent gameEnding;

        [SerializeField] private SceneReference nextScene;
        [SerializeField] private AudioClip newMusic;
        [SerializeField] private float newMusicVolume;
        private Animator anim;

        public static GameplayManager Current { get; set; }

        private void Awake()
        {
            Current = this;
            anim = GetComponent<Animator>();
        }

        private void Start()
        {
            CutManager.Current.Open();
            SoundManager.Current.SwitchBGMusic(newMusic, newMusicVolume);
        }

        public void FinishGame(bool godWins)
        {
            gameEnding.Invoke();
            anim.SetTrigger(godWins ? "WonGod" : "WonDevil");
            StartCoroutine(WaitForEnd());
        }

        private IEnumerator WaitForEnd()
        {
            yield return new WaitForSeconds(1.24f);
            CutManager.Current.Close();
            yield return new WaitForSeconds(0.75f);
            DOTween.KillAll(false);
            SceneManager.LoadScene(nextScene.SceneName);
        }

    }
}
