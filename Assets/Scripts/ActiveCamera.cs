using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCamera : MonoBehaviour
{
    public static ActiveCamera activeCamera;

    public GameObject player1;
    public GameObject player2;

    public float distanceMultiplier = 1;
    public float moveSpeed;

    Vector3 targetPosition;
    Vector3 velocity;
    Vector3 startPosition;

    public float startZ = 0;

    private bool died;

    // Use this for initialization
    void Start()
    {
        activeCamera = this;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!died)
        {
            targetPosition = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2,
                transform.position.y,
                (player2.transform.position.x - player1.transform.position.x) * distanceMultiplier + startZ);
        }
        else
        {
            targetPosition = startPosition;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, moveSpeed);
    }

    public void Die()
    {
        died = true;
    }
}
