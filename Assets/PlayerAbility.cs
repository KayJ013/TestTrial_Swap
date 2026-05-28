using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private PlayerFormController formController;

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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);

        if (hit.collider == null)
            return;

        CharacterType type = formController.currentCharacter.characterType;

        if (type == CharacterType.Wizard)
        {
            Lever lever = hit.collider.GetComponent<Lever>();

            if (lever != null)
            {
                lever.Activate();
            }
        }

        if (type == CharacterType.Hero)
        {
            Monster monster = hit.collider.GetComponent<Monster>();

            if (monster != null)
            {
                monster.Defeat();
            }
        }

        if (type == CharacterType.Rogue)
        {
            Debug.Log("Rogue avoids traps");
        }
    }
}