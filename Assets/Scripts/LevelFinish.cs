
using UnityEngine;

public class LevelFinish : MonoBehaviour
{

    public GameObject NextLevelMenu;
    public GameObject PauseButton;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PauseButton.SetActive(false);
            Time.timeScale = 0;
            NextLevelMenu.SetActive(true);
            

        }
    }
}
