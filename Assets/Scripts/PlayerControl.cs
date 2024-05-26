using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public AudioSource[] audioSRC;

    public Animator animator;


    public float speed;
    public float jumpForce;
    public float moveInput;

    private Rigidbody2D rb;

    private bool isfacingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;


    private int extraJumps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update() {


        if(isGrounded == true)
        { 
            extraJumps = 1;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps>0) {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
            audioSRC[1].Play();
            audioSRC[0].Stop();
            extraJumps--;
        }else if (Input.GetKeyDown(KeyCode.Space) && extraJumps==0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }
        if (moveInput == 0)
        {
            audioSRC[0].Play();
        }

    }

    void FixedUpdate()
    {
        //if player is on the ground disable jump animation
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

        //move player
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
       
       

        //Character flip
        if (isfacingRight ==  false && moveInput>0 ) {
            flip();
        }else if (isfacingRight == true && moveInput<0) {
            flip();
        }
    }

    

    void flip()
    {
        isfacingRight = !isfacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
