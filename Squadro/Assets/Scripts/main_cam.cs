using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_cam : MonoBehaviour
{
    public float s = 0.5f;//sensitivity
    //deplacer la camera
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))// si click gauche
        {
            transform.Rotate(new Vector3(0, 0, Input.GetAxis("Mouse X") * s));//on tourne le plateau 
        }
    }
}
