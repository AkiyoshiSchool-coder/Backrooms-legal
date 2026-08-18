using Unity.VisualScripting;
using UnityEngine;

public class Fim : MonoBehaviour
{
    [SerializeField] private GameObject fim; //Objeto fim no canvas
    
    void OnTriggerEnter(Collider other)
    {
        if(this.enabled == true) //Impede o Script de funcionar sem estar ativado
        {
            if(other.CompareTag("Player"))
            {
                fim.SetActive(true);
                other.gameObject.SetActive(false); //player nao move mais
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
