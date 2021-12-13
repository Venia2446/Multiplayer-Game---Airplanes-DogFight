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
    private PhotonView photonView;
    public TextMeshPro HeathBar; 
    private int healt = 100;
    private bool startGame = true;
    private bool player2dead = false;
    private GameObject clone_bullet;
    private Transform Bullet_spawn_tranform;
    


    public void hitHealhtDownAirplane2() => healt--;
    public bool Player2Status() => player2dead;
    public void Player2StatusReset() => player2dead = false;


    private void shoot()
    {
        Bullet_spawn_tranform = this.gameObject.transform.GetChild(0);

        clone_bullet = PhotonNetwork.Instantiate(bullet.name, Bullet_spawn_tranform.position, Bullet_spawn_tranform.rotation); 
    }

    void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();


        if (!photonView.IsMine) HeathBar.color = Color.red;

    }

    void Update()
    {
        if (healt <= 0)
        {
                player2dead = true;
                healt = 100;
        }

        Player[] plist = PhotonNetwork.PlayerList;
        if (plist.Length == 2 && startGame)
        {
            transform.position = new Vector3(49f, 0f, -20f);
            transform.rotation = new Quaternion(0, 0, 0, 0);

            startGame = false;
        }


        HeathBar.SetText(healt.ToString());

        if (photonView.IsMine)
        {
            transform.Translate(Vector3.left * AirplaneSpeed * Time.deltaTime);
            if (Input.GetKey("up")) transform.Rotate(0f, 0f, 1f * RotationSpeed * Time.deltaTime);
            if (Input.GetKey("down")) transform.Rotate(0f, 0f, -1f * RotationSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shoot();
            }
        }
        if (transform.position.x > 53)
        {
            transform.position = new Vector3(53f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -53)
        {
            transform.position = new Vector3(-53f, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 30)
        {
            transform.position = new Vector3(transform.position.x, 30f, transform.position.z);
        }
        if (transform.position.y < -30)
        {
            transform.position = new Vector3(transform.position.x, -30f, transform.position.z);
        }
    }
}


