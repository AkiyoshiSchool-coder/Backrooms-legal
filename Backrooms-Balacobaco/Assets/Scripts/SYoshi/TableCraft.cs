using UnityEngine;

public class TableCraft : MonoBehaviour
{
    public bool PlayerInRange;
    public bool OnTable;
    public GameObject posicao;
    public GameObject Base,Marcelo,Cabeca;
    public BoxCollider boxCollider;
    

    void Update()
    {
        if(Cabeca.transform.position == posicao.transform.position)
        {
            CraftHammer();
        }
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
    private void CraftHammer()
    {
        Marcelo.transform.SetParent(null);
        Destroy(Head);
        Destroy(Base);
        Marcelo.SetActive(true);
        boxCollider.enabled = true;
        
    }
}
