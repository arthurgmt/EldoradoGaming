using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    private const byte MAX_PLAYERS = 2;
    public InputField create;
    public InputField join;
    // Start is called before the first frame update

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {

    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void CreateRoom()// do something when the game already exists.
    {
        PhotonNetwork.CreateRoom(create.text, new RoomOptions { MaxPlayers = MAX_PLAYERS });
    }

    public void JoinRoom() // if the room does not exist create one.
    {
        if (join.text.Length != 0)
            PhotonNetwork.JoinRoom(join.text);
        else
            PhotonNetwork.JoinRandomRoom(null, MAX_PLAYERS);
    }

    public override void OnJoinedRoom() 
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError($"Joining random room failed becuse of {message}");

        PhotonNetwork.CreateRoom(null, new RoomOptions
        {
            MaxPlayers = MAX_PLAYERS,
        });
    }

    internal bool IsRoomFull()
    {
        return PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers;
    }
}
