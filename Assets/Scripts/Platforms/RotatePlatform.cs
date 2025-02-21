using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
