using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript_Level1 : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerGetInsideFromDoor();

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
}

