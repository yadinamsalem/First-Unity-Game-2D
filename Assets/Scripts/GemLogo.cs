using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemLogo : MonoBehaviour
{

    public Camera mainCamera; // Reference to the player's transform
    public float offsetX; // Offset to adjust the X position of each Heart on Scene screen.

    void Start()
    {
    }


    void Update()
    {
        GemsLogoPosition();
    }

    private void GemsLogoPosition()
    {
        // Calculate the X position of the left border of the camera's view
        float cameraWidth = 2.0f * mainCamera.orthographicSize * mainCamera.aspect;
        float leftBorderX = mainCamera.transform.position.x - cameraWidth / 2.0f;

        // Set the heart's & Gems logo new position
        transform.position = new Vector3(leftBorderX + offsetX, transform.position.y, transform.position.z);
    }
}
