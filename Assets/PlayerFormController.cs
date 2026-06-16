using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFormController : MonoBehaviour
{
    public CharacterData heroData;
    public CharacterData wizardData;
    public CharacterData rogueData;

    public CharacterData currentCharacter;

    private SpriteRenderer sr;
    private Animator animator;

    private PlayerInputController inputController;

    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();

        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        ChangeForm(heroData);
    }

    private void OnEnable()
    {
        inputController.InputActions.Player.SelectHero.performed += OnHero;
        inputController.InputActions.Player.SelectMage.performed += OnMage;
        inputController.InputActions.Player.SelectRogue.performed += OnRogue;
    }

    private void OnDisable()
    {
        inputController.InputActions.Player.SelectHero.performed -= OnHero;
        inputController.InputActions.Player.SelectMage.performed -= OnMage;
        inputController.InputActions.Player.SelectRogue.performed -= OnRogue;
    }

    private void OnHero(InputAction.CallbackContext context)
    {
        ChangeForm(heroData);
    }

    private void OnMage(InputAction.CallbackContext context)
    {
        ChangeForm(wizardData);
    }

    private void OnRogue(InputAction.CallbackContext context)
    {
        ChangeForm(rogueData);
    }

    public void ChangeForm(CharacterData newCharacter)
    {
        currentCharacter = newCharacter;

        animator.runtimeAnimatorController = newCharacter.animatorController;
        sr.sprite = currentCharacter.characterSprite;

        Debug.Log("Changed to: " + currentCharacter.characterType);
    }
}