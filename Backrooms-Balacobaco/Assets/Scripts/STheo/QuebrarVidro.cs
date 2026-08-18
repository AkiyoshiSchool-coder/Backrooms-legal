using System;
using UnityEngine;

public class QuebrarVidro : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, timer);
    }
}
