using UnityEngine;

public class PlayerMovementment : MonoBehaviour
{
    [Header("Movimiento Horizontal")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float horizontalMove;

    [Header("salto")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask GroundLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");//captura las teclas horizontales para el movimiento

        if (Input.GetButtonDown("Jump") && isGrounded()) //si estamos oprimiendo el espacio y estamos en el suelo
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);//a la propiedad velocidad del rb le agregamos un fuer
        }

        if (Input.GetButtonDown("Jump") && rb.linearVelocity.y > 0) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    public bool isGrounded() 
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f, GroundLayer);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMove * speed, rb.linearVelocity.y);
    }
}
