using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class ColliderTronco : MonoBehaviour
{
    [SerializeField] private GameObject tronco;
    private float startDelay = 2f;
    private float spawnInterval = 1f;
    private float positionZ;
    private int num;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        InvokeRepeating("InvocarTronco", startDelay, spawnInterval);
    }

    void Update()
    {
        num = UnityEngine.Random.Range(1,3);
        if(num == 1)
        {
            positionZ = -14f;
        }else{
            positionZ = -6.96f;
        }

        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        print("oJogo");
        yield break;
    }

    void InvocarTronco()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-14, -5), 0.5f, positionZ);
        Instantiate(tronco, randomPosition, Quaternion.identity);
    }

    void OnTriggerStay(Collider other)
    {
        //InvocarTronco();
    }
}
