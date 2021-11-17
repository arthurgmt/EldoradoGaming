using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionMovement : MonoBehaviour
{
    public int nbDeplacement;
    private bool allerSimple = false; // voir si le pion est arrivé a fait sa rotation ou pas.
    private int deplacement = 7;
    public int player;
    public float initialCoordinatesX,initialCoordinatesY,initialCoordinatesZ;
    private PlateauScript p;
    // Start is called before the first frame update
    void Start()
    {
        p = new PlateauScript();
        Debug.Log(p);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void deplacerPion()
    {
        
    }

    public void deplacement_z()
    {
        Vector3 z = new Vector3(0.0f, 0.0f, deplacement);
        transform.localPosition += z;
    }
}
