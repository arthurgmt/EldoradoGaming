using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partie:MonoBehaviour
{
    public Plateau plateau;
    public Player player1;
    public Player player2;
    private string idPartie;
    public int tourJoueur;// désigne le tour.

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void setPlayer1(Player p1)
    {
        this.player1 = p1;
    }

    public void setPlayer2(Player p2)
    {
        this.player2 = p2;
    }

}
