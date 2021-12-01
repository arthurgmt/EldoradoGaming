using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partie
{
    public Plateau plateau;
    public Player player1;
    public Player player2;
    private string idPartie;
    public Partie(Plateau plateau, Player player1, Player player2)
    {
        this.plateau = plateau;
        this.player1 = player1;
        this.player2 = player2;
    }
}
