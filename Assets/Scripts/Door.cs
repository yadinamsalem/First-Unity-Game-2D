using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public UnityEvent OnAnimationEnd;
    Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorAnimator.SetBool("Door Open", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            // Animation of "Door Opening" has ended
            // Notifu others that door opened
/*            if (OnAnimationEnd != null)
            {
                OnAnimationEnd.Invoke();
            }*/
            // First wait to the player to step out the Door

            // Close the Door
            doorAnimator.SetBool("Door Open", false);

        }
    }
}
