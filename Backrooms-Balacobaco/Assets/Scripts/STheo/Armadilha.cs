using UnityEngine;

public class Armadilha : MonoBehaviour
{
    public GameObject objetoAlvo; 
    private CapsuleCollider meuColisor;
    public float timer = 1f;
    private bool ativarTimer = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuColisor = objetoAlvo.GetComponent<CapsuleCollider>();
        meuColisor.enabled = true;
    }
    void Update(){
        print(timer);
    }
    void ReativarComponente()
    {
        print("bosta");
        timer+=Time.deltaTime;
        if(timer>=2f){
            if (objetoAlvo != null)
            {
                if (meuColisor != null)
                {
                    // Reativa o componente
                meuColisor.enabled = true;
                ativarTimer = false;
                timer = 1f;
                print("volta");
                }
            }
        }
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        timer = 1f;
        if (objetoAlvo != null)
        {
            // Pega um componente especifico, por exemplo, um BoxCollider ou um Script customizado

            if (meuColisor != null)
            {
                // Desativa o componente temporariamente
                meuColisor.enabled = false;
                print("invisivel");
            }
        }
        Destroy(this.gameObject);
        print("armadilha");
        ReativarComponente();

    }
}
