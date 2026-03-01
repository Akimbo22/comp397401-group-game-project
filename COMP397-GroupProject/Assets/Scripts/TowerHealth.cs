using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed for scene loading

public class TowerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 200f;
    [HideInInspector] public float currentHealth;

    [Header("UI")]
    public Slider healthSlider;

    [Header("Game Over")]
    public string gameOverSceneName = "GameOver"; // Name of your Game Over scene

    private void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
        else
        {
            Debug.LogWarning("Health Slider not assigned!");
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Update slider
        if (healthSlider != null)
            healthSlider.value = currentHealth;

        Debug.Log("Tower Health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            TowerDestroyed();
        }
    }

    private void TowerDestroyed()
    {
        Debug.Log("TOWER DESTROYED!");

        // Load Game Over scene
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}