using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float attackCooldown;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject[] fireballs;

    private float cooldownTimer;

    private void Attack()
    {
        cooldownTimer = 0;

        fireballs[0].transform.position = firePoint.position;
        // fireballs[0].GetComponent<EnemyProjectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy) return i;
        }
        return 0;
    }
}
