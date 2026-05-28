using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "SwapScape/Character Data")]
public class CharacterData : ScriptableObject
{
    public CharacterType characterType;

    public Sprite characterSprite;

    [TextArea]
    public string abilityDescription;
}