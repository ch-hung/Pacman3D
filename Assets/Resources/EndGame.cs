using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    PlayerStatus playerStatus;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private GameObject botton;
    [SerializeField] private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        endText.gameObject.SetActive(false);
        botton.SetActive(false);
        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatus.isEnd())
        {
            if (playerStatus.isAlive())
            {
                endText.text = "Win!";
                showEnd();
            }
            else
            {
                endText.text = "Lose!";
                showEnd();
            }
        }
    }

    void showEnd()
    {
        endText.gameObject.SetActive(true);
        botton.SetActive(true);
        panel.SetActive(true);
    }
}
