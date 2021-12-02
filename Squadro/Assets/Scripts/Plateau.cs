using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Plateau : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public Camera mainCam; // 2d 
    public Camera cam; //3d
    public GameObject myPrefab;
    public GameObject SelectedPion;
    public Button confirmButton;

    //public GameObject[] Player1 = new GameObject[5];
    //public GameObject[] Player2 = new GameObject[5];
    private bool[,] plateau = new bool[7, 7];

    private int[] arrayOfNbCasesDepart = new int[] { 1, 3, 2, 3, 1 };
    private int[] arrayOfNbCasesRotate = new int[] { 3, 1, 2, 1, 3 };

    public int tourJoueur;// désigne le tour.
    public Partie partie;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        float initialValue = 21.4f;
        // Camera Setup
        cam.enabled = true;
        mainCam.enabled = false;

        // Instantiate at position (0, 0, 0) and zero rotation.
        Vector3 v1;
        GameObject[] pionsP1 = new GameObject[5];
        GameObject[] pionsP2 = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            v1 = new Vector3(24, 3, initialValue - i * 7);
            pionsP1[4 - i] = Instantiate(myPrefab, v1, Quaternion.Euler(0f, 90f, 0f));
            pionsP1[4 - i].tag = "Pion" + (4 - i + 1).ToString();
            pionsP1[4 - i].GetComponent<InitPion>().joueur = 1;
            pionsP1[4 - i].GetComponent<InitPion>().absolutePosition = v1;
            pionsP1[4 - i].GetComponent<InitPion>().ligne = 4 - i + 1;
            pionsP1[4 - i].GetComponent<InitPion>().colonne = 0;
            pionsP1[4 - i].GetComponent<InitPion>().NbCase = arrayOfNbCasesDepart[i];
            pionsP1[4 - i].GetComponent<InitPion>().absoluteLigne = 4 - i + 1;
            pionsP1[4 - i].GetComponent<InitPion>().absoluteColonne = 0;
        }
        initialValue = 13.4f;
        for (int i = 0; i < 5; i++)
        {
            v1 = new Vector3(initialValue - i * 7, 3, 31);
            pionsP2[i] = Instantiate(myPrefab, v1, Quaternion.identity);
            pionsP2[i].tag = "Pion" + (i + 6).ToString();
            pionsP2[i].GetComponent<InitPion>().joueur = 2;
            pionsP2[i].GetComponent<InitPion>().absolutePosition = v1;
            pionsP2[i].GetComponent<InitPion>().ligne = 6;
            pionsP2[i].GetComponent<InitPion>().colonne = i + 1;
            pionsP2[i].GetComponent<InitPion>().NbCase = arrayOfNbCasesDepart[i];
            pionsP2[i].GetComponent<InitPion>().absoluteLigne = 6;
            pionsP2[i].GetComponent<InitPion>().absoluteColonne = i + 1;
        }

        for (int i = 1; i < 6; i++)//faire l'initialisation du plateau.
        {
            plateau[i, 0] = true;
            plateau[6, i] = true;
        }
        this.tourJoueur = 1;
        this.partie = new Partie(this, new Player(pionsP1), new Player(pionsP2));
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
        bool sauvCollision = false;
        int parcours, deplacement;
        if (joueur == 1)
        {
            //il faut après verifier les rotations.
            if (!pion.rotated)
            {
                parcours = colonne + 1;
                while ((parcours <= colonne + NbCase || collision) && parcours <= 6)
                {
                    sauvCollision = collision;
                    collision = this.plateau[ligne, parcours];
                    parcours++;
                    if (collision)
                    {
                        resetInitialPosition(this.partie.player2.pions, parcours - 2, ligne, parcours - 1);
                    }
                    else if (sauvCollision)
                        break;
                }
                deplacement = parcours - colonne - 1;
                pion.colonne += deplacement;
            }
            else
            {
                parcours = colonne - 1;
                while ((parcours >= colonne - NbCase || collision) && parcours >= 0)
                {
                    sauvCollision = collision;
                    collision = this.plateau[ligne, parcours];
                    parcours--;
                    if (collision)
                        resetInitialPosition(this.partie.player2.pions, parcours, ligne, parcours + 1);
                    else if (sauvCollision)
                        break;
                }
                deplacement = colonne - parcours - 1;
                pion.colonne -= deplacement;
            }
        }
        else
        {
            if (!pion.rotated)
            {
                parcours = ligne - 1;
                while ((parcours >= ligne - NbCase || collision) && parcours >= 0)
                {
                    sauvCollision = collision;
                    collision = this.plateau[parcours, colonne];
                    parcours--;
                    if (collision)
                        resetInitialPosition(this.partie.player1.pions, parcours, parcours + 1, colonne);
                    else if (sauvCollision)
                        break;
                }
                deplacement = ligne - parcours - 1;
                pion.ligne -= deplacement;
            }
            else
            {
                parcours = ligne + 1;
                while ((parcours <= ligne + NbCase || collision) && parcours <= 6)
                {
                    sauvCollision = collision;
                    collision = this.plateau[parcours, colonne];
                    parcours++;
                    if (collision)
                        resetInitialPosition(this.partie.player1.pions, parcours - 2, parcours - 1, colonne);
                    else if (sauvCollision)
                        break;
                }
                deplacement = parcours - ligne - 1;
                pion.ligne += deplacement;
            }
        }
        pion.MovedCase += deplacement;
        SelectedPion.transform.Translate(0, 0, -deplacement * 7);
        this.plateau[pion.ligne, pion.colonne] = true;
        this.plateau[ligne, colonne] = false;
        if (pion.MovedCase == 6)
        {
            if (!pion.rotated)
                this.RotatePion();
            else
            {
                this.SelectedPion.SetActive(false);
                this.incrementNbPionsAllerRetourPlayer(pion.joueur);
            } // le pion a fait un tour.
        }
        this.SelectedPion.GetComponent<SelectPion>().UnShowMove();
        SelectedPion = null;
        this.tourJoueur = this.tourJoueur == 1 ? 2 : 1;
        DisableButton();//désactiver le bouton.

    }

    private void RotatePion()
    {
        InitPion pion = SelectedPion.GetComponent<InitPion>();
        if (pion.joueur == 1)//rotation joueur 1
        {
            float pos = pion.transform.position.z;
            pion.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            pion.transform.position = new Vector3(-24f, 3f, pos - 1f);
            pion.NbCase = this.arrayOfNbCasesRotate[pion.ligne - 1];
            pion.absoluteColonne = 6;
        }
        else // rotation joueur 2
        {
            float pos = pion.transform.position.x;
            pion.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            pion.transform.position = new Vector3(pos + 1f, 3f, -17f);
            pion.NbCase = this.arrayOfNbCasesRotate[pion.colonne - 1];
            pion.absoluteLigne = 0;
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

    private void resetInitialPosition(GameObject[] playerArray, int index, int ligne, int colonne)
    {
        InitPion pion = playerArray[index].GetComponent<InitPion>();
        Vector3 temp = pion.absolutePosition;
        pion.MovedCase = 0;
        playerArray[index].transform.position = temp;
        this.plateau[ligne, colonne] = false;
        this.plateau[pion.absoluteLigne, pion.absoluteColonne] = true;
        pion.ligne = pion.absoluteLigne;
        pion.colonne = pion.absoluteColonne;
    }

    private void incrementNbPionsAllerRetourPlayer(int joueur)
    {
        bool fin;
        if (joueur == 1)
            fin = this.partie.player1.incrementerNbPiecesAndTest();      
        else
            fin = this.partie.player2.incrementerNbPiecesAndTest();
        if (fin)
        {
            /*Faire un affichage UI*/
            Debug.Log("Player N=" + joueur + " has win");
        }
    }
}
