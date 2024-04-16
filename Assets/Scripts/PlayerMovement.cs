using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    
 

    //float x;

    //AudioSource audioSource;
    //Rigidbody2D rb2D;

    //void Start(){
      //  audioSource = GetComponent<AudioSource>();
        //rb2D = GetComponent<Rigidbody2D>();
    //}

    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       /*rb2D.velocity = new Vector2(x, rb2D.velocity.y);

       if (rb2D.velocity.x != 0){
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
       }else{
            audioSource.Stop();
       }*/

       if(Input.GetButtonDown("Jump")){
            jump=true;
            animator.SetBool("isJumping", true);
       }
    }

    public void onLand(){
        animator.SetBool("isJumping", false);
    }


    void FixedUpdate(){
        controller.Move(horizontalMove*Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
