using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPion : MonoBehaviour
{

    public int NbCase;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Pion1") | CompareTag("Pion5") | CompareTag("Pion6") | CompareTag("Pion10")) { NbCase = 1; }
        else if (CompareTag("Pion2") | CompareTag("Pion4") | CompareTag("Pion7") | CompareTag("Pion9")) { NbCase = 3; }
        else { NbCase = 2; }
        
    }

    
}
