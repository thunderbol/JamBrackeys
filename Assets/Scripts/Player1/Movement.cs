using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Variables de Movimiento")]
    Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 3f;
    private float horizontalMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2 (horizontalMove * speed, rb.linearVelocity.y);

        if (Input.GetKey("space") && IsGrounded.grounded == true) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
    }
}
