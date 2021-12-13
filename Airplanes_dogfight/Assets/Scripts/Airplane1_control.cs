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
    private PhotonView photonView;
    private int healt = 100;
    private bool startGame = true;
    private bool player1dead = false;
    private GameObject clone_bullet;
    private Transform Bullet_spawn_tranform;


    public void hitHealhtDownAirplane1() => healt--;
    public bool Player1Status() => player1dead;
    public void Player1StatusReset() => player1dead = false;

    private void shoot()
    {
        Bullet_spawn_tranform = this.gameObject.transform.GetChild(0);
        

        clone_bullet = PhotonNetwork.Instantiate(bullet.name, Bullet_spawn_tranform.position , transform.rotation);


    }

    void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
        if (!photonView.IsMine) HeathBar.color = Color.red;;
    }

    void Update()
    {
        if (healt <= 0)
        {
            player1dead = true;
            healt = 100;
        }



        Player[] plist = PhotonNetwork.PlayerList;
        if (plist.Length == 2 && startGame)
        {
            transform.position = new Vector3(-49f, 0f, -20f);
            transform.rotation = new Quaternion(0, 0, 0, 0);
            
            startGame = false;
        }



        HeathBar.SetText(healt.ToString());

        if (photonView.IsMine)
        {

       
        transform.Translate(Vector3.right* AirplaneSpeed*Time.deltaTime);
        if (Input.GetKey("up")) transform.Rotate(0f, 0f, 1f*RotationSpeed * Time.deltaTime);
        if (Input.GetKey("down")) transform.Rotate(0f, 0f, -1f*RotationSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {

                shoot();
                
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
}
