using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    private PlayerFormController formController;
    public Transform attackPoint;
    private Animator animator;

    public float interactRange = 1f;

    void Start()
    {
        formController = GetComponent<PlayerFormController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateAttackPoint();

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseAbility();
        }
    }
    void UseAbility()
    {
        CharacterType type =
            formController.currentCharacter.characterType;

        // Trigger Animation
        switch (type)
        {
            case CharacterType.Hero:
                animator.SetTrigger("Attack");
                break;

            case CharacterType.Wizard:
                animator.SetTrigger("Interact");
                break;

            case CharacterType.Rogue:
                Debug.Log("Rogue avoids traps");
                break;
        }

        // Check nearby objects
        Collider2D[] hits =
        Physics2D.OverlapCircleAll(
            attackPoint.position,
            interactRange
        );

        foreach (Collider2D hit in hits)
        {
            // HERO → MONSTER
            if (type == CharacterType.Hero)
            {
                Monster monster = hit.GetComponent<Monster>();

                if (monster != null)
                {
                    monster.Defeat();
                }
            }

            // MAGE → LEVER
            if (type == CharacterType.Wizard)
            {
                Lever lever = hit.GetComponent<Lever>();

                if (lever != null)
                {
                    lever.Activate();
                }
            }
        }
    }

    void UpdateAttackPoint()
    {
        float x = animator.GetFloat("LastMoveX");
        float y = animator.GetFloat("LastMoveY");

        attackPoint.localPosition =
            new Vector2(x, y) * 0.75f;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(
                attackPoint.position,
                interactRange
            );
        }
    }
}