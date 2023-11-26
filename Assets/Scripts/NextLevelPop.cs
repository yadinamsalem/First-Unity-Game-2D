using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class NextLevelPop : MonoBehaviour
{
    public Text popUpText;
    public Camera mainCamera; // Reference to the Scene main camera
    public Transform player; // Reference to the Player transform details


    void Start()
    {
        popUpText.enabled = false;
        popUpText.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        // Calculate the X position of the center of the camera's view
        // Calculate the Y position of the center of the camera's view

        float cameraHeight = Camera.main.orthographicSize * 2f;
    }

    void Update()
    {

    }

    public void ShowMessage(string message)
    {
        //Set the text in the middle of Main Camera view.
        float cameraWidth = 2.0f * mainCamera.orthographicSize * mainCamera.aspect;
        float centerY = Camera.main.transform.position.y;

        popUpText.transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
        //popUpText.transform.position = new Vector3(cameraWidth / 2f, centerY, popUpText.transform.position.z);
        popUpText.text = message;
        popUpText.enabled = true;
    }

}
