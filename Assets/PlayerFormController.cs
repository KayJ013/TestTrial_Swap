using UnityEngine;

public class PlayerFormController : MonoBehaviour
{
    public CharacterData heroData;
    public CharacterData wizardData;
    public CharacterData rogueData;

    public CharacterData currentCharacter;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        ChangeForm(heroData);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeForm(heroData);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeForm(wizardData);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeForm(rogueData);
    }

    public void ChangeForm(CharacterData newCharacter)
    {
        currentCharacter = newCharacter;

        sr.sprite = currentCharacter.characterSprite;

        Debug.Log("Changed to: " + currentCharacter.characterType);
    }
}