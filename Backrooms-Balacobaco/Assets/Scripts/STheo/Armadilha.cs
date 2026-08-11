using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Armadilha : MonoBehaviour
{
    public GameObject objetoAlvo; 
    [SerializeField] private CapsuleCollider meuColisor;
    float timer = 3f;
    private bool ativarTimer = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuColisor = objetoAlvo.GetComponent<CapsuleCollider>();
        meuColisor.enabled = true;
    }
    void Update(){
        //print(timer);
        //timer+=Time.deltaTime;
        //ReativarComponente();
    }
    void ReativarComponente()
    {
        //print("bosta");
        if (objetoAlvo != null)
        {
            if (meuColisor != null)
            {
                meuColisor.enabled = true;
                //print("volta");
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.5f);
        ReativarComponente();
        yield break;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        timer = 1f;
        if (objetoAlvo != null)
        {

            if (meuColisor != null)
            {
                meuColisor.enabled = false;
                print("invisivel");
                StartCoroutine("Timer");
            }
        }
        print("armadilha");

    }
}
