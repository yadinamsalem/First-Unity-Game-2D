using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float heartOffsetX;

    private void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + heartOffsetX, transform.position.y, transform.position.z);
        }
    }
}
