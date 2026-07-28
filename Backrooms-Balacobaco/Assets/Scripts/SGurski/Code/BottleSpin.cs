using UnityEngine;

public class BottleSpin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 360*Time.deltaTime, 0, Space.World);
        transform.Translate(0, 0.2f*Time.deltaTime, 0);
    }
}
