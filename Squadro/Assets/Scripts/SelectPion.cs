using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPion : MonoBehaviour
{
    public Material m_base;
    public Material m_selection;
    public bool selected = false;
    public GameObject Pionwithlowalpha;
    public Plateau plateau;
    
    // Start is called before the first frame update
    void Start()
    {
        plateau = GameObject.FindWithTag("Plateau").GetComponent<Plateau>();
    }

    void OnMouseDown()
    {
        Debug.Log(this.GetComponent<InitPion>().joueur);
        Debug.Log(this.plateau.getPartie().tourJoueur);
        if (this.plateau.getPartie().tourJoueur == this.GetComponent<InitPion>().joueur)
        {
            if (this.plateau.getPartie().tourJoueur == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    this.plateau.getPartie().player1.pions[i].GetComponent<SelectPion>().selected = false;
                    this.plateau.getPartie().player1.pions[i].GetComponent<SelectPion>().UnShowMove();
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                   
                    this.plateau.getPartie().player2.pions[i].GetComponent<SelectPion>().selected = false;
                    this.plateau.getPartie().player2.pions[i].GetComponent<SelectPion>().UnShowMove();
                }
            }
            selected = true;
            plateau.SelectedPion = GameObject.FindWithTag(this.tag);
            plateau.EnableButton();
            ShowMove();
        }
    }

    void Update()
    {
    }

    void ShowMove()
    {
        this.GetComponent<Renderer>().material = m_selection;
        InitPion pion = this.plateau.SelectedPion.GetComponent<InitPion>();
        float t = this.transform.rotation.y;
        string tag_p = this.tag + "alpha";
        int deplacement = pion.MovedCase + pion.NbCase <= 6 ? pion.NbCase : 6 - pion.MovedCase; 
        // check the rotation
        if (pion.joueur == 1 && !pion.rotated)
        {
            float x = this.transform.position.x - (deplacement * 7);
            float z = this.transform.position.z;
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.Euler(0f, 90f, 0f)).tag = tag_p;
        }   
        else if (pion.joueur == 1 && pion.rotated)
        {
            float x = this.transform.position.x + (deplacement * 7);
            float z = this.transform.position.z;
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.Euler(0f, -90f, 0f)).tag = tag_p;
        }
        else if(pion.joueur == 2 && !pion.rotated)
        {
            float x = this.transform.position.x;
            float z = this.transform.position.z - (deplacement * 7);
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.identity).tag = tag_p;
        }
        else
        {
            float x = this.transform.position.x;
            float z = this.transform.position.z + (deplacement * 7);
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.Euler(0f, 180f, 0f)).tag = tag_p;
        }
    }

    public void UnShowMove()
    {
        string tag_p = this.tag + "alpha";
        this.GetComponent<Renderer>().material = m_base;
        Destroy(GameObject.FindWithTag(tag_p));
    }

}
