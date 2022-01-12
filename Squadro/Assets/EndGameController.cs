using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public Camera camPlayer1;
    public Camera camPlayer2;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        int joueur = PlayerPrefs.GetInt("joueur");
        if(joueur == 1)
        {
            camPlayer1.enabled = true;
            camPlayer2.enabled = false;
            text.text = "Player 1 has won !";
        }
        else if(joueur == 2)
        {
            camPlayer1.enabled = false;
            camPlayer2.enabled = true;
            text.text = "Player 2 has won !";
        }
        else
        {
            Debug.LogError("There is an error");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
