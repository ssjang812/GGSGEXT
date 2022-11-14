using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;

    private void Awake()
    {
        Debug.Log("Awake");
        lobby = this; //Creates the singleton, lives withing the Main menu scene.
    }

    void Start()
    {
        Debug.Log("Start");
        PhotonNetwork.ConnectUsingSettings(); //Connects to Master photon server.
    }

    public override void OnConnectedToMaster() //Called when app connected to Master photon server
    {
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinRandomRoom();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //Called when failed to join room (no room)
    {
        Debug.Log("Failed to join room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("CreateRoom");
        int randomRoomName = Random.Range(0, 10);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message) //Called when failed to create room (name duplicate)
    {
        Debug.Log("Failed to create room");
        CreateRoom();
    }
}
