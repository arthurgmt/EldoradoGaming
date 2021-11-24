using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPion : MonoBehaviour
{
    public Material m_base;
    public Material m_selection;
    public bool selected = false;
    public bool shown = false;
    public GameObject Pionwithlowalpha;
    public Plateau plateau;


    // Start is called before the first frame update
    void Start()
    {
        plateau = GameObject.FindWithTag("GameController").GetComponent<Plateau>();
    }

    void OnMouseDown()
    {
        for (int i = 0; i < 5; i++)
        {
            this.plateau.Player1[i].GetComponent<SelectPion>().selected = false;
            this.plateau.Player2[i].GetComponent<SelectPion>().selected = false;
        }
        selected = true;
        plateau.SelectedPion = GameObject.FindWithTag(this.tag);
        plateau.EnableButton();
        // afficher le bouton
    }

    void Update()
    {
        if ((selected == true) && (shown == false)) { ShowMove(); }
        else if ((selected == false) && (shown == true)) { UnShowMove(); }
    }

    void ShowMove()
    {
        shown = true;
        this.GetComponent<Renderer>().material = m_selection;
        InitPion pion = this.plateau.SelectedPion.GetComponent<InitPion>();
        float t = this.transform.rotation.y;
        string tag_p = this.tag + "alpha";
        Debug.Log(pion.NbCase);
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

    void UnShowMove()
    {
        shown = false;
        string tag_p = this.tag + "alpha";
        this.GetComponent<Renderer>().material = m_base;
        Destroy(GameObject.FindWithTag(tag_p));
    }

}
