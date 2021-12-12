using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField create;
    public InputField join;

    public void CreateRoom()// do something when the game already exists.
    {
        PhotonNetwork.CreateRoom(create.text);
    }

    public void JoinRoom() // if the room does not exist create one.
    {
        PhotonNetwork.JoinRoom(join.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("NetPartie");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
