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
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(13.4f, 3, 31), Quaternion.identity).tag = "Pion1";
        Instantiate(myPrefab, new Vector3(6.6f, 3, 31), Quaternion.identity).tag = "Pion2";
        Instantiate(myPrefab, new Vector3(-0.4f, 3, 31), Quaternion.identity).tag = "Pion3";
        Instantiate(myPrefab, new Vector3(-7.6f, 3, 31), Quaternion.identity).tag = "Pion4";
        Instantiate(myPrefab, new Vector3(-14.6f, 3, 31), Quaternion.identity).tag = "Pion5";
        Instantiate(myPrefab, new Vector3(24, 3, 21.4f), Quaternion.Euler(0f, 90f, 0f)).tag = "Pion6";
        Instantiate(myPrefab, new Vector3(24, 3, 14.4f), Quaternion.Euler(0f, 90f, 0f)).tag = "Pion7";
        Instantiate(myPrefab, new Vector3(24, 3, 7.4f), Quaternion.Euler(0f, 90f, 0f)).tag = "Pion8";
        Instantiate(myPrefab, new Vector3(24, 3, 0.4f), Quaternion.Euler(0f, 90f, 0f)).tag = "Pion9";
        Instantiate(myPrefab, new Vector3(24, 3, -6.6f), Quaternion.Euler(0f, 90f, 0f)).tag = "Pion10";
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
