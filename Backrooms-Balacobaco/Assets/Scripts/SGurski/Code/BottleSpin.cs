using UnityEngine;
using System.Collections;
using FMODUnity;

public class BottleSpin : MonoBehaviour
{
    [SerializeField] private bool spin = false;
    public GameObject tampa, tampaSpawn, thisTampa;
    public PasswordCode passcode;
    [SerializeField] private StudioEventEmitter openBottle;
    
    public void OpenBottle()
    {
        spin = true;
        openBottle.Play();
        Invoke("DisableSpin", 1f);
    }

    void Start()
    {
        transform.Rotate(-90, 0, 0, Space.Self);
    }
    
    void Update()
    {
        if(spin)
        {
            transform.Rotate(0, 0, 720*Time.deltaTime, Space.Self);
            transform.Translate(0, 0, 0.1f*Time.deltaTime);
        }
    }

    void DisableSpin()
    {
        thisTampa = Instantiate(tampa, tampaSpawn.transform.position, Quaternion.identity);
        thisTampa.GetComponent<WriteSenha>().Init(passcode);
        Destroy(gameObject);
    }
}
