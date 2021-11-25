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
        Vector3 v1;
        for(int i = 0; i < 5; i++)
        {
            v1 = new Vector3(24, 3, initialValue - i * 7);
            this.Player1[i] = Instantiate(myPrefab, v1, Quaternion.Euler(0f, 90f, 0f));
            this.Player1[i].tag = "Pion" + (4 - i + 1).ToString();
            this.Player1[i].GetComponent<InitPion>().joueur = 1;
            this.Player1[i].GetComponent<InitPion>().absolutePosition = v1;
            this.Player1[i].GetComponent<InitPion>().ligne = 4 - i + 1;
            this.Player1[i].GetComponent<InitPion>().colonne = 0;
            this.Player1[i].GetComponent<InitPion>().NbCase = arrayOfNbCasesDepart[i];
        }
        initialValue = 13.4f;
        for (int i = 0; i < 5; i++)
        {
            v1 = new Vector3(initialValue - i * 7, 3, 31);
            this.Player2[i] = Instantiate(myPrefab, v1, Quaternion.identity); 
            this.Player2[i].tag = "Pion" + (i + 6).ToString();
            this.Player2[i].GetComponent<InitPion>().joueur = 2;
            this.Player2[i].GetComponent<InitPion>().absolutePosition = v1;
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
        int parcours;
        if (joueur == 1)
        {
            //il faut après verifier les rotations.
            if (!pion.rotated) {
                parcours = colonne + 1;
                while ((parcours <= colonne + NbCase || collision) && parcours <= 6)
                {
                    collision = this.plateau[ligne, parcours];
                    parcours++;
                }
                SelectedPion.transform.Translate(0, 0, -(parcours - colonne - 1) * 7);
                pion.colonne += parcours - colonne - 1;
                pion.MovedCase += parcours - colonne - 1;
            }
            else
            {
				parcours = colonne - 1;
                while ((parcours >= colonne - NbCase || collision) && parcours >= 0) 
                {
                    collision = this.plateau[ligne, parcours];
                    parcours--;
                }
                SelectedPion.transform.Translate(0, 0, -( colonne - parcours - 1) * 7);
                pion.colonne -= colonne - parcours - 1;
                pion.MovedCase += colonne - parcours - 1;
            }
        }
        else {
            if (!pion.rotated)
            {            
                parcours = ligne - 1;
                while ((parcours >= ligne - NbCase || collision) && parcours >= 0)
                {
                    collision = this.plateau[parcours, colonne];
                    parcours--;
                }
                SelectedPion.transform.Translate(0, 0, -(ligne - parcours - 1) * 7);
                pion.ligne -= ligne - parcours - 1;
                pion.MovedCase += ligne - parcours - 1;
            }
            else
            {
                parcours = ligne + 1;
                while ((parcours <= ligne + NbCase || collision) && parcours <= 6)
                {
                    collision = this.plateau[parcours, colonne];
                    parcours++;
                }
                SelectedPion.transform.Translate(0, 0, -(parcours - ligne - 1) * 7);
                pion.ligne += parcours - ligne - 1;
                pion.MovedCase += parcours - ligne - 1;
            }
        }
        this.plateau[pion.ligne, pion.colonne] = true;
        this.plateau[ligne, colonne] = false;
        if(pion.MovedCase == 6)
		{
            if (!pion.rotated)
                this.RotatePion();
            else {
                this.SelectedPion.SetActive(false);
                this.SelectedPion.GetComponent<SelectPion>().UnShowMove();
            } // le pion a fait un tour.
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
            pion.transform.position = new Vector3(-24f, 3f, pos-1f);
            pion.NbCase = this.arrayOfNbCasesRotate[pion.ligne - 1];
        }
        else // rotation joueur 2
        {
            float pos = pion.transform.position.x;
            pion.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            pion.transform.position = new Vector3(pos+1f, 3f, -17f);
            pion.NbCase = this.arrayOfNbCasesRotate[pion.colonne - 1];
        }
        pion.absolutePosition = pion.transform.position;// setter le point absolue du parcours.
        pion.rotated = true;
        pion.MovedCase = 0;
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
