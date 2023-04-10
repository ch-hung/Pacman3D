using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    PlayerStatus playerStatus;

    public AudioSource chomp;
    public AudioSource death;
    public AudioSource ghost;
    public AudioSource intro;
    public AudioSource power;
    public AudioSource start;

    private void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
    }

    // Eat sound
    public void playChomp()
    {
        if (!chomp.isPlaying && !intro.isPlaying)
        {
            chomp.Play();
        }
    }

    // Death sound
    public void playDeath()
    {
        death.Play();
    }

    // Normal play sound
    public void playGhost()
    {
        if (!playerStatus.isEnd())
        {
            ghost.Play();
        }
    }
    public void stopGhost()
    {
        ghost.Stop();
    }

    // Enter sound
    public void playIntro()
    {
        intro.Play();
    }
    public void stopIntro()
    {
        intro.Stop();
    }

    // Power dots sound
    public void playPower()
    {
        power.Play();
    }
    public void stopPower()
    {
        power.Stop();
    }

    // Restart scene sound
    public void playStart()
    {
        start.Play();
    }
}
