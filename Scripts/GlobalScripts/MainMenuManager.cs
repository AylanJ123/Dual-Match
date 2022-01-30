using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

namespace MinigamesScripts
{
    public class MainMenuManager : MonoBehaviour
    {

        [SerializeField] private List<MaskableGraphic> hideElements;
        private bool alreadyGoing;

        public void GoNext()
        {
            if (alreadyGoing) return;
            alreadyGoing = true;
            StartCoroutine(GoDelayed());
        }

        private IEnumerator GoDelayed()
        {
            foreach (MaskableGraphic element in hideElements)
            {
                Color color = element.color;
                color.a = 0;
                DOTween.To(() => element.color, x => element.color = x, color, .25f);
            }
            yield return new WaitForSeconds(.25f);
            SceneManager.LoadScene(2);
        }

    }
}
