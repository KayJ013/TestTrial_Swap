using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerFormController form =
            collision.GetComponent<PlayerFormController>();

        PlayerHealth health =
            collision.GetComponent<PlayerHealth>();

        if (form == null || health == null)
            return;

        CharacterData currentCharacter =
            form.currentCharacter;

        // ROGUE CAN PASS
        if (currentCharacter.canPassSpike)
        {
            // tahan E = aman
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Rogue avoids traps");

                return;
            }
        }

        // selain itu kena damage
        health.TakeDamage(1);
    }
}