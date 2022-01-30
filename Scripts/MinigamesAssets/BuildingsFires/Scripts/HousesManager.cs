using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts
{
    public class HousesManager : MonoBehaviour
    {

        [SerializeField] private float winTime;
        private House[] leftHouses;
        private House[] rightHouses;
        private float start;
        private int burntCount;
        private bool gameEnded;

        private void Awake()
        {
            start = Time.time;
            leftHouses = transform.GetChild(0).GetComponentsInChildren<House>();
            rightHouses = transform.GetChild(1).GetComponentsInChildren<House>();
        }

        private void Update()
        {
            if (gameEnded) return;
            if (Time.time >= start + winTime)
            {
                gameEnded = true;
                GameplayManager.Current.FinishGame(true);
            }
        }

        public void HouseBurnt()
        {
            gameEnded = true;
            GameplayManager.Current.FinishGame(false);
        }

        public void BurnHouse(bool rightHouse)
        {
            if (gameEnded || burntCount == 4) return;
            bool success;
            do
            {
                success = rightHouse ? rightHouses[Random.Range(0, 3)].BurnDown() : leftHouses[Random.Range(0, 3)].BurnDown();
            } while (!success);
            burntCount++;
        }

        private void HouseFireExtinguished()
        {
            burntCount--;
        }
    }
}
