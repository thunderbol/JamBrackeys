using UnityEngine;

public class SurpriseTramp : MonoBehaviour
{
    public GameObject trapObject; // Objeto trampa que se activará
    public float delay = 0.2f;

    void Start()
    {
        trapObject.SetActive(false); // Inicia desactivado
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("ActivateTrap", delay);
        }
    }

    void ActivateTrap()
    {
        trapObject.SetActive(true); // Se activa la trampa
    }

}
