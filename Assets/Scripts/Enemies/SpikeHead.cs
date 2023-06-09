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

    private Vector3[] directions = new Vector3[2];

    private void OnEnable()
    {
        Stop();
    }

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
            // Consider spike just goes up and down; after down goes back
            // dont understand what is wrong with save file
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit =
                Physics2D
                    .Raycast(transform.position,
                    directions[i],
                    range,
                    playerLayer);
            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirection()
    {
        //directions[0] = transform.right * range; // Right
        //directions[1] = -transform.right * range; // Left
        directions[0] = transform.up * range; // Up
        directions[1] = -transform.up * range; // Down
    }

    private void Stop()
    {
        destination = transform.position; // Set destination as current position;
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Stop();
    }
}
