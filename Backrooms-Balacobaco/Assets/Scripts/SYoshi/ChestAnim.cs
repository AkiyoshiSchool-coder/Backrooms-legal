using UnityEngine;
using FMODUnity;

public class ChestAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool open;
    [SerializeField] private Animation animation;
    [SerializeField] private StudioEventEmitter woodChest;
    public bool PlayerInRange;

    public void StartAnim()
    {
        woodChest.Play();
        open = true;
        Animator();
    }

    private void Animator()
    {
        animation.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider colisao)
    {
        if(colisao.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
