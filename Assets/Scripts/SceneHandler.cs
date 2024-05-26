using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject LevelFinishMenu;
    public GameObject PauseButton;
    [SerializeField] GameObject Player;


    //Changes the scene based on ID given in the editor
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1;
    }

    //Is called if pause button is pressed
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        PauseButton.SetActive(false);    
    }

    //Is called if continue button on pause screen is pressed
    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        PauseButton.SetActive(true);
    }

}
