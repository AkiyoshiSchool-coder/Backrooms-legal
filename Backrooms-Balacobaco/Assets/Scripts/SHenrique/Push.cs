using UnityEngine;
using UnityEngine.InputSystem;
public class Push : MonoBehaviour
{
    [SerializeField] private InputActionReference pushingAction;
    [SerializeField] private Texture hand;
    private GameObject objpuxavel;
    private bool perto;
    public bool umavez = false;
    [SerializeField] private Color colorNew;
    [SerializeField] private GameObject originalP;
    [SerializeField] private GameObject objectBox;
    private BoxCollider boxCollider;
    private BoxCollider pegavelColider;
    private Rigidbody rb;
    private bool pegavel;

    private void OnEnable()
    {
        pushingAction.action.performed += PushingObject;
    }
    private void OnDisable()
    {
        pushingAction.action.performed -= PushingObject;
    }

    void Awake()
    {
        boxCollider = objectBox.GetComponent<BoxCollider>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(umavez == false)
        {
            if(other.tag == "Box")
            {
                UIManager.instance.ChangeImage(hand);
                objpuxavel = other.gameObject;
                rb = objpuxavel.GetComponent<Rigidbody>();
                pegavel = objpuxavel.GetComponent<Pegavel>();
                pegavelColider = objpuxavel.GetComponent<BoxCollider>();

                if(pegavel == true)
                {
                    UIManager.instance.changeColor(colorNew);
                }
                rb.constraints = RigidbodyConstraints.FreezeAll;
                perto = true;
            }  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Box")
        {
            if(pegavel == false)
            {
                UIManager.instance.ChangeImage(hand);
            
                if(objpuxavel!=null)
                {
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                }
                objpuxavel = null;
                perto = false;
                pegavel = false;
                rb = null;
            }
        }
    }

    public void PushingObject(InputAction.CallbackContext context)
    {
        if (umavez == false)
        {
            if (perto == true)
            {
                if (objpuxavel != null)
                {
                    if (pegavel == false)
                    {
                        rb.constraints = RigidbodyConstraints.None;
                    }
                    else
                    {

                        objpuxavel.transform.SetParent(this.transform);
                        objpuxavel.transform.position = objectBox.transform.position;
                        objectBox.transform.localScale = objpuxavel.transform.localScale;
                        boxCollider.size = pegavelColider.size;
                        pegavelColider.enabled = false;
                        boxCollider.enabled = true;
                        umavez = true;
                    }
                }
            }
        }
        else
        {
            objectBox.transform.localScale = new Vector3(1f, 1f, 1f);
            boxCollider.enabled = false;
            objpuxavel.transform.SetParent(originalP.transform);
            rb.constraints = RigidbodyConstraints.None;
            UIManager.instance.ChangeImage(hand);
            UIManager.instance.changeColor(Color.black);
            objpuxavel = null;
            pegavelColider.enabled = true;
            pegavelColider = null;
            perto = false;
            umavez = false;
            pegavel = false;
            rb = null;
        }

    }
}
