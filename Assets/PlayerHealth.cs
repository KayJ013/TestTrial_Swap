using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;

    private PlayerFormController formController;

    void Start()
    {
        formController = GetComponent<PlayerFormController>();

        currentHealth =
            formController.currentCharacter.maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");

        Destroy(gameObject);
    }
}