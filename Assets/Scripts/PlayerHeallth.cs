using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PlayerHeallth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int maxHealth = 3;
    public float invincibilityDuration = 1f;
    public float knockbackForce = 5f;

    private int currentHealth;
    private bool isInvincible = false;
    private Rigidbody rb;
    public TextMeshProUGUI healthText;

    void Start()
    {
        Debug.Log("Start)");
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        UpdateUI();
    }

    void UpdateUI()
    {
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
    }

    public void TakeDamage(int amount, Vector3 hitDirection)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        UpdateUI();

        Debug.Log("Player Health: " + currentHealth);

        ApplyKnockback(hitDirection);
        StartCoroutine(DamageCooldown());

        if (currentHealth <= 0)
            Die();
    }

    void ApplyKnockback(Vector3 direction)
    {
        Debug.Log("Knckback");
        direction.y = 1.5f; // add a small upward bump
      
        rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);
    }

    IEnumerator DamageCooldown()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
