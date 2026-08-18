using JetBrains.Annotations;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class Push : MonoBehaviour
{
    [SerializeField] private InputActionReference pushingAction;
    [SerializeField] private Texture hand;
    private GameObject objpuxavel;
    private bool perto;
    public bool umavez = false;
    [SerializeField] private Color colorNew;
    [SerializeField] private Vector3 maoTamanho;
     [SerializeField] private Vector3 normalTamanho;
    private Rigidbody rb;
    private bool pegavel;
    [SerializeField] private FirstPersonMovement firstPersonMovement;
    [SerializeField] private Jump jump;
    [SerializeField] private GameObject box;
    [SerializeField] private StudioEventEmitter caixaSound;

    private void OnEnable()
    {
        pushingAction.action.performed += PushingObject;
    }
    private void OnDisable()
    {
        pushingAction.action.performed -= PushingObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if(umavez == false)
        {
            if(other.tag == "Box")
            {
                UIManager.instance.ChangeImage(hand);
                UIManager.instance.ChangeScale(maoTamanho);
                objpuxavel = other.gameObject;
                rb = objpuxavel.GetComponent<Rigidbody>();
                pegavel = objpuxavel.GetComponent<Pegavel>();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                perto = true;
            }  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Box")
        {
            UIManager.instance.ChangeImage(hand);
            UIManager.instance.ChangeScale(normalTamanho);

            if (pegavel == false)
            {

                if (objpuxavel != null)
                {
                    UIManager.instance.ChangeColor(Color.black);
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    objpuxavel = null;
                    perto = false;
                    rb = null;
                }
            }
            else
            {   
                if (umavez == true)
                {
                    StopCarrying();
                }
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
                    UIManager.instance.ChangeColor(colorNew);
                    caixaSound.Play();

                    rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
                    rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
                    rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
    
                    if(pegavel == true)
                    {
                        objpuxavel.transform.position = box.transform.position;
                        firstPersonMovement.PushingObject(rb);
                        jump.PushingObject(rb);
                        umavez = true;
                    }
                }
            }
        }
        else
        {
            StopCarrying();
        }
    }
    public void StopCarrying()
    {
        firstPersonMovement.StopPushing();
        jump.StopPushing();
        rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        UIManager.instance.ChangeColor(Color.black);

        if (objpuxavel != null)
        {
            objpuxavel = null;
        }
        perto = false;
        umavez = false;
        rb = null;
    }
}
