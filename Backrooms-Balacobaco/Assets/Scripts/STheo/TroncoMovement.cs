using UnityEngine;

public class TroncoMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed*Time.deltaTime);
        }
    }
}
