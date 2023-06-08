using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float startingHealth;

    [Header("iFrames")]
    [SerializeField]
    private float iFramesDuration;

    [SerializeField]
    private float numberOfFlashes;

    private SpriteRenderer spriteRenderer;

    private Animator animation;

    public float currentHealth { get; private set; }

    public bool dead { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        animation = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (dead)
        {
            //  Destroy(GameObject.FindGameObjectsWithTag("Player"));
        }
    }

    public void AddHealth(float _health)
    {
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startingHealth);
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        //currentHealth -= _damage;
        if (currentHealth > 0)
        {
            // trigger when damage
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
