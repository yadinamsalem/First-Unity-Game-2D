using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Camera mainCamera; // Reference to the player's transform
    public float offsetX; // Offset to adjust the X position of each Heart on Scene screen.
    public Transform player;

    private void Update()
    {
        if (mainCamera != null)
        {
            HeartsPosition();
        }
    }

    private void HeartsPosition()
    {
        // Calculate the X position of the left border of the camera's view
        float cameraWidth = 2.0f * mainCamera.orthographicSize * mainCamera.aspect;
        float leftBorderX = mainCamera.transform.position.x - cameraWidth / 2.0f;
        float offsetY = 8.5f * (Mathf.RoundToInt(player.position.y) / 8.5f);

        // Set the heart's & Gems logo new position
        transform.position = new Vector3(leftBorderX + offsetX, Mathf.Clamp(3.6f + offsetY, 3.6f, 12.5f), transform.position.z);
    }
}
