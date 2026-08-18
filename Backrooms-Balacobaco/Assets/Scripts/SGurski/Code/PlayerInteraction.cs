using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR;
using FMODUnity;

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
    [SerializeField] private ChestAnim chestAnim;
    [SerializeField] private Keys keys;

    public InputActionAsset InputActions;
    private InputAction interactAction;
    private InputAction lookAction;
    private InputAction dropAction;
    private InputAction extraAction;
    private InputAction getInHandAction;
    private InputAction pauseAction;

    public Transform ObjectViewer;
    public UnityEvent OnView;
    public UnityEvent OnFinishView;

    private Interactables currentObject;
    private Vector3 originPosition;
    private Quaternion originRotation;
    [SerializeField] private Quaternion HammerRotation; 
    [SerializeField] private BoxCollider boxCollider;

    [SerializeField] private StudioEventEmitter LockB;
    [SerializeField] private StudioEventEmitter LockF;

    private bool interacting;
    private bool canFinish;
    private bool Grabbed = false;
    [SerializeField] private List<string> Names = new List<string>();
    

    public FirstPersonLook camMovement;
    public PasswordCode passwordCode;
    public BottleSpin bottleCode;
    public GameObject pauseMenu;

    public Interactables teste;

    void Start()
    {
        cam = Camera.main;
        interactAction = InputSystem.actions.FindAction("Interact");
        lookAction = InputSystem.actions.FindAction("Look");
        dropAction = InputSystem.actions.FindAction("Drop");
        extraAction = InputSystem.actions.FindAction("Extra");
        getInHandAction = InputSystem.actions.FindAction("Grab");
        pauseAction = InputSystem.actions.FindAction("Pause");
        InputActions.FindActionMap("Player").Enable();
    }

    void Update()
    {
        InteractCheck();
        if(pauseAction.WasPressedThisFrame())
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = Convert.ToInt32(!pauseMenu.activeSelf); // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
        if(pauseMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            InputActions.FindActionMap("Player").Disable();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            InputActions.FindActionMap("Player").Enable();
        }
    }

    void InteractCheck()
    {
        if(interacting)
        {
            Names[0] = currentObject.item.name;
            if(currentObject.item.canGrab)
            {
                if(currentObject.GetComponent<BoxCollider>() != null)
                {
                    boxCollider = currentObject.GetComponent<BoxCollider>();
                }
                if(interactAction.IsPressed() && Grabbed == false)
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
                    if(Names[0] == Names[3] && chestAnim.PlayerInRange)
                    {
                        chestAnim.StartAnim();
                        FinishView();
                        tableCraft.DestroyHammer();
                        LockB.Play();
                        StartCoroutine(LockSound(LockF,1.3f));
                    }
                    if(currentObject.CompareTag("Chave"))
                    {
                        keys.KeyChange();
                        currentObject.gameObject.SetActive(false);
                        FinishView();
                    }
                }
            }

            if(getInHandAction.WasPressedThisFrame() && canFinish)
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
            teste = obj;
            if(obj != null)
            {
                if(!interacting)
                {
                    UIManager.instance.ChangeColor(Color.yellow);
                }
                if(interactAction.WasPressedThisFrame() && !interacting)
                {
                    currentObject = obj;
                    interacting = true;
                    if(boxCollider != null)
                    {
                        boxCollider.enabled = false;
                    }
                    if(obj.isMoving)
                    {
                        return;
                    }

                    Invoke("CanFinish", 1f);

                    if(currentObject.item.canGrab)
                    {
                        originPosition = currentObject.transform.position;
                        originRotation = currentObject.transform.rotation;
                        OnView.Invoke();
                        UIManager.instance.ChangeColor(new Color(0f, 0f, 0f, 0f));
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
            if(!interacting)
            {
                UIManager.instance.ChangeColor(Color.black);
            }
        }
    }

    void CanFinish()
    {
        canFinish = true;
        if(currentObject.item.canGrab)
        {
            UIManager.instance.InteractText(true);
            UIManager.instance.ExtraText(currentObject.item.texto);
        }
    }
    IEnumerator LockSound(StudioEventEmitter Lock, float timer)
    {
        yield return new WaitForSeconds(timer);
        Lock.Play();
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
        UIManager.instance.ExtraText(null);
        if(currentObject.item.canGrab)
        {
            currentObject.transform.SetParent(null);
            currentObject.transform.rotation = originRotation;
            UIManager.instance.ChangeColor(new Color(0f, 0f, 0f, 1f));
            StartCoroutine(MovingObject(currentObject, originPosition));
            if(boxCollider!=null)
            {
                if(ghostPlacement.onPillar &&  Names[0] == Names[1])
                {
                    boxCollider.enabled = false;
                    tableCraft.boxCollider.enabled = true;
                    
                }
                else if(Names[0] == Names[2])
                {
                    handPos.transform.rotation = HammerRotation;
                    boxCollider.enabled = true;
                }
                else
                {
                    boxCollider.enabled = true;
                }
            }

        }
        else
        {
            cam.transform.rotation = originRotation;
        }
        OnFinishView.Invoke();
        Grabbed = false;
        boxCollider = null;
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
        if(ghostPlacement.onPillar &&  Names[0] == Names[1])
        {
            boxCollider.enabled = false;
            tableCraft.boxCollider.enabled = true;
            
        }
        else
        {
            if(boxCollider != null)
            {
                boxCollider.enabled = true;
            }
        }
    }

    void RotateObject()
    {
        if(currentObject.item.canRotate)
        {
            if(boxCollider != null)
            {
                boxCollider.enabled = false;
            }
            Vector2 rotation = lookAction.ReadValue<Vector2>();
            currentObject.transform.Rotate(cam.transform.up, -Mathf.Deg2Rad*rotation.x*rotateSpeed, Space.World);
            currentObject.transform.Rotate(cam.transform.right, -Mathf.Deg2Rad*rotation.y*rotateSpeed, Space.World);
        }
    }

    void GrabObject()
    {
        if (currentObject.item.inHand && Grabbed != true)
        {
            currentObject.transform.rotation = handPos.transform.rotation;
            currentObject.transform.position = handPos.transform.position;
            currentObject.transform.SetParent(handPos.transform);
            if(boxCollider != null)
            {
                boxCollider.enabled = false;
            }
            Grabbed = true;
            OnFinishView.Invoke();
        }   
    }

    void PauseGame(bool pause)
    {
        pauseMenu.SetActive(!pause);
        Time.timeScale = Convert.ToInt32(!pause); // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
        camMovement.Freeze(pause);
        if(pause)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
