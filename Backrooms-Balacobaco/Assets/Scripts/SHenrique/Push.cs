using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
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
    
    void OnTriggerEnter(Collider other)
    {
        if(umavez == false)
        {
            if(other.tag == "Box")
            {
                UIManager.instance.ChangeImage(hand);
                objpuxavel = other.gameObject;
                if(objpuxavel.GetComponent<Pegavel>() != null)
                {
                    UIManager.instance.changeColor(colorNew);
                }
                objpuxavel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                perto = true;
            }  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Box")
        {
            if(objpuxavel.GetComponent<Pegavel>() == null)
            {
                UIManager.instance.ChangeImage(hand);
            
                if(objpuxavel!=null)
                {
                    objpuxavel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
                objpuxavel = null;
                perto = false;
            }
        }
    }
    
    public void PushingObject(InputAction.CallbackContext context)
    {
        if(umavez == false)
        {
            if (perto == true)
            {
                if(objpuxavel!=null)
                {
                    if(objpuxavel.GetComponent<Pegavel>() == null)
                    {
                        objpuxavel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    }
                    else
                    {
                        
                        objpuxavel.transform.SetParent(this.gameObject.transform);
                        objpuxavel.transform.position = objectBox.transform.position;
                        //objpuxavel.GetComponent<Rigidbody>().isKinematic = true;
                        //objpuxavel.GetComponent<BoxCollider>().enabled = false;
                        umavez = true;
                    }
                }
            }
        }
        else
        {
            objpuxavel.transform.SetParent(originalP.transform);
            //objpuxavel.GetComponent<BoxCollider>().enabled = true;
            //objpuxavel.GetComponent<Rigidbody>().isKinematic = false;
            objpuxavel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            
            UIManager.instance.ChangeImage(hand);
            UIManager.instance.changeColor(Color.black); 
            objpuxavel = null;
            perto = false;
            umavez = false;
        }
        
    }
}
