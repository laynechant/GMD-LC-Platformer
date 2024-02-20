using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
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
    }
}
