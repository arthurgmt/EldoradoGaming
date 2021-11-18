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


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        for (int i = 1; i <= 10; i++)
        {
            string p = "Pion" + i.ToString();
            GameObject.FindWithTag(p).GetComponent<SelectPion>().selected = false;
        }
        selected = true;
        // afficher le bouton
        GameObject.FindWithTag("GameController").GetComponent<Plateau>().SelectedPion = GameObject.FindWithTag(this.tag);

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
        int n = GameObject.FindWithTag(this.tag).GetComponent<InitPion>().NbCase;
        float t = this.transform.rotation.y;
        string tag_p = this.tag + "alpha";

        // check the rotation
        if ( t == 0)
        {
            float x = this.transform.position.x;
            float z = this.transform.position.z - (n * 7);
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.identity).tag = tag_p;
        }else if (t > 0 && t < 90)
        {
            float x = this.transform.position.x - (n * 7);
            float z = this.transform.position.z;
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.Euler(0f, 90f, 0f)).tag = tag_p;
        }else if (t < 0 && t > -90)
        {
            float x = this.transform.position.x + (n * 7);
            float z = this.transform.position.z;
            Instantiate(Pionwithlowalpha, new Vector3(x, 3, z), Quaternion.Euler(0f, -90f, 0f)).tag = tag_p;
        }else
        {
            float x = this.transform.position.x;
            float z = this.transform.position.z + (n * 7);
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
