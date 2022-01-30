using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts.ChickCross
{
    public class Street : MonoBehaviour
    {

        [SerializeField] private Vector3 streetRotation;
        [SerializeField] private Vector2 streetVelocity;
        [SerializeField] private GameObject carPrefab;
        private GameObject bubble;

        private void Start()
        {
            bubble = transform.GetChild(0).gameObject;
        }

        public void SpawnCar()
        {
            GameObject car = GameObject.Instantiate(carPrefab, null);
            car.transform.position = transform.position;
            car.transform.eulerAngles = streetRotation;
            car.GetComponent<Car>().SpeedUp(streetVelocity);
        }

        public void ChangeSelection(bool on)
        {
            bubble.SetActive(on);
        }

    }
}
