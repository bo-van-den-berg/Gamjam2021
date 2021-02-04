using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        EventManager.current.objectDeath += GameOver;
    }

    private void GameOver(GameObject iObject)
    {
        if (iObject == gameObject)
        {
            SceneManager.LoadScene(2);
        }
    }
}
