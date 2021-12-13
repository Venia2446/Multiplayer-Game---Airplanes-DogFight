using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviourPunCallbacks
{
    public GameObject Airplane1Prefub;
    public GameObject Airplane2Prefub;
    private GameObject GameClone_Airplane1Prefub, GameClone_Airplane2Prefub;
    private Player[] plist;
    private bool startGame = true;


    void Start()
    {
        plist = PhotonNetwork.PlayerList;

        if (plist.Length == 1)
        {
            Vector3 Airplane1SpawnPossition = new Vector3(-49f, 0f, -20f);
            GameClone_Airplane1Prefub = PhotonNetwork.Instantiate(Airplane1Prefub.name, Airplane1SpawnPossition, Quaternion.identity);
            
        }
        else
        {
            Vector3 Airplane2SpawnPossition = new Vector3(49f, 0f, -20f);
            GameClone_Airplane2Prefub = PhotonNetwork.Instantiate(Airplane2Prefub.name, Airplane2SpawnPossition, Quaternion.identity);       
        } 
    }



    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnLeftRoom() // текущий игрок покинул комнату
    {
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    }
}
