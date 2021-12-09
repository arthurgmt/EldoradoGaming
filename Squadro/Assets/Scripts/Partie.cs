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
    public Partie(Plateau plateau, Player player1, Player player2)
    {
        this.plateau = plateau;
        this.player1 = player1;
        this.player2 = player2;
        this.tourJoueur = 1;
    }

    private void Start()
    {
        this.plateau = GetComponent<Plateau>();
    }

    private void Update()
    {
        
    }

}
