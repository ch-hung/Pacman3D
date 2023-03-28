using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
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
}
