using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class TroncoMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(this.transform.position.z == -6.86f){
            speed = -speed;
        }
        
        StartCoroutine("Timer");
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other){
        //other.velocity.y = 10;
    }
}
