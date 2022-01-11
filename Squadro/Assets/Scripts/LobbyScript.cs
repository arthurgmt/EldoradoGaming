using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
    private PhotonView photonView;
    // Start is called before the first frame update
    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        photonView = GetComponent<PhotonView>();
    }
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber > 1)
            photonView.RPC(nameof(RPC_loadPlayingRoom), RpcTarget.AllBuffered, new object[] { });
    }

    // Update is called once per frame
    [PunRPC]
    void RPC_loadPlayingRoom()
    {
        PhotonNetwork.LoadLevel("PlayingRoom");
    }
}
