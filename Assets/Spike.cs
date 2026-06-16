using UnityEngine;

public class Spike : MonoBehaviour
{
    private PlayerInputController inputController;

    private void Awake()
    {
        inputController = FindFirstObjectByType<PlayerInputController>();
    }

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

        if (currentCharacter.canPassSpike)
        {
            if (inputController.InputActions.Player.Ability.IsPressed())
            {
                Debug.Log("Rogue avoids traps");
                return;
            }
        }

        health.TakeDamage(1);
    }
}