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

    // Start is called before the first frame update
    void Start()
    {

    }

    //Gestion du nombre de case à parcourir 
    void Update()
    {
        // cas0: si le pion arrive au bout du plateau le retourner

        if (joueur == 1)//rotation joueur 1
        {
            float pos = this.transform.position.z;
            pos -= 1.2f;
            if (MovedCase == 6 && !rotated)
            {//Rotation
                this.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                this.transform.position = new Vector3(-24f, 3f, (float)pos);
                this.rotated = true;
            }
        }
        else // rotation joueur 2
        {
            float pos =  this.transform.position.x;
            pos += 1.2f;
            if (MovedCase == 6 && !rotated)
            {
                //Rotation
                this.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                this.transform.position = new Vector3((float)pos, 3f, -17f);
                this.rotated = true;
            }
        }
        
        
        
        // cas1: ne pas dépasser du plateau
        if (NbCase + MovedCase > 6)
            NbCase = MovedCase - 6;
       

        //cas2: si un pion adverse est sur la case d'arrivée du pion

    }

}
