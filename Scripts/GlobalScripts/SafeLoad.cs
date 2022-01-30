using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinigamesScripts
{
    public class SafeLoad : MonoBehaviour
    {
        private void Start()
        {
            if (!GameManager.Current) SceneManager.LoadScene(0);
        }
    }
}
