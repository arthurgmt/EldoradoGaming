using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public InitPion[] pions = new InitPion[5];
    private int nbPiecesAllerRetour;
    public Player(InitPion[] pions)
    {
        this.nbPiecesAllerRetour = 0;
        this.pions = pions;
    }

    public InitPion getPionWithIndex(int i)
    {
        return this.pions[i];
    }

    public bool incrementerNbPiecesAndTest()
    {
        return ++this.nbPiecesAllerRetour == 1;
    }

    public int getNbPieces()
    {
        return this.nbPiecesAllerRetour;
    }

    public InitPion getInitPionWithInfo(int ligne, int colonne)
    {
        for (int i = 0; i < 5; i++)
            if (pions[i].ligne == ligne && pions[i].colonne == colonne)
                return pions[i];
        return null;
    }

    //public abstract void deplacerPion();
}
