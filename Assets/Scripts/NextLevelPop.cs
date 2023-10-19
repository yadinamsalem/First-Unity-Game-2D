using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelPop : MonoBehaviour
{
    public float displayTime = 3.5f; // Adjust the duration you want the message to display.
    public Text popUpText;
   

    void Start()
    {
        popUpText.enabled = false;
    }

    void Update()
    {
     
    }

    public void ShowMessage(string message)
    {
        popUpText.text = message;
        popUpText.enabled = true;
        Invoke("HideMessage", displayTime);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Jump to Next Level
    }

    private void HideMessage()
    {
        popUpText.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Jump to Next Level

    }
}
