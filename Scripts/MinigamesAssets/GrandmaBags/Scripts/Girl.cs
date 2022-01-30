using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinigamesScripts
{
    public class Girl : MonoBehaviour
    {

        [SerializeField] private List<Sprite> sprites;
        private bool dontUpdateMore;
        private SpriteRenderer rend;

        private void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
        }

        public void CheckForChange(float balance)
        {
            if (dontUpdateMore) return;
            float abs = Mathf.Abs(balance);
            bool neg = balance < 0;
            rend.sprite = sprites[(abs < 1 ? 0 : abs < 4 ? 1 : abs < 7 ? 2 : 3) + (neg && abs >= 1 ? 3 : 0)];
        }

        public void Finished()
        {
            if (dontUpdateMore) return;
            rend.sprite = sprites[sprites.Count - 1];
            dontUpdateMore = true;
        }

        public void DroppedBags(bool righSided)
        {
            if (dontUpdateMore) return;
            rend.sprite = sprites[sprites.Count - (righSided ? 2 : 3)];
            dontUpdateMore = true;
        }

    }
}
