using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelPop : MonoBehaviour
{
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
    }

}
