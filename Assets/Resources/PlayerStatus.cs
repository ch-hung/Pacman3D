using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int totalScore;
    private bool isPowerful;
    private float powerfulTime;
    private bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        isPowerful = false;
        powerfulTime = 0f;
        isAlive = true;
    }

    private void Update()
    {
        if (isPowerful)
        {
            powerfulTime -= Time.deltaTime;
            if (powerfulTime <= 0)
            {
                isPowerful = false;
            }
        }
    }

    public void addScore(int score)
    {
        totalScore++;
    }

    public int getScore()
    {
        return totalScore;
    }

    public void bePowerful()
    {
        isPowerful = true;
        powerfulTime = 10f;
    }
}
