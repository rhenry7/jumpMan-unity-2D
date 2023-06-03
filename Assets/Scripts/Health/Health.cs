using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;

    private Animator animation;

    public float currentHealth { get; private set; }

    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        animation = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        //currentHealth -= _damage;
        if (currentHealth > 0)
        {
            animation.SetTrigger("Hurt");
            // iframes
        }
        else
        {
            if (!dead)
            {
                animation.SetTrigger("Die");
                GetComponent<Movement>().enabled = false;
                dead = true;
            }
        }
    }

    // Update is called once per frame
}
