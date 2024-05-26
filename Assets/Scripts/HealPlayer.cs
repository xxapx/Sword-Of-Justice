using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public AudioSource heal;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Player.GetComponent<PlayerDamaged>().getCurrentHealth() < 4)
            {
                heal.Play();
                Player.GetComponent<PlayerDamaged>().HealPlayer();
                this.gameObject.SetActive(false);
            }
           
            
            
        }
    }

}
