using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPion : MonoBehaviour
{
    public int NbCase; // Nombre de case à parcourir au prochain coup
    public int MovedCase = 0; // Cases parcourues par le pion 0 - 6
    private float x_position=-18;
    //private float pos=0.0;
    private float z_position= -11;
    private GameObject[] pions_x =  new GameObject[5];
    private GameObject[] pions_z = new GameObject[5];
    private GameObject[] s;
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Pion1") | CompareTag("Pion5") | CompareTag("Pion6") | CompareTag("Pion10")) { NbCase = 1; }
        else if (CompareTag("Pion2") | CompareTag("Pion4") | CompareTag("Pion7") | CompareTag("Pion9")) { NbCase = 3; }
        else { NbCase = 2; }

        for (int i=6;i<=10;i++){
            
            s=GameObject.FindGameObjectsWithTag("Pion"+(i).ToString());
            
            pions_x[i-6] =s[0];
        }
        for (int i=1;i<=5;i++){
             s=GameObject.FindGameObjectsWithTag("Pion"+(i).ToString());
            pions_z[i-1] =s[0];
        }
    }

    //Gestion du nombre de case à parcourir 
    void Update()
    {
        // cas0: si le pion arrive au bout du plateau le retourner
        
        //déplacement en x
         
        foreach (GameObject Pion in pions_x)
        {   
            double pos ;
            pos = Pion.transform.position.z;
            pos=pos-1.2;
            if (Mathf.Abs(Pion.transform.position.x - x_position)<=0.1){
                //Rotation
            Pion.transform.localRotation=Quaternion.Euler(0f, -90f , 0f);
            Pion.transform.position=new Vector3(-24f, 3f, (float)pos);

            
            }
         }
         
        //Réinitilalisation du nombre de déplacement
        
        // deplacement en Z
        foreach (GameObject Pion in pions_z)
        {   
            double pos ;
            pos = Pion.transform.position.x;
            pos=pos+1.2;
            if (Mathf.Abs(Pion.transform.position.z - z_position)<=0.1){
                //Rotation
            Pion.transform.localRotation=Quaternion.Euler(0f, 180f, 0f);
            
            Pion.transform.position=new Vector3((float)pos, 3f, -17f);
            
            }
         }
        
        
        
        // cas1: ne pas dépasser du plateau
        if (NbCase + MovedCase > 6)
            NbCase = MovedCase - 6;
       

        //cas2: si un pion adverse est sur la case d'arrivée du pion

    }

}
