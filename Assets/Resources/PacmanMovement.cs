using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    PlayerStatus playerStatus;
    private float pacmanMoveSpeed;

    // Direction
    private Quaternion faceUp = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion faceDown = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion faceLeft = Quaternion.Euler(0f, 270f, 0f);
    private Quaternion faceRight = Quaternion.Euler(0f, 90f, 0f);

    // Wall hit
    private float raycastDistance = 0.08f;
    private float sphereRadius = 0.4f;
    private LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus = FindObjectOfType<PlayerStatus>();
        pacmanMoveSpeed = 0f;
        transform.rotation = faceRight;
        wallLayer = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerStatus.isEnd())
        {
            // Get keboard input then turn
            if (Input.GetKey("up"))
            {
                transform.rotation = faceUp;
                pacmanMoveSpeed = 5f;
            }
            if (Input.GetKey("down"))
            {
                transform.rotation = faceDown;
                pacmanMoveSpeed = 5f;
            }
            if (Input.GetKey("left"))
            {
                transform.rotation = faceLeft;
                pacmanMoveSpeed = 5f;
            }
            if (Input.GetKey("right"))
            {
                transform.rotation = faceRight;
                pacmanMoveSpeed = 5f;
            }

            // Wall Hit
            WallDetect();

            // Move forward base on face direction
            transform.position += transform.rotation * Vector3.forward * pacmanMoveSpeed * Time.deltaTime;
        }
        else
        {
            pacmanMoveSpeed = 0f;
        }
    }

    void WallDetect()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, raycastDistance, wallLayer))
        {
            pacmanMoveSpeed = 0f;
        }

    }
}
