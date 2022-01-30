using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinigamesScripts
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Current { get; private set; }

        private void Awake()
        {
            Current = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SceneManager.LoadScene(1);
        }

    }
}
