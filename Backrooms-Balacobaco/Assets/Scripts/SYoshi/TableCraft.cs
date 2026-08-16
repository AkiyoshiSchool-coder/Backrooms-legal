using UnityEngine;

public class TableCraft : MonoBehaviour
{
    public bool PlayerInRange;
    public bool OnTable;
    public GameObject posicao;
    public GameObject Base;
    public GameObject Cabeca;
    public BoxCollider boxCollider;

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
