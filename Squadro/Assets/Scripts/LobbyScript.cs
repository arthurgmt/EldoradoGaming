using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            StartCoroutine(WaitForDisconnect());
        }
    }

    // Update is called once per frame
    [PunRPC]
    void RPC_loadPlayingRoom()
    {
        PhotonNetwork.LoadLevel("PlayingRoom");
    }

    private IEnumerator WaitForDisconnect()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return 0;
        SceneManager.LoadScene("OfficialScene");
    }
}
