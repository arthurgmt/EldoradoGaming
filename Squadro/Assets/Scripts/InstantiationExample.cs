using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstantiationExample : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public GameObject SelectedPion;


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

    }

    public void DeplacerPion()
    {
        int NbCase = SelectedPion.GetComponent<InitPion>().NbCase;
        float t = SelectedPion.transform.rotation.y;

        SelectedPion.GetComponent<SelectPion>().selected = false;

        if (t >= 0 && t < 90)
        {   
             SelectedPion.transform.Translate(0, 0, -(NbCase * 7));
        }
        else { SelectedPion.transform.Translate(0, 0, NbCase * 7); }
        SelectedPion.GetComponent<InitPion>().MovedCase += NbCase;

        SelectedPion = null;
        // désactiver le bouton
    }

}
