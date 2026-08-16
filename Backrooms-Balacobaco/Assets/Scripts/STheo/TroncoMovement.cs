using UnityEngine;

public class TroncoMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(this.transform.position.z == -6){
            speed = -5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //if (playerTransform != null)
        //{
        //}
    }
}
