using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 moveInput;

    private PlayerInputController inputController;

    private void Awake()
    {
        inputController = GetComponent<PlayerInputController>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = inputController.InputActions.Player.Move.ReadValue<Vector2>();
        moveInput = moveInput.normalized;

        bool isMoving = moveInput != Vector2.zero;

        if (isMoving)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);

            animator.SetFloat("LastMoveX", moveInput.x);
            animator.SetFloat("LastMoveY", moveInput.y);
        }

        animator.SetBool("isMoving", isMoving);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
}