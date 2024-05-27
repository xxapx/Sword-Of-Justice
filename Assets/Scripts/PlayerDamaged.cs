using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerDamaged : MonoBehaviour
{

    public AudioSource[] SRC;

    Vector2 checkpointPos;

    //Player's health
    int PlayerMaxHealth =4;
    int Health = 4;
    int currentHealth;

    //Health system
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;

    [SerializeField] public Animator animator;

    public GameObject UI;
    public GameObject GameOverMenu;
    public GameObject PauseButton;

    void Start()
    {
        currentHealth = Health;
        checkpointPos = transform.position;
    }

    public float getCurrentHealth() {

        return currentHealth;
    }


    public void HealPlayer() {
        currentHealth += 1;
        if (currentHealth == 4)
        {
            Heart4.SetActive(true);
        }
        else if (currentHealth == 3)
        {
            Heart3.SetActive(true);
        }
        else if (currentHealth == 2)
        {
            Heart2.SetActive(true);
        }
    }

    public void takeDamage(int damage)
    {
            currentHealth -= damage;
            animator.SetTrigger("Hurt");
            if(currentHealth > 0)
            {
                SRC[0].Play();
            }
            if (currentHealth == 3)
            {
                Heart4.SetActive(false);
            }
            else if (currentHealth == 2)
            {
                Heart3.SetActive(false);
            }
            else if (currentHealth == 1)
            {
                Heart2.SetActive(false);
            }
            else if (currentHealth == 0)
            {
                Heart1.SetActive(false);
            }
       

            if (currentHealth <= 0) {
            
                Dead();
                disablePlayerControls();

            }
                
    }


    void Dead()
    {
        SRC[1].Play();
        disablePlayerControls();
        
        animator.SetBool("Death", true);

        Debug.Log(PlayerMaxHealth);
        
        disablePlayerControls();
            
        StartCoroutine(stopDeathAnimation(0.8f));

        gameOver();
    }

    public void CheckpointUpdate(Vector2 pos) {
        checkpointPos = pos;
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);

        transform.position = checkpointPos;

        enablePlayerControls();

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
            takeDamage(1);
            animator.SetFloat("Speed", 0);
            animator.SetBool("isJumping", false) ;
            animator.SetTrigger("Hurt");
            
            disablePlayerControls() ;

            StartCoroutine(Respawn(0.5f));
        }
    }

    void gameOver()
    {
        currentHealth = 4;
        GetComponent<AudioSource>().enabled = false;
        UI.SetActive(false);
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        
    }


    //Disables player scripts
    public void disablePlayerControls()
    {
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<PlayerFightScript>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }

    void enablePlayerControls()
    {
        GetComponent<PlayerControl>().enabled = true;
        GetComponent<PlayerFightScript>().enabled = true;
        GetComponent<Rigidbody2D>().simulated = true;
    }
    
}
