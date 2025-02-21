using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private bool ready = false;

    private void Update()
    {
        if (ready) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ready = true;
    }
}
