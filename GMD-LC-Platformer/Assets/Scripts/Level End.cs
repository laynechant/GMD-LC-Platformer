using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ("Level 1" == SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if ("Level 2" == SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene("Level 3");

        }
        else if ("Level 3" == SceneManager.GetActiveScene().name)
        {
            GameOverScreen.Setup();

        }
    }
}
