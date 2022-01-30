using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MinigamesScripts
{
    public class GameButton : Button
    {

        public UnityEvent OnStay;
        public UnityEvent OnRelease;
        public UnityEvent OnEnter;
        private bool held;

        private void Update()
        {
            if (held)
            {
                OnStay.Invoke();
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            OnRelease.Invoke();
            held = false;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            held = true;
            OnEnter.Invoke();
        }

    }
}
