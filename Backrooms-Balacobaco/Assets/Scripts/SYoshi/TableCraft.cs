using UnityEngine;

public class TableCraft : MonoBehaviour
{
    public bool PlayerInRange;
    public bool OnTable;
    public GameObject posicao;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }
}
