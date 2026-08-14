using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
public class ColliderTronco : MonoBehaviour
{
    [SerializeField] private GameObject tronco;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        InvocarTronco();
        yield break;
    }

    void InvocarTronco()
    {
        Instantiate(tronco, new Vector3(0,0,0), Quaternion.identity);
        print("oJogo");
    }

    void OnTriggerEnter(Collider other)
    {
        InvocarTronco();
    }
}
