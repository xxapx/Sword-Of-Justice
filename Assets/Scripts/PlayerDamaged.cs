using System.Collections;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    //Start position
    Vector2 CheckpointPos;

    //Player's health
    int PlayerMaxHealth =5;
    int Health = 6;
    int currentHealth;

    [SerializeField] public Animator animator;

    public GameObject GameOverMenu;
    public GameObject PauseButton;

    void Start()
    {
        currentHealth = Health;
        CheckpointPos = transform.position;
    }


    public void takeDamage(int damage)
    {
        
        if (currentHealth > 0)
        {
            
            currentHealth -= damage;
            animator.SetTrigger("Hurt");

        }

        if (currentHealth <= 0) {
            
            Dead();
            disablePlayerControls();

        }
                
    }


    void Dead()
    {
        disablePlayerControls();
        PlayerMaxHealth -= 2;
        //
        
        animator.SetBool("Death", true);
        //Debug.Log(PlayerMaxHealth);
        if (PlayerMaxHealth > 0)
        {
          
            StartCoroutine(Respawn(0.5f));
        }
        else
        {
            disablePlayerControls();
            
            StartCoroutine(stopDeathAnimation(0.8f));

            gameOver();
        }


    }


    public void CheckpointUpdate(Vector2 pos)
    {
        CheckpointPos = pos;
    }

    //Respawn in starting position
    IEnumerator Respawn(float duration)
    {
        
        yield return new WaitForSeconds(duration);

        animator.SetBool("Death", false);
        transform.position = CheckpointPos;
        
        GetComponent<PlayerControl>().enabled = true;
        GetComponent<PlayerFightScript>().enabled = true;
        GetComponent<Rigidbody2D>().simulated = true;

        currentHealth =  6;
    }

    //Disables the animator
    IEnumerator stopDeathAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.enabled = false;

    }


    //player dies on collition with water
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            PlayerMaxHealth += 1;
            animator.SetFloat("Speed", 0);
            animator.SetBool("isJumping", false) ;
            animator.SetTrigger("Hurt");
            Dead();
            
        }
    }

    void gameOver()
    {
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
    }


    //Disables player scripts
    void disablePlayerControls()
    {
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<PlayerFightScript>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    
}
