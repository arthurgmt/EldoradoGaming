using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber > 1)
            PhotonNetwork.LoadLevel("PlayingRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
