using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Push : MonoBehaviour
{
    [SerializeField] private InputActionReference pushingAction;
    [SerializeField] private Texture hand;
    private GameObject objpuxavel;
    private bool perto;

    private void OnEnable()
    {
        Cursor.visible = false;
        pushingAction.action.performed += PushingObject;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
        pushingAction.action.performed -= PushingObject;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            UIManager.instance.ChangeImage(hand);
            objpuxavel = other.gameObject;
            perto = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Box")
        {
            UIManager.instance.ChangeImage(hand);
            if(objpuxavel!=null)
                objpuxavel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            objpuxavel = null;
            perto = false;
        }
    }
    
    public void PushingObject(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (perto == true)
            {
                if(objpuxavel!=null)
                    objpuxavel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
        }
    }
}
