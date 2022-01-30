using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts.ChickCross
{
    public class TrafficLight : MonoBehaviour
    {

        private Animator anim;
        private GameObject zone;
        private GameObject bubble;
        private bool inProgress;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            zone = transform.GetChild(0).gameObject;
            bubble = transform.GetChild(1).gameObject;
        }

        public void TurnOn()
        {
            if (inProgress) return;
            inProgress = true;
            StartCoroutine(Animate());
        }

        public void ChangeSelection(bool on)
        {
            bubble.SetActive(on);
        }

        private IEnumerator Animate()
        {
            anim.SetTrigger("Stop");
            yield return new WaitForSeconds(.25f);
            zone.SetActive(true);
            yield return new WaitForSeconds(3.99f);
            zone.SetActive(false);
            inProgress = false;
        }

    }
}
