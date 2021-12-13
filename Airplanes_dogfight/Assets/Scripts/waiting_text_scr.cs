using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waiting_text_scr : MonoBehaviour
{
    // Start is called before the first frame update
    private float alpha_color;
    private TextMeshProUGUI text_color;

    private void Start()
    {
        text_color = gameObject.GetComponent<TextMeshProUGUI>();
    }




    void Update()
    {
        
        if (PhotonNetwork.PlayerList.Length != 2)
        {
            text_color.text = "Waiting fo players";
        }
        if (PhotonNetwork.PlayerList.Length == 2)
        {
            alpha_color = text_color.color.a - 0.001f;
            text_color.text = "GameStart";
            text_color.color = new Color(text_color.color.r, text_color.color.g, text_color.color.b, alpha_color);

        }
    }
}
