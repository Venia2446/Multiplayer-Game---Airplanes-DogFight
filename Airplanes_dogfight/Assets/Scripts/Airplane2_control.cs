using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Airplane2_control: MonoBehaviour
{
    // Start is called before the first frame update


    public float AirplaneSpeed;
    public float RotationSpeed;
    public GameObject bullet;
    public TextMeshPro HeathBar;
    
    private PhotonView _photonView;
    private int _healt = 100;
    private bool _startGame = true;
    private bool _player2Dead = false;
    private GameObject _cloneBullet;
    private Transform _bulletSpawnTranform;
    


    public void HitHealhtDownAirplane2() => _healt--;
    public bool Player2Status() => _player2Dead;
    public void Player2StatusReset() => _player2Dead = false;


    private void shoot()
    {
        _bulletSpawnTranform = this.gameObject.transform.GetChild(0);
        _cloneBullet = PhotonNetwork.Instantiate(bullet.name, _bulletSpawnTranform.position, _bulletSpawnTranform.rotation); 
    }

    void Start()
    {
        _photonView = gameObject.GetComponent<PhotonView>();
        if (!_photonView.IsMine) HeathBar.color = Color.red;

    }

    void Update()
    {
        if (_healt <= 0)
        {
                _player2Dead = true;
                _healt = 100;
        }

        Player[] plist = PhotonNetwork.PlayerList;
        if (plist.Length == 2 && _startGame)
        {
            transform.position = new Vector3(49f, 0f, -20f);
            transform.rotation = new Quaternion(0, 0, 0, 0);

            _startGame = false;
        }


        HeathBar.SetText(_healt.ToString());

        if (_photonView.IsMine)
        {
            transform.Translate(Vector3.left * AirplaneSpeed * Time.deltaTime);
            if (Input.GetKey("up")) transform.Rotate(0f, 0f, 1f * RotationSpeed * Time.deltaTime);
            if (Input.GetKey("down")) transform.Rotate(0f, 0f, -1f * RotationSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space)) shoot();
            if (transform.position.x > 53) transform.position = new Vector3(53f, transform.position.y, transform.position.z);
            if (transform.position.x < -53) transform.position = new Vector3(-53f, transform.position.y, transform.position.z);
            if (transform.position.y > 30) transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
            if (transform.position.y < -30) transform.position = new Vector3(transform.position.x, -30f, transform.position.z);
        }
    }  
}


