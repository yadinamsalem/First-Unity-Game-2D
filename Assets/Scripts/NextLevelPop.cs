using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelPop : MonoBehaviour
{
    public Text popUpText;
    public Camera mainCamera; // Reference to the Scene main camera


    void Start()
    {
        popUpText.enabled = false;
        popUpText.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        // Calculate the X position of the center of the camera's view
        float cameraWidth = 2.0f * mainCamera.orthographicSize * mainCamera.aspect;
        popUpText.transform.position = new Vector3(cameraWidth / 2f, popUpText.transform.position.y, popUpText.transform.position.z);
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
