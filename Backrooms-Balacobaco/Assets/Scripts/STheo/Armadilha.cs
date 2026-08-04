using UnityEngine;

public class Armadilha : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        print(other);
    }
}
