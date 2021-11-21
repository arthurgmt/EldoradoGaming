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


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        float initialValue = 13.4f;
        for(int i = 0; i < 5; i++)
        {
            Instantiate(myPrefab, new Vector3(initialValue - i * 7, 3, 31), Quaternion.identity).tag = "Pion" + (i+1).ToString();
        }
        initialValue = 21.4f;
        for (int i = 0; i < 5; i++)
        {
            Instantiate(myPrefab, new Vector3(24, 3, initialValue - i * 7), Quaternion.Euler(0f, 90f, 0f)).tag = "Pion" + (i + 6).ToString();
        }
    }

    public void DeplacerPion()
    {
        // Get the NbCase available to use in movement.
        int NbCase = SelectedPion.GetComponent<InitPion>().NbCase;
        // Get 
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
        DisableButton();

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
