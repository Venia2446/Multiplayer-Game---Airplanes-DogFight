using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class Lobby_manager_scr : MonoBehaviourPunCallbacks
{

    public TextMeshProUGUI LogText;
    //private int playercount = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        PhotonNetwork.NickName = "Player" + Random.Range(1,10);
        Log("Player's name:" + PhotonNetwork.NickName);
        
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to server");
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }
    public void joinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel("Game");
    }



    private void Log(string massage)
    {
        Debug.Log(massage);
        LogText.text += "\n";
        LogText.text += massage;



    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
