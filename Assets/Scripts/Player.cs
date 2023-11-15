using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;
    float hitDelayTime = 0.35f;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    public GameObject[] hearts; // An array to store the heart objects.
    protected static int currentHealth;
    private int heartsInitialAmount;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();


        heartsInitialAmount = currentHealth = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Attack();
    }

    private void DoorHasOpened()
    {
        // After
        playerAnimator.SetBool("Going Out The Door", true);

    }

    private void Jump()
    {
        bool isJumping = CrossPlatformInputManager.GetButtonDown("Jump");

        if (isJumping && playerRigidBody.velocity.y == 0) // Jump only if key pressed AND not jump already
        {
            Vector2 jumpVelocity = new Vector2(playerRigidBody.velocity.x, jumpSpeed);
            playerRigidBody.velocity = jumpVelocity;
        }
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        Vector2 platerVelocity = new Vector2(controlThrow * runSpeed, playerRigidBody.velocity.y);
        playerRigidBody.velocity = platerVelocity;

        FlipSprite();
        ChangeToRunningAnimation();

    }

    private void Attack()
    {
        bool isAttacking = CrossPlatformInputManager.GetButtonDown("Attack");
        playerAnimator.SetBool("Attack", isAttacking);

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

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            if (currentHealth > 0)
            {
                currentHealth--;
                Destroy(hearts[currentHealth]); // Remove one heart object. (from the end of hearts array)
                playerAnimator.SetBool("Hitted", true);
                Debug.Log("Hitted = true");
                Invoke("GetHit", hitDelayTime);
            }
        }
    }

    private void GetHit()
    {
        bool isHitted = false;
        playerAnimator.SetBool("Hitted", isHitted);
    }

    public int GetCurrentHearts()
    {
        return currentHealth;
    }
}
