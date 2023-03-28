using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    PlayerStatus playerStatus;
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        scoreText.text = "Score: 0";
        scoreText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerStatus.getScore();
        if (!playerStatus.isAlive())
        {
            scoreText.color = Color.black;
        }
    }
}
