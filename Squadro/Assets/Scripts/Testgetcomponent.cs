using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testgetcomponent : MonoBehaviour
{
    public int recupnbcase = -1;
    // Start is called before the first frame update
    void Update()
    {
        recupnbcase  = GameObject.FindWithTag("Pion2").GetComponent<InitPion>().NbCase;   
    }

}
