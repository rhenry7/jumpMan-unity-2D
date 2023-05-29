using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject[] fireballs;

    private Animator animation;

    private Movement playerMovement;

    private float cooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Awake()
    {
        animation = GetComponent<Animator>();
        playerMovement = GetComponent<Movement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (
            Input.GetMouseButton(0) &&
            cooldownTimer > attackCooldown &&
            playerMovement.canAttack()
        ) Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animation.SetTrigger("Attack");
        cooldownTimer = 0;

        // object pooling
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()]
            .GetComponent<Projectile>()
            .SetDirection(Mathf.Sign(transform.localScale.x));
    }

    // get fireball in the array
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
