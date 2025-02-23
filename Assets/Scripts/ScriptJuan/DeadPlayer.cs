using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeadPlayer : MonoBehaviour
{


[Header("Configuración de Muerte")]
    public float deathDelay = 1f;  // Tiempo antes de reiniciar el nivel
    private bool isDead = false;
    
    private Rigidbody2D rb;
    private Animator anim;
    private PlayerController playerController;

void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

   void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el personaje toca algo peligroso, muere
        if (collision.CompareTag("Enemy") || collision.CompareTag("Tramp"))
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return; // Evita que se llame varias veces
        isDead = true;

        // Desactiva el movimiento del personaje
        playerController.enabled = false;
        rb.linearVelocity = Vector2.zero; // Detiene el personaje
        rb.gravityScale = 0; // Evita que siga cayendo

        // Activa la animación de muerte
        anim.SetTrigger("Die");
        //frenar animación
        //anim.enabled = false;
        // Llamar a los efectos de muerte
        GetComponent<PlayerDeathEffects>()?.PlayDeathEffects();

        // Inicia el reinicio del nivel después de un tiempo
        StartCoroutine(RestartLevel());
    }
 

     IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel actual
    }

    
}
