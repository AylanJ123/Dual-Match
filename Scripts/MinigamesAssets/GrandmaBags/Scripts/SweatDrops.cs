using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts
{
    public class SweatDrops : MonoBehaviour
    {

        private GameObject leftDrop;
        private GameObject rightDrop;

        private void Awake()
        {
            leftDrop = transform.GetChild(0).gameObject;
            rightDrop = transform.GetChild(1).gameObject;
        }

        public void PressedRight(bool down)
        {
            rightDrop.SetActive(down);
        }

        public void PressedLeft(bool down)
        {
            leftDrop.SetActive(down);
        }

    }
}
