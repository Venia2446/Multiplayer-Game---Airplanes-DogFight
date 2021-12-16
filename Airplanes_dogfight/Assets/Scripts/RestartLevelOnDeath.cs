using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RestartLevelOnDeath : MonoBehaviour
{
    private GameObject Airplane1, Airplane2;
    private Airplane1_control airplane1_Control;
    private Airplane2_control airplane2_Control;
    public TextMeshProUGUI ScoreText;
    private int _playerScore1 = 0;
    private int _playerScore2 = 0;

    void Update()
    {
        ScoreText.SetText($"Player1: {_playerScore1}  |  Player2: {_playerScore2}");

        Airplane1 = GameObject.FindGameObjectWithTag("Airplane1");
        Airplane2 = GameObject.FindGameObjectWithTag("Airplane2");
        if (Airplane1 != null & Airplane2 != null)
        {
            airplane1_Control = Airplane1.GetComponent<Airplane1_control>();
            airplane2_Control = Airplane2.GetComponent<Airplane2_control>();
            if (airplane1_Control.Player1Status() == true || airplane2_Control.Player2Status() == true)
            {
                if (airplane1_Control.Player1Status() == true) _playerScore2 += 1;
                Airplane1.transform.position = new Vector3(-49f, 0f, -20f);
                Airplane1.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                airplane1_Control.Player1StatusReset();

                if (airplane2_Control.Player2Status() == true) _playerScore1 += 1;
                Airplane2.transform.position = new Vector3(49, 0f, -20f);
                Airplane2.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                airplane2_Control.Player2StatusReset();
            }
        }
    }
}
