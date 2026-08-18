using Unity.VisualScripting;
using UnityEngine;

public class Fim : MonoBehaviour
{
    [SerializeField] private GameObject fim;
    [SerializeField] private GameObject Player;
    
    void OnTriggerEnter(Collider other)
    {
        fim.SetActive(true);
        Player.SetActive(false);
        Cursor.visible = true;
    }
}
