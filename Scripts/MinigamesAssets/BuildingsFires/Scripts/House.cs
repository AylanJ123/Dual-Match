using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts
{
    public class House : MonoBehaviour
    {

        private bool burnt;

        // Start is called before the first frame update
        void Start()
        {

        }

        public bool BurnDown()
        {
            if (burnt) return false;
            else
            {
                burnt = true;
                return true;
            }
        }
    }
}
