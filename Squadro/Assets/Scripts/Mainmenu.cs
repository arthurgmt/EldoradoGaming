 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mainmenu : MonoBehaviour
{
    public Button play;
    public Button settings;
    public Button quit;
    public Button createGame;
    public Button joinGame;

    public GameObject settingsWindow;
    public GameObject playingWindow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    }
    public void JoinGame()
    {

    }
}
