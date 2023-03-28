using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDot : MonoBehaviour
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
            playerStatus.bePowerful();
            Destroy(gameObject);
        }
    }
}
