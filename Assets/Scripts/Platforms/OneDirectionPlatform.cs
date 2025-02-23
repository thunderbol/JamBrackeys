using UnityEngine;

public class OneDirectionPlatform : MonoBehaviour
{
    [Header("Variables Movimiento")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private float startTime = 2f;
    
    [Header("Platform Positions")]
    public Transform[] movePoints;
    private int i = 0;
    private float waitTime;


    [Header("Animation Wink Platform")]
    private Animator anim;

    void Start()
    {
        waitTime = startTime;//We initiate the wait time
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //We move the platform from one point to other
        transform.position = Vector2.MoveTowards(transform.position, movePoints[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePoints[i].transform.position) < 0.1f) 
        {
            //We check the time never be negative
            if (waitTime <= 0)
            {
                if (movePoints[i] != movePoints[movePoints.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                //We initiate the timer again
                waitTime = startTime;
            }
            else 
            {
                //We put the timer on
                waitTime -= Time.deltaTime;
            }
        }
    }
    //We ensure the player be the parent of the platform, so they move toguether
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("Wink");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetTrigger("PlatformN1");
        }
    }


}
