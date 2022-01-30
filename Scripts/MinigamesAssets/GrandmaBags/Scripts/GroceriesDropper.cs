using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts
{
    public class GroceriesDropper : MonoBehaviour
    {

        [SerializeField] private GameObject prefab;
        [SerializeField] private AudioClip dropSound;
        [SerializeField] private float fallDistance;
        [SerializeField] private float offSet;

        public void Dropped(float expectedTime, bool righSide)
        {
            float timeTaken = TimeTakenToFall();
            GameObject newObject = GameObject.Instantiate(prefab, null);
            newObject.transform.position = transform.position + new Vector3((righSide ? -1 : 1) * offSet, 0, 0);
            newObject.GetComponent<Rigidbody2D>().gravityScale = -timeTaken / expectedTime;
            StartCoroutine(DelayDestroy(timeTaken, newObject));
        }

        private IEnumerator DelayDestroy(float time, GameObject obj)
        {
            yield return new WaitForSeconds(time);
            SoundManager.Current.PlaySecondSFX(dropSound, .4f);
            GameObject.Destroy(obj);
        }

        private float TimeTakenToFall()
        {
            return Mathf.Sqrt(2 * fallDistance / -Physics2D.gravity.y);
        }

    }
}
