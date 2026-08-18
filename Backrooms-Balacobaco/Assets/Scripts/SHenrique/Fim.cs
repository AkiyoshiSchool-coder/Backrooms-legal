using Unity.VisualScripting;
using UnityEngine;

public class Fim : MonoBehaviour
{
    [SerializeField] private GameObject fim;
    
    void OnTriggerEnter(Collider other)
    {
        if(this.enabled == true)
        {
            if(other.CompareTag("Player"))
            {
                fim.SetActive(true);
                other.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
