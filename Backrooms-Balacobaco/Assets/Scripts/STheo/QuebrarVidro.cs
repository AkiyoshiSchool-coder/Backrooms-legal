using System;
using UnityEngine;

public class QuebrarVidro : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, timer);
    }
}
