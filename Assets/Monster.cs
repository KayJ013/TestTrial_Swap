using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth health =
            collision.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(1);
        }
    }

    public void Defeat()
    {
        Debug.Log("Monster Defeated!");

        Destroy(gameObject);
    }
}