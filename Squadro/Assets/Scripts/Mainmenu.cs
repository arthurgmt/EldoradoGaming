using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Button play;
    public Button settings;
    public Button quit;
    public Button createGame;
    public Button joinGame;

    public GameObject settingsWindow;
    public GameObject playingWindow;


    public void Play()
    {
        play.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        playingWindow.gameObject.SetActive(true);

    }

    public void Settings()
    {
        settingsWindow.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.gameObject.SetActive(false);
    }

    public void ClosePlaying()
    {
        playingWindow.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void CreateGame()
    {
        SceneManager.LoadScene("Tour_Management");
    }
    public void JoinGame()
    {

    }
}
