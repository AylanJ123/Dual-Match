using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts.ChickCross
{
    public class StreetsManager : ChickCrossManager<Street>
    {

        [SerializeField] private float cooldown;
        private float spawnTime;

        private void Start()
        {
            currentIndex = 3;
            Switch();
        }

        protected override void Activated(Street element)
        {
            if (Time.time < spawnTime) return;
            spawnTime = Time.time + cooldown;
            element.SpawnCar();
        }

        protected override void Selected(Street element)
        {
            element.ChangeSelection(true);
        }

        protected override void Deselected(Street element)
        {
            element.ChangeSelection(false);
        }

    }
}
