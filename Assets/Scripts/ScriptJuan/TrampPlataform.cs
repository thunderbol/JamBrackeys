using UnityEngine;

public class TrampPlataform : MonoBehaviour
{
    public float fallDelay = 0.5f; // Tiempo antes de caer
    private Rigidbody2D rb;
    private bool activated = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Mantenerla estática al inicio
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Invoke("DropPlatform", fallDelay);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 2f); // Se destruye después de 2 segundos
    }
}
