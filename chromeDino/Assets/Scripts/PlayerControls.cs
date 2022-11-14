using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    bool weJumped;
    bool weDucked;

    [Tooltip("This controls the jumping speed of the dino")]
    [SerializeField]float jumpingSpeed = 8f;

    Rigidbody2D player;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        //initally we are not jumpnig so it is false
        weJumped = false;
        //gets the rigidbody of the object on which the script is attached to
        player = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        //to check if we are ducking
        Duck();

        //this part is the jumping part
        Jump();

        anim.SetBool("isDucking", weDucked);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !weJumped)
        {
            //jumped is true when we jump so that we can get the animation
            weJumped = true;
            Debug.Log("We are jumping");
            player.velocity = new Vector3(0, jumpingSpeed);
        }
       
    }

    private void Duck()
    {
        //this part is the part where we duck
        if (Input.GetKey(KeyCode.DownArrow) && !weJumped)
        {
            weDucked = true;
            Debug.Log("We are ducking");
        }
        else
        {
            weDucked = false;
            Debug.Log("We are not ducking");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("We are on ground");
            weJumped = false;
        }
    }
}
