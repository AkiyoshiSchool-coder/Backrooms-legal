using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rayRange = 2.5f;
    [SerializeField] private float interactSpeed = 5f;
    [SerializeField] private float rotateSpeed = 200f;
    [SerializeField] private GameObject handPos;
    [SerializeField] private GameObject pilarPos;
    [SerializeField] private GhostPlacement ghostPlacement;
    [SerializeField] private TableCraft tableCraft;
    private InputAction interactAction;
    private InputAction lookAction;
    private InputAction dropAction;
    private InputAction extraAction;
    private InputAction getInHandAction;

    public Transform ObjectViewer;
    public UnityEvent OnView;
    public UnityEvent OnFinishView;

    private Interactables currentObject;
    private Vector3 originPosition;
    private Quaternion originRotation;
    [SerializeField] private BoxCollider boxCollider;

    private bool interacting;
    private bool canFinish;
    [SerializeField] private List<string> Names = new List<string>();
    

    public FirstPersonLook camMovement;
    public PasswordCode passwordCode;
    public BottleSpin bottleCode;

    void Start()
    {
        cam = Camera.main;
        interactAction = InputSystem.actions.FindAction("Interact");
        lookAction = InputSystem.actions.FindAction("Look");
        dropAction = InputSystem.actions.FindAction("Drop");
        extraAction = InputSystem.actions.FindAction("Extra");
        getInHandAction = InputSystem.actions.FindAction("Grab");
    }

    void Update()
    {
        InteractCheck();
    }

    void InteractCheck()
    {
        
        if(interacting)
        {
            Names[0] = currentObject.item.name;
            if(currentObject.item.canGrab)
            {
                boxCollider = currentObject.GetComponent<BoxCollider>();
                if(interactAction.IsPressed())
                {
                    RotateObject();
                    return;
                }

                if(currentObject.item.hasExtraAction && canFinish && extraAction.WasPressedThisFrame())
                {
                    if(currentObject.item.name == "Garrafa")
                    {
                        bottleCode = currentObject.gameObject.GetComponentInChildren<BottleSpin>();
                        bottleCode.OpenBottle();
                        canFinish = false;
                        Invoke("FinishView", 1f);
                    }
                    //if(currentObject.item.name == "Hammer")
                    //{
                        
                    //}
                }
            }

            if(getInHandAction.WasPressedThisFrame())
            {
                GrabObject();
            }
            
            if(canFinish && dropAction.WasPressedThisFrame())
            {
                FinishView();
            }
        }
        RaycastHit hit;
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

        if(Physics.Raycast(rayOrigin, cam.transform.forward, out hit, rayRange))
        {
            Interactables obj = hit.collider.GetComponent<Interactables>();
            if(obj != null)
            {
                UIManager.instance.changeColor(Color.yellow);
                if(interactAction.WasPressedThisFrame())
                {
                    if(obj.isMoving)
                    {
                        return;
                    }

                    currentObject = obj;
                    interacting = true;

                    Invoke("CanFinish", 1f);

                    if(currentObject.item.canGrab)
                    {
                        originPosition = currentObject.transform.position;
                        originRotation = currentObject.transform.rotation;
                        OnView.Invoke();
                        StartCoroutine(MovingObject(currentObject, ObjectViewer.position));
                    }
                    else
                    {
                        if(currentObject.item.name == "Botao")
                        {
                            passwordCode.InsertCharacter(currentObject.name);
                            currentObject.gameObject.GetComponent<BlinkButton>().Blink();
                        }
                    }
                }
            }
        }
        else
        {
            UIManager.instance.changeColor(Color.black);
        }
    }

    void CanFinish()
    {
        canFinish = true;
        if(currentObject.item.canGrab)
        {
            UIManager.instance.InteractText(true);
        }
    }

    void FinishView()
    {
        if(ghostPlacement!=null)
        {
            if(ghostPlacement.playerInRange)
            {
                originPosition = pilarPos.transform.position;
                originRotation = pilarPos.transform.rotation;
                ghostPlacement.onPillar = true;
            }
        }
        if(tableCraft!=null)
        {
           if(tableCraft.PlayerInRange && ghostPlacement.onPillar == true)
            {
                originPosition = tableCraft.posicao.transform.position;
                originRotation = tableCraft.posicao.transform.rotation;
                tableCraft.OnTable = true;
            } 
        }
        canFinish = false;
        interacting = false;
        UIManager.instance.InteractText(false);
        if(currentObject.item.canGrab)
        {
            currentObject.transform.SetParent(null);
            currentObject.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentObject, originPosition));
            if(ghostPlacement.onPillar &&  Names[0] == Names[1])
            {
                boxCollider.enabled = false;
                tableCraft.boxCollider.enabled = true;
            }
            else
            {
                boxCollider.enabled = true;
            }

        }
        else
        {
            cam.transform.rotation = originRotation;
        }
        OnFinishView.Invoke();
    }

    IEnumerator MovingObject(Interactables heldItem, Vector3 pos)
    {
        heldItem.isMoving = true;
        float timer = 0;
        canFinish = false;
        while(timer<1)
        {
            heldItem.transform.position = Vector3.Lerp(heldItem.transform.position, pos, Time.deltaTime*interactSpeed);
            timer+=Time.deltaTime;
            yield return null;
        }

        heldItem.transform.position = pos;
        heldItem.isMoving = false;
        if(interacting == true && currentObject.item.canGrab)
        {
            UIManager.instance.InteractText(true);
        }
        else
        {
            UIManager.instance.InteractText(false);
        }
        canFinish = true;
    }

    void RotateObject()
    {
        if(currentObject.item.canRotate)
        {
            Vector2 rotation = lookAction.ReadValue<Vector2>();
            currentObject.transform.Rotate(cam.transform.up, -Mathf.Deg2Rad*rotation.x*rotateSpeed, Space.World);
            currentObject.transform.Rotate(cam.transform.right, -Mathf.Deg2Rad*rotation.y*rotateSpeed, Space.World);
        }
    }

    void GrabObject()
    {
        if (currentObject.item.inHand)
        {
            currentObject.transform.rotation = handPos.transform.rotation;
            currentObject.transform.position = handPos.transform.position;
            currentObject.transform.SetParent(handPos.transform);
            boxCollider.enabled = false;
        }
        OnFinishView.Invoke();
    }
}
