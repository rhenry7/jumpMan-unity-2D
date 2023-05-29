using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float attackCooldown;

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
    void Update()
    {
        if (
            Input.GetMouseButton(0) &&
            cooldownTimer > attackCooldown &&
            playerMovement.canAttack()
        )
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animation.SetTrigger("Attack");
        cooldownTimer = 0;
    }
}
