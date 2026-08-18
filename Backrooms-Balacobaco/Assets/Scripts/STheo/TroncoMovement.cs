using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using FMODUnity;

public class TroncoMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    private float speed = 5f;
    [SerializeField] private StudioEventEmitter punchSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(this.transform.position.z == -6.96f){
            transform.Rotate(0,180f,0);
        }
        
        StartCoroutine("Timer");
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.3f);
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
        if(other.CompareTag("Player"))
        {
            punchSound.Play();
        }
    }
}
