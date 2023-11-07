using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript_Level1 : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Player player;
    public NextLevelPop popUpMessage;
    public Canvas messageCanvas;
    private float displayTime = 2f; // Adjust the duration you want the message to display.

    // Start is called before the first frame update
    void Start()
    {
        popUpMessage = FindObjectOfType<NextLevelPop>();  // Save reference to the Next Level PopUpMessage script.
        messageCanvas.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        messageCanvas.transform.position = new Vector3(0.06f, -0.04f, 0f);
        playerSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGetInsideFromDoor();
        CheckPlayerStatus();
    }

    private void CheckPlayerStatus()
    {
        if (player.GetCurrentHearts() == 0)
        {
            popUpMessage.ShowMessage("YOU LOST !");
            Invoke("RestartScene", displayTime);
        }
    }

    private void PlayerGetInsideFromDoor()
    {
        if (doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !playerSprite.enabled)
        {
            //Door opened succesfuly.
            playerSprite.enabled = true;
            playerAnimator.SetBool("Going Out The Door", true);

        }
        else if (playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && playerAnimator.GetBool("Going Out The Door"))
        {
            playerAnimator.SetBool("Going Out The Door", false);
        }
    }

    private void RestartScene()
    {
        // Reload the current scene.
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}

