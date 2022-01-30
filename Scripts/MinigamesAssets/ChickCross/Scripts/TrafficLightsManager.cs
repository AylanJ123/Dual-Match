using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts.ChickCross
{
    public class TrafficLightsManager : ChickCrossManager<TrafficLight>
    {

        private void Start()
        {
            currentIndex = 1;
            Switch();
        }

        protected override void Activated(TrafficLight element)
        {
            element.TurnOn();
        }

        protected override void Selected(TrafficLight element)
        {
            element.ChangeSelection(true);
        }

        protected override void Deselected(TrafficLight element)
        {
            element.ChangeSelection(false);
        }
    }
}
