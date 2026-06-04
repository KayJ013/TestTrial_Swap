using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "SwapScape/Character Data")]
public class CharacterData : ScriptableObject
{
    public CharacterType characterType;

    public Sprite characterSprite;
    public RuntimeAnimatorController animatorController;

    [Header("Stats")]
    public int maxHealth = 1;

    [Header("Abilities")]
    public bool canPassSpike;

    [TextArea]
    public string abilityDescription;
}