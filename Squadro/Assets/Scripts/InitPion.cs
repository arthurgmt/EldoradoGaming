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
    public int absoluteLigne, absoluteColonne;
   //
    public void RotateMotionP1()
    {       if (MovedCase == 6 && rotated == false){ 
            this.GetComponent<Animator>().SetBool("action",true);
            this.GetComponent<Animator>().Play("rotation_animation_p1");}
         
    }

    public void RotateMotionP2()

    {   if (MovedCase == 6 && rotated == false)  {  
            this.GetComponent<Animator>().SetBool("action",true);
            this.GetComponent<Animator>().Play("rotation_animation_p2");}
         
    }
      public void DisparitionPion()
    {      if (MovedCase == 6 && rotated == true) {
            this.GetComponent<Animator>().SetBool("action",true);
            this.GetComponent<Animator>().Play("disparition");}
         
    }
}
