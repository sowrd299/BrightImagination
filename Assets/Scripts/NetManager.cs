using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetManager : MonoBehaviourPunCallbacks
{

    public string worldLevel = "World";
    public byte maxPlayers = 50;


    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // CONNECT TO THE SERVER
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = "1";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster() {
        // ONCE ON THE SERVER, JOIN A ROOM
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        // IF THERE ARE NO ROOMS, JOIN ONE
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayers});
    }

    public override void OnJoinedRoom() {
        // IF YOU ARE THE FIRST PLAYER IN A ROOM, LOAD THE WORLD
        if(PhotonNetwork.CurrentRoom.PlayerCount == 1 && PhotonNetwork.IsMasterClient) {
            PhotonNetwork.LoadLevel(worldLevel);
        }
    }

}
