using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb2d;

    [SerializeField] public Animator animator;

    public int maxHeath = 100;
    int currentHealth;

    bool hurt = false;

    private bool isfacingRight = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHeath;
    }

    private void Update()
    {
        
        animator.SetBool("Run", false);
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print("Distance:  " + distToPlayer);

        if (distToPlayer < agroRange && distToPlayer >3.12f && hurt == false)
        {
            ChasePlayer();
            //print("Distance:  " + distToPlayer);
        }
        else if(distToPlayer == 3.12f || distToPlayer > agroRange) 
        {
            stopChasingPlayer();
            
        }
    }

    public void takeDamage(int damage){
        hurt = true;
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

         if (currentHealth <= 0){
            Dead();
        }
    }


    void Dead(){
        animator.SetBool("Death", true);

        GetComponent<BoxCollider2D>().size = new Vector2(0.5f, 0.01f);
        GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.06f);

        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
   

    void ChasePlayer()
    {
        animator.SetBool("Run", true);
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            if (isfacingRight == true)
            {
                flip();
            }
        }
        else if(transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            
            if(isfacingRight == false) {
                flip();
            }
        }
    }

    void stopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        animator.SetBool("Run", false);
        hurt = false;
    }

    void flip()
    {
        isfacingRight = !isfacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
