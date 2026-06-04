using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Supaya tidak diagonal lebih cepat
        moveInput = moveInput.normalized;

        bool isMoving = moveInput != Vector2.zero;

        // Update Animator Walk Direction
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);

        // Simpan arah terakhir
        if (isMoving)
        {
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);

            animator.SetFloat("LastMoveX", moveInput.x);
            animator.SetFloat("LastMoveY", moveInput.y);
        }

        // State bergerak atau diam
        animator.SetBool("isMoving", isMoving);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
    }
}