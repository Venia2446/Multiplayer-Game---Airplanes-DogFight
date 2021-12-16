using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour
{
    public float BulletSpeed;
    private Rigidbody2D rb;
    private string parentName;
    private Airplane1_control airplane1_Control;
    private Airplane2_control airplane2_Control;
    private GameObject ariplane1gameobject;
    private GameObject ariplane2gameobject;
    private PhotonView photonView;


    private void OnCollisionEnter2D(Collision2D collision)
    {



            if (collision.gameObject.CompareTag("Airplane1"))
            {
                Debug.Log("HIT1");
                airplane1_Control.HitHealhtDownAirplane1();
            }


            if (collision.gameObject.CompareTag("Airplane2"))
            {
                Debug.Log("HIT2");
                airplane2_Control.HitHealhtDownAirplane2();
            }
            Debug.Log("HIT_test");
            Destroy(gameObject);
            

    }




    private void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
        if (!photonView.IsMine) gameObject.GetComponent<SpriteRenderer>().color = Color.red; 


        
        ariplane1gameobject = GameObject.FindGameObjectWithTag("Airplane1");
        ariplane2gameobject = GameObject.FindGameObjectWithTag("Airplane2");
        
        if (ariplane1gameobject != null) airplane1_Control = ariplane1gameobject.GetComponent<Airplane1_control>();

        if (ariplane2gameobject != null) airplane2_Control = ariplane2gameobject.GetComponent<Airplane2_control>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector3.right * BulletSpeed);
    }

    void Update()
    {
        
    }
}
