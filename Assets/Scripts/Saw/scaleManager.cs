using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class scaleManager : MonoBehaviour
{
    [Header("Variables de escalado")]
    [SerializeField] private float speedScale = 1f;
    [SerializeField] private Vector3 firstScale = new Vector3(1,1,1);
    [SerializeField] private Vector3 lastScale = new Vector3(8,8,1);

    [Header("Variables de control")]
    [SerializeField] private float timeElapsed = 0f;
    [SerializeField] private float speedRotation = 180f;
    [SerializeField] private bool nearPlayer = false;
    
    [Header("Seguimiento")]
    [SerializeField] private GameObject target;
    [SerializeField] private float speedFollow = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = firstScale;//Se le da como tamaño inicial la primera escala
    }

    
    void Update()
    {
        //Rota en el eje Z para hacer efecto de sierra
        transform.Rotate(0, 0, speedRotation * Time.deltaTime);

        if (nearPlayer == true)
        {
            //un objeto tiene su propia escala, le sumamos la escala del vector 3 por la velocidad del escalado
            Vector3 newScale = transform.localScale + Vector3.one * speedScale * Time.deltaTime;
            transform.localScale = newScale;//la escala de la sierra será la que estamos calculado
            //seguimiento de la sierra
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speedFollow * Time.deltaTime);

        }
        else 
        {
            transform.localScale = firstScale;
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            nearPlayer = true;
        }
    }

    
}
