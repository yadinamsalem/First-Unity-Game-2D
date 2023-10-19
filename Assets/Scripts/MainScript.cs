using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    private int GEMS;
    public Text GemCounter;
    private int numberOfGems = 0;
    public NextLevelPop popUpMessage;
    public GreenGem[] gemCollisionNotifier;

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
        }
    }

    private void OnCollisionOccurred(Collision2D collision)
    {
        GemCounter.text = "Gems : " + ++numberOfGems;
        Debug.Log("gem == " + GEMS);
    }
}
