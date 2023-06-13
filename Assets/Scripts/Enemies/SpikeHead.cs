using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Enemy_Damage
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float range;

    [SerializeField]
    private float checkDelay;

    [SerializeField]
    private LayerMask playerLayer;

    private float checkTimer;

    private Vector3 destination;

    private bool attacking;

    private Vector3[] directions = new Vector3[4];

    // Update is called once per frame
    void Update()
    {
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay) CheckForPlayer();
        }
    }

    private void CheckForPlayer()
    {
        CalculateDirection();

        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit =
                Physics2D
                    .Raycast(transform.position,
                    directions[i],
                    range,
                    playerLayer);
        }
    }

    private void CalculateDirection()
    {
        directions[0] = transform.right * range; // Right
        directions[1] = -transform.right * range; // Left
        directions[2] = transform.up * range; // Up
        directions[3] = -transform.up * range; // Down
    }
}
