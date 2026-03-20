using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 20f;
    public int damage = 5;
    public float life = 5f;

    [Header("Audio")]
    public AudioClip hitSFX; // optional, plays when hitting enemy

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true; // movement handled manually
    }

    private void Start()
    {
        Destroy(gameObject, life);
    }

    private void Update()
    {
        float moveDistance = speed * Time.deltaTime;

        // Raycast forward to ensure fast projectiles hit enemies
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, moveDistance))
        {
            Enemy enemy = hit.collider.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                // Deal damage and pass hit sound
                enemy.TakeDamage(damage, hitSFX);
                Debug.Log("?? Hit enemy for " + damage);

                Destroy(gameObject);
                return;
            }
        }

        // Move projectile forward
        transform.position += transform.forward * moveDistance;
    }
}