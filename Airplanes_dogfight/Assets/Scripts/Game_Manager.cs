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
    private GameObject _gameCloneAirplane1Prefub, _gameCloneAirplane2Prefub;
    private Player[] _plist;
    private bool _startGame = true;


    void Start()
    {
        _plist = PhotonNetwork.PlayerList;

        if (_plist.Length == 1)
        {
            Vector3 Airplane1SpawnPossition = new Vector3(-49f, 0f, -20f);
            _gameCloneAirplane1Prefub = PhotonNetwork.Instantiate(Airplane1Prefub.name, Airplane1SpawnPossition, Quaternion.identity); 
        }
        else
        {
            Vector3 Airplane2SpawnPossition = new Vector3(49f, 0f, -20f);
            _gameCloneAirplane2Prefub = PhotonNetwork.Instantiate(Airplane2Prefub.name, Airplane2SpawnPossition, Quaternion.identity);       
        } 
    }



    public void Leave() => PhotonNetwork.LeaveRoom();
    public override void OnLeftRoom() => SceneManager.LoadScene(0); 
    public override void OnPlayerEnteredRoom(Player newPlayer) => Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
   
    public override void OnPlayerLeftRoom(Player otherPlayer) => Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
    
}
