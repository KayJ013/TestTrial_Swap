using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        InputActions.Player.Enable();
    }

    private void OnDisable()
    {
        InputActions.Player.Disable();
    }
}