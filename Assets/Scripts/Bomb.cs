using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public event Action<Collision2D> BombCollisionEvent;
    Animator bombAnimator;
    private float delayTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        bombAnimator = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool isBombing = true;
            bombAnimator.SetBool("Touch Bomb", isBombing);
            BombCollisionEvent?.Invoke(collision);
            Invoke("DestroyBomb", delayTime);
            //bombAnimator.SetBool("Touch Bomb", isBombing);

        }

    }

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }
}
