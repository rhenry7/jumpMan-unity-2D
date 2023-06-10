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

    private Animator anim;

    private SpriteRenderer spriteRend;

    private bool triggered;

    private bool activate;

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
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
