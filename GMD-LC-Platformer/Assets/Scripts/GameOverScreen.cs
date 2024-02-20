using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
  public void Setup()
  {
        gameObject.SetActive(true);
  }

  public void RestartButton()
    {
        if ("Level 1" == SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene("Level 1");
        }
        else if ("Level 2" == SceneManager.GetActiveScene().name)
        {
            SceneManager.LoadScene("Level 2");
        }

    }


}
