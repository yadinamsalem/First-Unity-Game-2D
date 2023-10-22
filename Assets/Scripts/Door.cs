using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
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
            // Animation has ended

            doorAnimator.SetBool("Door Open", false);

        }
    }
}
