using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public bool val;
    [SerializeField] public Animator animator;

    //Take Damage
    bool hurt = false;

    //Player chase
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    //[SerializeField] float chaseSpeed;



    //Move,Edge & Wall Detection
    const string LEFT = "left";
    const string RIGHT = "right";
    bool isfacingRight;
    string facingDirection;

    [SerializeField] Transform castPos;
    [SerializeField] float baseCastDist;
        
    Rigidbody2D rb2d;
    public float moveSpeed;
    
    

    void Start()
    {     
        isfacingRight =false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        

    }


    



    private void FixedUpdate()
    {
        
        float velocityX = moveSpeed;

        if(isfacingRight == true)
        {
            velocityX = -moveSpeed;
        }
        //distance from player
        float distToPlayer = Mathf.Abs(transform.position.x - player.position.x);
        isHittingWall();
        isNearEdge();
        if (distToPlayer < agroRange && hurt == false && val==false)
        {
            
            if (val == false)
            {
                ChasePlayer(velocityX);
            }
            
            Debug.Log("Val in 1st if  " + val);
        }
        else if(isHittingWall() || isNearEdge())
        {
            
            stopChasingPlayer(velocityX);
            if (facingDirection == LEFT)
            {
                flip();
            }
            else
            {
                flip();
            }
        }


        //Enemy move
        rb2d.velocity = new Vector2(velocityX, rb2d.velocity.y);
    }


    void ChasePlayer(float chaseSpeed)
    {

        //animator.SetBool("Run", true);
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(chaseSpeed + 3, 0);
            if (isfacingRight == true)
            {
                flip();
            }
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-chaseSpeed +3, 0);

            if (isfacingRight == false)
            {
                flip();
            }
        }
    }

    void stopChasingPlayer(float speed)
    {
        rb2d.velocity = new Vector2(speed, 0);
        // animator.SetBool("Run", false);
        hurt = false;
        

    }



    //Check if enemy is hitting a wall
    bool isHittingWall()
    {
        val = false;

        float castDist = baseCastDist;

        if(facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;
        }

        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = true;
        }
        else { 
            val = false;
        }
        
        return val;
    }


    bool isNearEdge()
    {
        val = false;

        float castDist = baseCastDist;

        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.black);

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))
        {
            val = false;
        }
        else
        {
            val = true;
        }
        
        return val;
    }


    //Flip enemy
    void flip()
    {
        isfacingRight = !isfacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
