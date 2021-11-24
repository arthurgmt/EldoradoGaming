using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPion : MonoBehaviour
{
    public int NbCase; // Nombre de case à parcourir au prochain coup
    public int MovedCase = 0; // Cases parcourues par le pion 0 - 6
    public int joueur;// 1 : pour le joueur 1 et 2 : pour le joueur 2
    public int ligne, colonne;// indique la ligne colonne correspondante.
    public bool rotated = false;
    public Vector3 absolutePosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Gestion du nombre de case à parcourir 
    void Update()// ne pas mettre ici de code SVP car ca recharge après chaque frame ce qui rend l'application lourde.
    {
        // cas0: si le pion arrive au bout du plateau le retourner
        // cas1: ne pas dépasser du plateau
        //cas2: si un pion adverse est sur la case d'arrivée du pion
    }

}
