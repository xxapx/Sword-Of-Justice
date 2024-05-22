using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] Transform player;
    /*[SerializeField]*/ float agroRange = 20.5f;
    [SerializeField] float moveSpeed;

    [SerializeField] Transform castPoint;

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
        float distToPlayer = Mathf.Abs(transform.position.x - player.position.x);

        //float distToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("Dist  " + distToPlayer);
        
        if (distToPlayer < agroRange && distToPlayer > 6f && hurt == false)
        {
            ChasePlayer();
            
        }
        else if (distToPlayer < 6f || distToPlayer > agroRange)
        {
            stopChasingPlayer();
        }else  // if (hurt == true)
        {
            stopChasingPlayer();
        }


    }


    public void takeDamage(int damage){
        if (currentHealth > 0)
        {
            hurt = true;
            currentHealth -= damage;

            animator.SetTrigger("Hurt");
        }

         if (currentHealth <= 0){
            Dead();
        }
    }


    void Dead(){
        animator.SetBool("Death", true);

        GetComponent<CapsuleCollider2D>().size = new Vector2(0.01f, 0.01f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0f, 0.1f);

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
