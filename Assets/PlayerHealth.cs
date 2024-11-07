using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject restartButton; // Reference to the restart button

    void Start()
    {
        currentHealth = maxHealth;
        restartButton.SetActive(false); // will keep the button hidden at start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died. Showing Restart Button.");
        restartButton.SetActive(true); // Show the restart button
        Debug.Log("Restart button should be visible now: " + restartButton.activeSelf); // Check if it's truly active
        gameObject.SetActive(false); // Hide player object or disable controls
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
