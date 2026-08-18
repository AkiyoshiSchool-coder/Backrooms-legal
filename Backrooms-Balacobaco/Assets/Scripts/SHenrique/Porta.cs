using UnityEngine;
using FMODUnity;

public class Porta : MonoBehaviour
{
    Keys keys;
    [SerializeField] private GameObject naoTemChaves;
    [SerializeField] private Animator animator;
    public StudioEventEmitter doorSound;
    private bool aberto = false;

    void OnTriggerEnter(Collider other)
    {
        keys = other.GetComponent<Keys>();
        if (keys != null)
        {
            if (keys.keys == 3)
            {
                doorSound.Play();
                aberto = true;
                animator.SetBool("Aberto", aberto);
            }
            else
            {
                naoTemChaves.SetActive(true);
                aberto = false;
                animator.SetBool("Aberto", aberto);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        naoTemChaves.SetActive(false);
    }
}
