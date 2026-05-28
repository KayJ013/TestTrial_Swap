using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool isDead = false;

    public void Defeat()
    {
        if (!isDead)
        {
            isDead = true;

            Debug.Log("Monster Defeated!");

            Destroy(gameObject);
        }
    }
}