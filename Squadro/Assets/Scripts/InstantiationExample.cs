using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstantiationExample : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab1;
    public GameObject myPrefab2;
    public GameObject myPrefab3;
    public GameObject myPrefab4;
    public GameObject myPrefab5;
    public GameObject myPrefab6;
    public GameObject myPrefab7;
    public GameObject myPrefab8;
    public GameObject myPrefab9;
    public GameObject myPrefab10;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab1, new Vector3(13.4f, 3, 31), Quaternion.identity);
        Instantiate(myPrefab2, new Vector3(6.6f, 3, 31), Quaternion.identity);
        Instantiate(myPrefab3, new Vector3(-0.4f, 3, 31), Quaternion.identity);
        Instantiate(myPrefab4, new Vector3(-7.6f, 3, 31), Quaternion.identity);
        Instantiate(myPrefab5, new Vector3(-14.6f, 3, 31), Quaternion.identity);
        Instantiate(myPrefab6, new Vector3(24, 3, 21.4f), Quaternion.Euler (0f, 90f, 0f));
        Instantiate(myPrefab7, new Vector3(24, 3, 14.4f), Quaternion.Euler (0f, 90f, 0f));
        Instantiate(myPrefab8, new Vector3(24, 3, 7.4f), Quaternion.Euler (0f, 90f, 0f));
        Instantiate(myPrefab9, new Vector3(24, 3, 0.4f), Quaternion.Euler (0f, 90f, 0f));
        Instantiate(myPrefab10, new Vector3(24, 3, -6.6f), Quaternion.Euler (0f, 90f, 0f));
    }
}
