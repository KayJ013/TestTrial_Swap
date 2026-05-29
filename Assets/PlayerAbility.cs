using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private PlayerFormController formController;

    public float interactRange = 1f;

    void Start()
    {
        formController = GetComponent<PlayerFormController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseAbility();
        }
    }

    void UseAbility()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            interactRange
        );

        CharacterType type =
            formController.currentCharacter.characterType;

        foreach (Collider2D hit in hits)
        {
            // WIZARD → LEVER
            if (type == CharacterType.Wizard)
            {
                Lever lever = hit.GetComponent<Lever>();

                if (lever != null)
                {
                    lever.Activate();
                }
            }

            // HERO → MONSTER
            if (type == CharacterType.Hero)
            {
                Monster monster = hit.GetComponent<Monster>();

                if (monster != null)
                {
                    monster.Defeat();
                }
            }

            // ROGUE
            if (type == CharacterType.Rogue)
            {
                Debug.Log("Rogue avoids traps");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            transform.position,
            interactRange
        );
    }
}