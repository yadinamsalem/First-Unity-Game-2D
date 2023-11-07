using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action<Collision2D> BombCollisionEvent;

    // Start is called before the first frame update


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BombCollisionEvent?.Invoke(collision);
            Destroy(gameObject);
        }

    }
}
