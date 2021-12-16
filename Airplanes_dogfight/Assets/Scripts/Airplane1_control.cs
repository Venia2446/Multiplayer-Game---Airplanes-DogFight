using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Airplane1_control: MonoBehaviour
{
    public float AirplaneSpeed;
    public float RotationSpeed;
    public TextMeshPro HeathBar;
    public GameObject bullet;
    private PhotonView _photonView;
    private int _healt = 100;
    private bool _startGame = true;
    private bool _player1Dead = false;
    private GameObject _cloneBullet;
    private Transform _bulletSpawnTranform;


    public void HitHealhtDownAirplane1() => _healt--;
    public bool Player1Status() => _player1Dead;
    public void Player1StatusReset() => _player1Dead = false;

    private void Shoot()
    {
        _bulletSpawnTranform = this.gameObject.transform.GetChild(0);
        

        _cloneBullet = PhotonNetwork.Instantiate(bullet.name, _bulletSpawnTranform.position , transform.rotation);


    }

    void Start()
    {
        _photonView = gameObject.GetComponent<PhotonView>();
        if (!_photonView.IsMine) HeathBar.color = Color.red;;
    }

    void Update()
    {
        if (_healt <= 0)
        {
            _player1Dead = true;
            _healt = 100;
        }
        Player[] plist = PhotonNetwork.PlayerList;
        if (plist.Length == 2 && _startGame)
        {
            transform.position = new Vector3(-49f, 0f, -20f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            
            _startGame = false;
        }

        HeathBar.SetText(_healt.ToString());

        if (_photonView.IsMine)
        {

        transform.Translate(Vector3.right* AirplaneSpeed*Time.deltaTime);

        if (Input.GetKey("up")) transform.Rotate(0f, 0f, 1f*RotationSpeed * Time.deltaTime);
        if (Input.GetKey("down")) transform.Rotate(0f, 0f, -1f*RotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) Shoot();
        if (transform.position.x > 53)transform.position = new Vector3(53f, transform.position.y, transform.position.z);
        if (transform.position.x < -53) transform.position = new Vector3(-53f, transform.position.y, transform.position.z);
        if (transform.position.y > 30) transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
        if (transform.position.y < -30) transform.position = new Vector3(transform.position.x, -30f, transform.position.z);
        }
    }
}
