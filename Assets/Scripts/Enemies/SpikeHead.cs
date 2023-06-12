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

    private float checkTimer;

    [SerializeField]
    private Vector3 destination;

    private bool attacking;

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
    }

    private void CalculaeDirection()
    {
    }
}
