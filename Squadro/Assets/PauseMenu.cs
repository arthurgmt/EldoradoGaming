using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gameOnPause = false;
    public GameObject settingsWindow;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameOnPause)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

    }

    public void Paused()
    {
        settingsWindow.SetActive(true);
        //changer le status du jeu
        gameOnPause = true;
    }

    public void Resume()
    {
        settingsWindow.SetActive(false);
        //changer le status du jeu
        gameOnPause = false;
    }
}
