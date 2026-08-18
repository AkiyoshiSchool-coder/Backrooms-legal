using System;
using UnityEngine;
using FMODUnity;

public class QuebrarVidro : MonoBehaviour
{
    [SerializeField] private float timer = 0f;
    [SerializeField] private StudioEventEmitter glassBreak;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        //glassBreak.Play();
        Destroy(this.gameObject, timer);
    }
}
