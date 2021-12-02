using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public GameObject[] pions = new GameObject[5];
    private int nbPiecesAllerRetour; 
    public Player(GameObject[] pions)
    {
        this.nbPiecesAllerRetour = 0;
        this.pions = pions;
    }

    public GameObject getPionWithIndex(int i)
    {
        return this.pions[i];
    }

    public bool incrementerNbPiecesAndTest()
    {
        return ++this.nbPiecesAllerRetour == 4;
    }

    public int getNbPieces()
    {
        return this.nbPiecesAllerRetour;
    }
}
