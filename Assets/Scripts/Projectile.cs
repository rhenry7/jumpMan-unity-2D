using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float direction;

    private bool hit;

    private BoxCollider2D boxCollider;

    private Animator animation;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();

        // rb = GetComponent<Rigidbody2D>();
        // rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        animation.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction) localScaleX = -localScaleX;

        transform.localScale =
            new Vector3(localScaleX,
                transform.localScale.y,
                transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
