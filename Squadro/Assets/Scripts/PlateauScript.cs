using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauScript : MonoBehaviour
{
    public GameObject[] player1 = new GameObject[5];
    public GameObject[] player2 = new GameObject[5];
    public Dictionary<int,GameObject[]> dictionary= new Dictionary<int,GameObject[]>();
    public bool[,] plateau = new bool[7,7];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < 6; i++)//faire l'initialisation du plateau.
        {
            plateau[i, 0] = true;
            plateau[6, i] = true;
        }
        dictionary.Add(1, this.player1);
        dictionary.Add(2, this.player2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeCoordinates()
    {
        
    }

    Dictionary<int, GameObject[]> getDictionnary()
    {
        return dictionary;
    }
}
