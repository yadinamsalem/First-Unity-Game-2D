using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        Vector2 platerVelocity = new Vector2(controlThrow * runSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = platerVelocity;

        FlipSprite();
        ChangeToRunningAnimation();

    }

    private void FlipSprite()
    {
        bool runningHorizontaly = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;

        if (runningHorizontaly)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }

    private void ChangeToRunningAnimation()
    {
        bool runningHorizontaly = Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("Running", runningHorizontaly);
    }


}
