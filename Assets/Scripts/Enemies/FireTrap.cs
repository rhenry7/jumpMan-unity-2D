using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField]
    private float activationDelay;

    [SerializeField]
    private float activeTime;

    [SerializeField]
    private float damage;

    private Animator anim;

    private SpriteRenderer spriteRend;

    private bool triggered;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                // trigger
                StartCoroutine(ActivateFireTrap());
            }
            if (active)
            {
                // trigger
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator ActivateFireTrap()
    {
        triggered = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
