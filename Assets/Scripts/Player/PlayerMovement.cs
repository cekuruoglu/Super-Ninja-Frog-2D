using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public float doubleJumpPower = 2f;
    private bool canDouble;
    private float inputDirection;
    public float speed;
    private Rigidbody2D rb;
    public float jumpPower;
    private SpriteRenderer SR;
    private Animator anim;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {

        CheckInput();
    
    }

    private void FixedUpdate()
    {
        Movement();
        if (GroundCheck.isGrounded == false)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
        }
        if (GroundCheck.isGrounded == true)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("DJump", false);
            anim.SetBool("Fall", false);
        }
        if(rb.velocity.y < 0)
        {
            anim.SetBool("Fall", true);
        }
        else if(rb.velocity.y > 0)
        {
            anim.SetBool("Fall", false);
        }
    }

    private void CheckInput ()
    {

       inputDirection = CrossPlatformInputManager.GetAxis("Horizontal");
        if (inputDirection > 0)
            SR.flipX = false;
        else if (inputDirection < 0)
            SR.flipX = true;


        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (GroundCheck.isGrounded) 
            {
                
                canDouble = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                if (canDouble)
                {
                    canDouble = false;
                    rb.velocity = new Vector2(rb.velocity.x, doubleJumpPower);
                    anim.SetBool("DJump", true);
                }

                        
            }
        }

        
    }

    private void Movement()
    {

        rb.velocity = new Vector2 (speed * inputDirection, rb.velocity.y);
        if (rb.velocity.x !=0 )
            anim.SetBool("Run", true);
        else
            anim.SetBool("Run", false);

    }
}
