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
        Debug.Log(p);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void deplacerPion()
    {
        
    }
}
