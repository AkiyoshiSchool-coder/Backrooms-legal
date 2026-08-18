using UnityEngine;
using FMODUnity;

public class Porta : MonoBehaviour
{
    Keys keys; //Está no player
    [SerializeField] private GameObject naoTemChaves; //Caso nao tem todas as chaves
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject fim;
    public StudioEventEmitter doorSound;
    private bool aberto = false;

    void OnTriggerEnter(Collider other)
    {
        keys = other.GetComponent<Keys>();
        if (keys != null)
        {
            if (keys.keys == 3) //Caso tenha
            {
                doorSound.Play();
                aberto = true;
                animator.SetBool("Aberto", aberto);
                fim.SetActive(true);
            }
            else //Caso nao tenha
            {
                naoTemChaves.SetActive(true);
                aberto = false;
                animator.SetBool("Aberto", aberto);
            }
        }
    }

    void OnTriggerExit(Collider other) //Tira o texto
    {
        naoTemChaves.SetActive(false);
    }
}
