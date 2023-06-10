using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float startingHealth;

    [Header("iFrames")]
    [SerializeField]
    private float iFramesDuration;

    private bool isInvincible = false;

    [SerializeField]
    private float numberOfFlashes;

    private SpriteRenderer spriteRend;

    private Animator animation;

    public float currentHealth { get; private set; }

    public bool dead { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        animation = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
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
        if (isInvincible) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            animation.SetTrigger("Hurt");
            StartCoroutine(BecomeTemporarilyInvincible());
        }
        else
        {
            if (!dead)
            {
                animation.SetTrigger("Die");
                Debug.Log("Player has died!");
                GetComponent<Movement>().enabled = false;
                dead = true;
            }
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration /
                    (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration /
                    (numberOfFlashes * 2));
        }

        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }
}
