using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import the UI namespace


public class GemsCollected : MonoBehaviour
{
    public Camera mainCamera; // Reference to the player's transform
    public float offsetX; // Offset to adjust the X position of each Heart on Scene screen.
    public Text gemsCollectedCounter;
    public Transform player;
    private int screenHeightCounter;
    private float lastOffsetY;

    void Start()
    {
        screenHeightCounter = 0;
        lastOffsetY = 0;
    }

    void Update()
    {
        GemsLogoPosition();
        InitGemsCollectedCounterText();
    }

    private void GemsLogoPosition()
    {
        // Calculate the X position of the left border of the camera's view
        float cameraWidth = 2.0f * mainCamera.orthographicSize * mainCamera.aspect;
        float leftBorderX = mainCamera.transform.position.x - cameraWidth / 2.0f;
        float cameraHeight = 2.0f * mainCamera.orthographicSize;
        float upperBorderY = mainCamera.transform.position.y + cameraHeight / 2.0f;
        float offsetY = 8.5f * (Mathf.RoundToInt(player.position.y) / 8.5f);

        // Set the heart's & Gems logo new position
        transform.position = new Vector3(leftBorderX + offsetX, Mathf.Clamp(2.8f + offsetY, 3.0f, 11.7f), transform.position.z);
    }

    private void InitGemsCollectedCounterText()
    {
        gemsCollectedCounter.fontSize = 43;
        gemsCollectedCounter.rectTransform.sizeDelta = new Vector2(160.91f, 43.46f);
        gemsCollectedCounter.transform.localScale = new Vector3(0.0871f, 0.0871f, 0.0871f);
        //gemsCollectedCounter.transform.position = new Vector3(-6.3f, 2.95f, 6.66f);
    }

}
