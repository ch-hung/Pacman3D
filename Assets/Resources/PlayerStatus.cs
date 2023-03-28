using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int totalScore;
    private bool isPowerful;
    private float powerfulTime;
    private bool alive;
    private bool end;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        isPowerful = false;
        powerfulTime = 0f;
        alive = true;
        end = false;
    }

    private void Update()
    {
        // Count down the powerful time
        if (isPowerful)
        {
            powerfulTime -= Time.deltaTime;
            if (powerfulTime <= 0)
            {
                isPowerful = false;
            }
        }
    }

    // Score methods
    public void addScore(int score)
    {
        totalScore++;
        if (totalScore == 150)
        {
            beEnd();
        }
    }

    public int getScore()
    {
        return totalScore;
    }

    // Powerful methods
    public void bePowerful()
    {
        isPowerful = true;
        powerfulTime = 10f;
    }

    public bool isPowered()
    {
        return isPowerful;
    }

    // Alive method
    public void hurt()
    {
        alive = false;
        beEnd();
    }

    public bool isAlive()
    {
        return alive;
    }

    // End method
    public void beEnd()
    {
        end = true;
    }

    public bool isEnd()
    {
        return end;
    }
}