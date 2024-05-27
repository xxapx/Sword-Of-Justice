using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldStone : MonoBehaviour
{

    public GameObject Music, Player, UI, PauseButton;

    public Animator animator;

    public AudioSource SRC;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.GetComponent<PlayerDamaged>().disablePlayerControls();
            Player.GetComponent<Animator>().enabled = false;
            UI.gameObject.SetActive(false);
            PauseButton.gameObject.SetActive(false);
            Music.gameObject.SetActive(false);
            SRC.Play();
            animator.SetBool("Resize", true);
            StartCoroutine(loadEndScreen(1.9f));
        }
    }



    IEnumerator loadEndScreen(float duration) { 

        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(5);

    }
}
