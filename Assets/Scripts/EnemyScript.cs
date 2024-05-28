using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public AudioSource Death;

    public bool val;
    [SerializeField] public Animator animator;

    //Player chase
    [SerializeField] Transform player;
    [SerializeField] float agroRange;

    //Move,Edge & Wall Detection
    bool isfacingRight;

    [SerializeField] Transform castPos;
    [SerializeField] float baseCastDist;
        
    Rigidbody2D rb2d;
    public float moveSpeed;

    public float velocityX;

    void Start()
    {     
        isfacingRight =false;
        rb2d = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {        
        velocityX = moveSpeed;

        if(isfacingRight == true)
        {
            velocityX = -moveSpeed;
        }

        //Enemy move
        rb2d.velocity = new Vector2(velocityX, rb2d.velocity.y);
       
        //distance from player
        float distToPlayer = Mathf.Abs(transform.position.x - player.position.x);
        
        isHittingWall();
        isNearEdge();
        
        if (distToPlayer < agroRange && val ==false)
        {
            ChasePlayer(moveSpeed);
        }
        else if(isHittingWall() || isNearEdge())
        {
            stopChasingPlayer();
            if (isfacingRight == false)
            {
                flip();
            }
            else
            {
                flip();
            }
        }
       
    }

    //Chase player
    void ChasePlayer(float chaseSpeed)
    {
        
        chaseSpeed += 6.5f;
        animator.SetBool("Chase", true);
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(chaseSpeed, 0);
            
            if (isfacingRight == true)
            {
                flip();
            }
        }
        else if (transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-chaseSpeed, 0);

            if (isfacingRight == false)
            {
                flip();
            }
        }
    }

    public void stopChasingPlayer()
    {
        rb2d.velocity = new Vector2(velocityX, 0);
        animator.SetBool("Chase", false);
    }



    //Check if enemy is hitting a wall
    bool isHittingWall()
    {
        val = false;

        float castDist = baseCastDist;

        if(isfacingRight == false)
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

    //Check if enemy is near the edge
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



    //Take damage by player
    public void takeDamage()
    {
        Death.Play();
        GetComponent<EnemyAttackPlayer>().enabled = false;
        stopChasingPlayer();
        animator.SetBool("Death", true);

        Invoke("DestroyEnemy", 0.3f);
        
    }
    
    public void DestroyEnemy() {
        Destroy(gameObject);
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
