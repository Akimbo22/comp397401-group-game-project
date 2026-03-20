using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Tower : MonoBehaviour
{
    [Header("Shooting")]
    public Transform projectileSpawnPos;
    public GameObject projectilePrefab;
    public float shotDelay = 1f;
    private float shotTimer = 0f;

    [Header("Health")]
    public int maxHealth = 100;
    public int health;

    [Header("Audio")]
    public AudioController audioController;

    [Header("Settings")]
    public bool isPlayerTower;

    private void Start()
    {
        if (maxHealth <= 0) maxHealth = 1;
        health = maxHealth;
    }

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (shotTimer > 0)
            shotTimer -= Time.deltaTime;

        if (Mouse.current != null && Mouse.current.leftButton.isPressed && shotTimer <= 0)
        {
            Shoot();
            shotTimer = shotDelay;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab == null || projectileSpawnPos == null)
        {
            Debug.LogError("Projectile prefab or spawn position not assigned!");
            return;
        }

        GameObject shot = Instantiate(projectilePrefab, projectileSpawnPos.position, projectileSpawnPos.rotation);
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Projectile projScript = shot.GetComponent<Projectile>();
            if (projScript != null)
            {
                rb.linearVelocity = projectileSpawnPos.forward * projScript.speed;
            }
        }

        if (audioController != null)
            audioController.PlayShootSFX();
    }

    // ---------------- HEALTH ----------------
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        if (!isPlayerTower)
        {
            if (audioController != null)
                audioController.PlayDeathSFX();
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}