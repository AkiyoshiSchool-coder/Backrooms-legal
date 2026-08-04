using UnityEngine;

public class GhostPlacement : MonoBehaviour
{

    public bool playerInRange;

    private void OnTriggerEnter( Collider colisao)
    {
        if(colisao.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}
