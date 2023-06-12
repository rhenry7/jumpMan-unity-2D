using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class
Enemy_Projectile
: Enemy_Damage // inherets to reuse damage method
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float resetTime;

    private float lifetime;

    public void Start()
    {
        ActivateProjectile();
    }

    // Update is called once per frame
    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // way to inherit logic from other class

        // base.OnTriggerEnter2D(collision);

        gameObject.SetActive(false);
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
