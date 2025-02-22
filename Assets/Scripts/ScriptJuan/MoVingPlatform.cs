using UnityEngine;

public class MoVingPlatform : MonoBehaviour
{
    public Vector2 moveOffset = new Vector2(3f, 0f);
    public float moveSpeed = 2f;
    private Vector2 startPosition;
    private bool activated = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(MovePlatform());
        }
    }

    System.Collections.IEnumerator MovePlatform()
    {
        Vector2 targetPosition = startPosition + moveOffset;
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }
    }
}
