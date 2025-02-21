using System;
using Unity.VisualScripting;
using UnityEngine;

public class followSaw : MonoBehaviour
{
    [Header("Control de seguimiento")]
    [SerializeField] private GameObject target;
    [SerializeField] private float speedFollow = 10f;
    private bool nearPlayer = false;
    

    // Update is called once per frame
    void Update()
    {
        if (nearPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speedFollow * Time.deltaTime);
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
