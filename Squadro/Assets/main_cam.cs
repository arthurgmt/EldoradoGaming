using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_cam : MonoBehaviour
{
    public float sensitivity=1;
    private GameObject parent;
    //deplacer la camera
    public void move(Vector3 position)
    {
        this.transform.position = position;
    }
    // Start is called before the first frame update
    void Start()
    {
        // position absolue
        move(new Vector3(-10.1387f, 18f, -5.157465f));
    }

    // Update is called once per frame
    void Update()
    {/*
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        this.transform.RotateAround(this.transform.position, -Vector3.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        this.transform.RotateAround(Vector3.zero, this.transform.right, rotateVertical * sensitivity);*/
    }
}
