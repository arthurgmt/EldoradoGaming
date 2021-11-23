using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Plateau : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public GameObject SelectedPion;
    public Button confirmButton;

    public GameObject[] Player1 = new GameObject[5];
    public GameObject[] Player2 = new GameObject[5];
    private Dictionary<int, GameObject[]> Dictionary = new Dictionary<int, GameObject[]>();
    private bool[,] plateau = new bool[7, 7];
    private float initialValue = 21.4f;

    private int[] arrayOfNbCasesDepart = new int[]{1,3,2,3,1};
    private int[] arrayOfNbCasesRotate = new int[]{3,1,2,1,3};


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        for(int i = 0; i < 5; i++)
        {
            this.Player1[i] = Instantiate(myPrefab, new Vector3(24, 3, initialValue - i * 7), Quaternion.Euler(0f, 90f, 0f));
            this.Player1[i].tag = "Pion" + (4 - i + 1).ToString();
            this.Player1[i].GetComponent<InitPion>().joueur = 1;
            this.Player1[i].GetComponent<InitPion>().ligne = 4 - i + 1;
            this.Player1[i].GetComponent<InitPion>().colonne = 0;
            this.Player1[i].GetComponent<InitPion>().NbCase = arrayOfNbCasesDepart[i];
        }
        initialValue = 13.4f;
        for (int i = 0; i < 5; i++)
        {
            this.Player2[i] = Instantiate(myPrefab, new Vector3(initialValue - i * 7, 3, 31), Quaternion.identity); 
            this.Player2[i].tag = "Pion" + (i + 6).ToString();
            this.Player2[i].GetComponent<InitPion>().joueur = 2;
            this.Player2[i].GetComponent<InitPion>().ligne = 6;
            this.Player2[i].GetComponent<InitPion>().colonne = i+1;
            this.Player2[i].GetComponent<InitPion>().NbCase = arrayOfNbCasesDepart[i];
        }

        for (int i = 1; i < 6; i++)//faire l'initialisation du plateau.
        {
            plateau[i, 0] = true;
            plateau[6, i] = true;
        }
        Dictionary.Add(1, this.Player1);
        Dictionary.Add(2, this.Player2);
    }

    public void DeplacerPion() // A compléter.
    {
        // Get the NbCase available to use in movement.
        InitPion pion = SelectedPion.GetComponent<InitPion>();
        int NbCase = pion.NbCase;
        int joueur = pion.joueur;
        int ligne = pion.ligne;
        int colonne = pion.colonne;
        SelectedPion.GetComponent<SelectPion>().selected = false;
        bool collision = false;
        if (joueur == 1)
        {
            SelectedPion.transform.Translate(0, 0, -(NbCase * 7));
            //il faut après verifier les rotations.
            /*for (int col = colonne+1;col <= colonne+NbCase || !collision; col++)
            {
                if (this.plateau[ligne, col])
                {
                    collision = true;
                }
                else
                {
                    if(collision == true)
                    {
                        break;
                    }
                }
            }*/
        }
        else { SelectedPion.transform.Translate(0, 0, -(NbCase * 7)); }

        pion.MovedCase += NbCase;
        if(pion.MovedCase == 6)
        {
            this.RotatePion();
        }
        /*if (pion.NbCase + pion.MovedCase > 6)
            pion.NbCase = pion.MovedCase - 6;*/

        SelectedPion = null;
        DisableButton();//désactiver le bouton.

    }

    private void RotatePion()
    {
        InitPion pion = SelectedPion.GetComponent<InitPion>();
        if (pion.joueur == 1)//rotation joueur 1
        {
            float pos = pion.transform.position.z;
            pion.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            pion.transform.position = new Vector3(-24f, 3f, pos-0.95f);
            pion.NbCase = this.arrayOfNbCasesRotate[pion.ligne - 1];
        }
        else // rotation joueur 2
        {
            float pos = pion.transform.position.x;
            pion.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            pion.transform.position = new Vector3(pos+0.95f, 3f, -17f);
            pion.NbCase = this.arrayOfNbCasesRotate[pion.colonne - 1];
        }
        pion.rotated = true;
    }

    public void DisableButton()
    {
        confirmButton.interactable = false;
    }

    public void EnableButton()
    {
        confirmButton.interactable = true;
    }


}
