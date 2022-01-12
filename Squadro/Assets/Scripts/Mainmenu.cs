using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public Button play;
    public Button settings;
    public Button quit;

    public GameObject settingsWindow;
    public GameObject playingWindow;


    public void Play()
    {
        Screen.SetResolution(1920,1080,true);
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
        SettingsMenu menu = settingsWindow.GetComponent<SettingsMenu>();
        settingsWindow.gameObject.SetActive(false);
        GameConf gameConf = new GameConf(menu.speed, menu.volume);
        DataSaver.saveData<GameConf>(gameConf, "gameConf");
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
}
