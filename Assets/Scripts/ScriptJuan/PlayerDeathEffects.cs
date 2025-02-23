using UnityEngine;

public class PlayerDeathEffects : MonoBehaviour
{
    public ParticleSystem confettiEffect; // Asigna en el Inspector

    public void PlayDeathEffects()
    {
        if (confettiEffect != null)
        {
            // Instanciar las part�culas en la posici�n del jugador
            ParticleSystem confetti = Instantiate(confettiEffect, transform.position, Quaternion.identity);
            confetti.Play();
            Destroy(confetti.gameObject, 2f); // Elimina la part�cula despu�s de 2 segundos
        }
    }
}
