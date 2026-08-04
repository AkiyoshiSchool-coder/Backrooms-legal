using UnityEngine;
using System.Collections;

public class BottleSpin : MonoBehaviour
{
    [SerializeField] private bool spin = false;
    public void OpenBottle()
    {
        spin = true;
        Invoke("DisableSpin", 1f);
    }

    void Update()
    {
        if(spin)
        {
            // transform.Rotate(0, 720*Time.deltaTime, 0, Space.Self);
            transform.Translate(0, 0.1f*Time.deltaTime, 0);
        }
    }

    void DisableSpin()
    {
        spin = false;
    }
}
