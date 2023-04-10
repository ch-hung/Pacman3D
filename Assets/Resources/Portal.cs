using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject chomp;
    private void OnTriggerEnter(Collider other)
    {
        float vectorX;
        vectorX = other.transform.position.x;
        if (vectorX > 0)
        {
            chomp.transform.position = new Vector3(-9.5f, chomp.transform.position.y, chomp.transform.position.z);
        }
        else
        {
            chomp.transform.position = new Vector3(9.5f, chomp.transform.position.y, chomp.transform.position.z);
        }
    }
}
