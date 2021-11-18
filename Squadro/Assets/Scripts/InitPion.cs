using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPion : MonoBehaviour
{
    public int NbCase; // Nombre de case à parcourir au prochain coup
    public int MovedCase = 0; // Cases parcourues par le pion 0 - 6

    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Pion1") | CompareTag("Pion5") | CompareTag("Pion6") | CompareTag("Pion10")) { NbCase = 1; }
        else if (CompareTag("Pion2") | CompareTag("Pion4") | CompareTag("Pion7") | CompareTag("Pion9")) { NbCase = 3; }
        else { NbCase = 2; }
        
    }

    //Gestion du nombre de case à parcourir 
    void Update()
    {
        // cas0: si le pion arrive au bout du plateau le retourner


        // cas1: ne pas dépasser du plateau
        NbCase = (NbCase + MovedCase) % 6;

        //cas2: si un pion adverse est sur la case d'arrivée du pion

    }

}
