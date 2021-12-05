using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Camera : MonoBehaviour
{
    public Button b;
    public Camera mainCam; // 2d 
    public Camera cam; //3d
    // Start is called before the first frame update
    void Start()
    {
        //button setup
        b.onClick.AddListener(Switch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch()
    {
        if (mainCam.enabled)// si 2d
        {
            mainCam.enabled = false;
            cam.enabled = true;
            b.GetComponentInChildren<Text>().text = "3D";
        }
        else
        {
            mainCam.enabled = true;
            cam.enabled = false;
            b.GetComponentInChildren<Text>().text = "2D";
        }
    }
}
