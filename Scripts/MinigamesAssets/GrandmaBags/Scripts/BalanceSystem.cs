using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MinigamesScripts
{
    public class BalanceSystem : MonoBehaviour
    {

        public UnityEvent<float> valueChanged;
        public UnityEvent<bool> lostBalance;
        public UnityEvent finished;
        public UnityEvent<float, bool> cheated;

        [SerializeField] private float minBalanceRise;
        [SerializeField] private float balancePerSecond;
        [SerializeField] private float cheatBalanceAmount;
        [SerializeField] private float cheatCooldown;
        [SerializeField] private float cheatDelay;
        [SerializeField] private float winTime;
        private float start;
        private float currentBalance = 1;
        private float cheatTime;
        private bool stop;

        private void Start()
        {
            start = Time.time;
        }

        private void Update()
        {
            if (stop) return;
            float rise = currentBalance / 2f;
            if (Mathf.Abs(rise) < minBalanceRise) rise = minBalanceRise * (rise < 0 ? -1 : 1);
            currentBalance += rise * Time.deltaTime;
            if (Mathf.Abs(currentBalance) >= 10) LostBalance();
            else if (Time.time >= start + winTime) WonTheGame();
            valueChanged.Invoke(currentBalance);
        }

        public void PressedBalance(int value)
        {
            currentBalance += value * balancePerSecond * Time.deltaTime;
        }

        public void Cheat(bool rightSide)
        {
            if (Time.time < cheatTime) return;
            cheatTime = Time.time + cheatCooldown;
            cheated.Invoke(cheatDelay, rightSide);
            StartCoroutine(DropBalance(rightSide));
        }

        private void WonTheGame()
        {
            stop = true;
            finished.Invoke();
            GameplayManager.Current.FinishGame(true);
        }

        private void LostBalance()
        {
            stop = true;
            lostBalance.Invoke(currentBalance > 0);
            GameplayManager.Current.FinishGame(false);
        }

        private IEnumerator DropBalance(bool rightSide)
        {
            yield return new WaitForSeconds(cheatDelay);
            currentBalance += (rightSide ? 1 : -1) * cheatBalanceAmount;
        }

    }
}
