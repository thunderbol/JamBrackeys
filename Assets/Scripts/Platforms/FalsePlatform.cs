using UnityEngine;

public class FalsePlatform : MonoBehaviour
{
    SpriteRenderer platformMesh;

    private void Start()
    {
        platformMesh = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            platformMesh.enabled = false;
        }
    }
}
