using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GreenGem : MonoBehaviour
{
    public Text GemCounter;
    public static int numberOfGems = 0;
    public Vector2 offset = new Vector2(0, 0); // The offset to move the Text.
    public NextLevelPop popUpMessage; // Reference to the Next Level PopUpMessage script.
    public event Action<Collision2D> GemCollectCollisionEvent;

    void Start()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GemCollectCollisionEvent?.Invoke(collision);
            Destroy(gameObject);
        }

    }

}
