using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerStatus playerStatus;
    private Renderer enemyRenderer;
    private float time = 0f;
    private bool ischanged = false;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        enemyRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        // When Chomp eat power dot, enemy blink
        if (playerStatus.isPowered())
        {
            blink();
        }
        else
        {
            // Resume the color
            if (ischanged)
            {
                enemyRenderer.material.color = Color.white;
                ischanged = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Chomp")
        {
            // When Chomp is powerful > be eatten
            if (playerStatus.isPowered())
            {
                Destroy(gameObject);
            }
            // when Chomp is not powerful > die
            else
            {
                playerStatus.hurt();
            }
        }
    }

    private void blink()
    {
        time += Time.deltaTime;
        // Blink faster as the time expired more
        float frequency = (playerStatus.getPowerfulTime() / 20) > 0.1 ? (playerStatus.getPowerfulTime() / 20) : 0.05f;
        if (time > frequency)
        {
            if (ischanged)
            {
                enemyRenderer.material.color = Color.white;
                ischanged = false;
            }
            else
            {
                enemyRenderer.material.color = Color.black;
                ischanged = true;
            }
            time = 0;
        }
    }
}
