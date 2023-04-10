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

    AudioPlayer audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        totalScore = 0;
        isPowerful = false;
        powerfulTime = 0f;
        alive = true;
        end = false;

        audioPlayer.playIntro();
        audioPlayer.playGhost();
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
                audioPlayer.stopPower();
                audioPlayer.playGhost();
            }
        }
    }

    // Score methods
    public void addScore(int score)
    {
        totalScore++;
        audioPlayer.playChomp();
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
        audioPlayer.stopGhost();
        audioPlayer.playPower();
        powerfulTime = 10f;
    }

    public bool isPowered()
    {
        return isPowerful;
    }

    public float getPowerfulTime()
    {
        return powerfulTime;
    }

    // Alive method
    public void hurt()
    {
        alive = false;
        audioPlayer.playDeath();
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
        audioPlayer.stopGhost();
        audioPlayer.stopPower();
        audioPlayer.stopIntro();
        audioPlayer.playStart();
    }

    public bool isEnd()
    {
        return end;
    }
}
