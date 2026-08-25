using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using FMODUnity;

public class Armadilha : MonoBehaviour
{
    [SerializeField] GameObject objetoAlvoCapsula; 
    private CapsuleCollider meuColisorCapsula;
    [SerializeField] GameObject objetoAlvoBox; 
    private BoxCollider meuColisorBox;
    [SerializeField] private StudioEventEmitter trapSound;
    [SerializeField] private FirstPersonMovement player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuColisorCapsula = objetoAlvoCapsula.GetComponent<CapsuleCollider>();
        meuColisorCapsula.enabled = true;
        meuColisorBox = objetoAlvoBox.GetComponent<BoxCollider>();
        meuColisorBox.enabled = true;
        trapSound = gameObject.GetComponent<StudioEventEmitter>();
    }

    void ReativarComponente()
    {
        meuColisorCapsula.enabled = true;
        meuColisorBox.enabled = true;
        player.Stop(false);
        Destroy(this.gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.7f);
        ReativarComponente();
        yield break;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        meuColisorCapsula.enabled = false;
        meuColisorBox.enabled = false;
        trapSound.Play();
        StartCoroutine("Timer");
        player.Stop(true);
    }
}
