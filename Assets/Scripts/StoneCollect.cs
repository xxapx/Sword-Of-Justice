using UnityEngine;

public class StoneCollect : MonoBehaviour
{

    public AudioSource PickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp.Play();
            this.gameObject.SetActive(false);
        }
    }

}
