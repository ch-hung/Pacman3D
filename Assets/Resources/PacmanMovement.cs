using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    private float pacmanMoveSpeed;

    // Direction
    private Quaternion faceUp = Quaternion.Euler(0f, 0f, 0f);
    private Quaternion faceDown = Quaternion.Euler(0f, 180f, 0f);
    private Quaternion faceLeft = Quaternion.Euler(0f, 270f, 0f);
    private Quaternion faceRight = Quaternion.Euler(0f, 90f, 0f);

    // Wall hit
    private float raycastDistance = 0.1f;
    private float sphereRadius = 0.45f;
    private LayerMask wallLayer;

    // Start is called before the first frame update
    void Start()
    {
        pacmanMoveSpeed = 0f;
        transform.rotation = faceRight;
        wallLayer = LayerMask.GetMask("Wall");
    }

    // Update is called once per frame
    void Update()
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

    void WallDetect()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, sphereRadius, transform.forward, out hit, raycastDistance, wallLayer))
        {
            pacmanMoveSpeed = 0f;
        }

    }
}
