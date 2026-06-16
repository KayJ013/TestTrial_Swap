using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbility : MonoBehaviour
{
    private PlayerFormController formController;
    private PlayerInputController inputController;

    public Transform attackPoint;

    private Animator animator;

    public float interactRange = 1f;

    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();
    }

    private void OnEnable()
    {
        inputController.InputActions.Player.Ability.performed += OnAbility;
    }

    private void OnDisable()
    {
        inputController.InputActions.Player.Ability.performed -= OnAbility;
    }

    void Start()
    {
        formController = GetComponent<PlayerFormController>();
        animator = GetComponent<Animator>();
    }

    private void OnAbility(InputAction.CallbackContext context)
    {
        UseAbility();
    }

    void Update()
    {
        UpdateAttackPoint();
    }

    void UseAbility()
    {
        CharacterType type =
            formController.currentCharacter.characterType;

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

        Collider2D[] hits =
            Physics2D.OverlapCircleAll(
                attackPoint.position,
                interactRange);

        foreach (Collider2D hit in hits)
        {
            if (type == CharacterType.Hero)
            {
                Monster monster = hit.GetComponent<Monster>();

                if (monster != null)
                    monster.Defeat();
            }

            if (type == CharacterType.Wizard)
            {
                Lever lever = hit.GetComponent<Lever>();

                if (lever != null)
                    lever.Activate();
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
                interactRange);
        }
    }
}