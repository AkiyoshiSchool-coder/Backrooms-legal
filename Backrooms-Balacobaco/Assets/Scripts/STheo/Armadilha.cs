using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using FMODUnity;

public class Armadilha : MonoBehaviour
{
    [SerializeField]  GameObject objetoAlvo; 
    private BoxCollider meuColisor;
    [SerializeField] private StudioEventEmitter trapSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuColisor = objetoAlvo.GetComponent<BoxCollider>();
        meuColisor.enabled = true;
        trapSound = gameObject.GetComponent<StudioEventEmitter>();
    }

    void ReativarComponente()
    {
        if (objetoAlvo != null)
        {
            if (meuColisor != null)
            {
                meuColisor.enabled = true;
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.45f);
        ReativarComponente();
        yield break;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (objetoAlvo != null)
        {
            if (meuColisor != null)
            {
                trapSound.Play();
                meuColisor.enabled = false;
                StartCoroutine("Timer");
            }
        }
    }
}
