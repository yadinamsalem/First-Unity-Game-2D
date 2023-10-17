using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenGem : MonoBehaviour
{

    public Text GemCounter;
    public static int numberOfGems = 0;

    void Start()
    {
        GemCounter.text = "Gems : " + numberOfGems;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle the collision with the player here.
            Debug.Log("Collided with the player!");
            Destroy(gameObject);
            GemCounter.text = "Gems : " + ++numberOfGems;
        }
    }

    public void UpdateText(string newText)
    {
        GemCounter.text = newText;
    }
}
