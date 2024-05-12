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


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHeath;
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {

        }
    }

    public void takeDamage(int damage){
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
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }else if(transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
    }



}
