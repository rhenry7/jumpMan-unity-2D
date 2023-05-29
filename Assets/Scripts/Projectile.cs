using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool hit;

    private float direction;

    private Animator animation;

    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
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

        // every time it hits, make it explode and enable collision true
        boxCollider.enabled = true;
        animation.SetTrigger("Explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;

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
