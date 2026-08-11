using UnityEngine;

public class ChestAnim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool open;
    [SerializeField] private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnim()
    {
       open = true;
       Animator();
    }

    private void Animator()
    {
        animator.SetBool("aberto", open);
    }
}
