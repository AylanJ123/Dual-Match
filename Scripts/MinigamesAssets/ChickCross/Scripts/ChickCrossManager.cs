using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts.ChickCross
{
    public abstract class ChickCrossManager<T> : MonoBehaviour
    {

        [SerializeField] protected List<T> managedElements;
        protected int currentIndex;

        public void Switch()
        {
            Deselected(managedElements[currentIndex]);
            currentIndex++;
            if (currentIndex == managedElements.Count) currentIndex = 0;
            Selected(managedElements[currentIndex]);
        }

        public void Activate()
        {
            Activated(managedElements[currentIndex]);
        }

        protected abstract void Selected(T element);
        protected abstract void Deselected(T element);
        protected abstract void Activated(T element);

    }
}
