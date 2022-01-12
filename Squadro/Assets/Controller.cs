using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(DataSaver.loadData<KeyData>("keyData") != null)
        {
            SceneManager.LoadScene("OfficialScene");
        }
    }
}
