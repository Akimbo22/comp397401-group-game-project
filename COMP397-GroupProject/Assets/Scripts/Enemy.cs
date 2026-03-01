using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2f;
    public float attackDistance = 3.5f;

    [Header("Attack")]
    public float damagePerAttack = 20f;
    public float attackCooldown = 3f;
    public AudioClip attackSound;

    [Header("Health")]
    public float maxHealth = 50f;
    private float currentHealth;

    private Transform target;
    private TowerHealth towerHealth;
    private float attackTimer = 0f;
    private AudioSource audioSource;

    private void Start()
    {
        // Find tower by tag
        GameObject towerObj = GameObject.FindWithTag("Tower");
        if (towerObj != null)
        {
            target = towerObj.transform;

            // Get TowerHealth even if it's on a child
            towerHealth = towerObj.GetComponent<TowerHealth>();
            if (towerHealth == null)
                towerHealth = towerObj.GetComponentInChildren<TowerHealth>();

            if (towerHealth == null)
                Debug.LogError("TowerHealth component not found on tower or children!");
        }
        else
        {
            Debug.LogError("No object with tag 'Tower' found!");
        }

        // Setup AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
        attackTimer = 0f;
    }

    private void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            MoveTowardTarget();
        }
        else
        {
            AttackTower();
        }
    }

    private void MoveTowardTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(target);
    }

    private void AttackTower()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            if (towerHealth != null)
            {
                // Deal damage
                towerHealth.TakeDamage(damagePerAttack);

                // Play sound
                if (attackSound != null && audioSource != null)
                    audioSource.PlayOneShot(attackSound);

                Debug.Log("Enemy attacked tower for " + damagePerAttack + " damage. Tower HP: " + towerHealth.currentHealth);
            }
            attackTimer = 0f;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
            Destroy(gameObject);
    }
}



