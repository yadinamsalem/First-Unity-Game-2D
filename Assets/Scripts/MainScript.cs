using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private int GEMS;
    public Text GemCounter;
    private int numberOfGems = 0;
    public NextLevelPop popUpMessage;
    public GreenGem[] gemCollisionNotifier;
    public float displayTime = 2f; // Adjust the duration you want the message to display.


    // Start is called before the first frame update
    void Start()
    {
        GemCounter.text = "Gems : " + numberOfGems;
        popUpMessage = FindObjectOfType<NextLevelPop>();  // Save reference to the Next Level PopUpMessage script.
        GEMS = FindObjectsOfType<GreenGem>().Length;  // Find number of Gems in current level.
        foreach (GreenGem gem in gemCollisionNotifier)
        {
            gem.GemCollectCollisionEvent += OnCollisionOccurred;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfGems == GEMS)//&& popUpMessage.popUpText.enabled == false)
        {
            popUpMessage.ShowMessage("NEXT LEVEL !");
            Invoke("MoveToNextLevel", displayTime);
        }
    }

    private void OnCollisionOccurred(Collision2D collision)
    {
        GemCounter.text = "Gems : " + ++numberOfGems;
        Debug.Log("gem == " + GEMS);
    }

    private void MoveToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Jump to Next Level
    }

}
