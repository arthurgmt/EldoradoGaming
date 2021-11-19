using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCam : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))// si click gauche
        {
            transform.Rotate(0,speed* Input.GetAxis("Mouse X"), 0);//on tourne le plateau 
        }
    }
}
