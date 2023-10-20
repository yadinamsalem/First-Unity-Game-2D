using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GreenGem : MonoBehaviour
{
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
