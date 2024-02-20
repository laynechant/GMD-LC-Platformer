using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextDissap : MonoBehaviour
{
    public TextMeshProUGUI Instructions;  //Add reference to UI Text here via the inspector
    private float timeToAppear = .2f;
    private float timeWhenDisappear;

    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        Instructions.enabled = true;
        timeWhenDisappear = Time.time + timeToAppear;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        if (Instructions.enabled && (Time.time >= timeWhenDisappear))
        {
            Instructions.enabled = false;
        }
    }
}
