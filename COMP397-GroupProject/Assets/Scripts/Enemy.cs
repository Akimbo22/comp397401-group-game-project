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

    [Header("Death Audio")]
    public AudioClip deathSFX;

    [Header("Target (DRAG THIS IN UNITY)")]
    [SerializeField] private TowerHealth towerHealth;

    private Transform target;
    private float attackTimer = 0f;
    private AudioSource audioSource;

    private void Start()
    {
        currentHealth = maxHealth;

        if (towerHealth == null)
        {
            Debug.LogError("? TowerHealth NOT assigned in Inspector!");
            return;
        }

        target = towerHealth.transform;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
            MoveTowardTarget();
        else
            AttackTower();
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
            towerHealth.TakeDamage(damagePerAttack);

            if (attackSound != null && audioSource != null)
                audioSource.PlayOneShot(attackSound);

            attackTimer = 0f;
        }
    }

    public void TakeDamage(float amount, AudioClip hitSound = null)
    {
        currentHealth -= amount;

        if (hitSound != null)
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);

        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");

        // ? OBSERVER EVENTS
        if (EventChannelManager.instance != null)
        {
            EventChannelManager.instance.onEnemyKilled?.Raise(1);

            // First kill event
            if (KillCounter.Instance.deathCount == 0)
            {
                EventChannelManager.instance.onFirstEnemyKilled?.Raise();
            }
        }

        KillCounter.Instance.AddKill();

        if (deathSFX != null)
        {
            GameObject deathSoundObj = new GameObject("EnemyDeathSound");
            deathSoundObj.transform.position = transform.position;

            AudioSource audio = deathSoundObj.AddComponent<AudioSource>();
            audio.clip = deathSFX;
            audio.spatialBlend = 1f;
            audio.Play();

            Destroy(deathSoundObj, deathSFX.length);
        }

        Destroy(gameObject);
    }
}