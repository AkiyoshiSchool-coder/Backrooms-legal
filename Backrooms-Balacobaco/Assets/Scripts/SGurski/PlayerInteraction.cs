using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rayRange = 2.5f;
    [SerializeField] private float interactSpeed = 5f;
    [SerializeField] private float rotateSpeed = 200f;

    public InputActionAsset inputActions;
    private InputAction interactAction;
    private InputAction lookAction;
    private InputAction dropAction;

    public Transform ObjectViewer;
    public UnityEvent OnView;
    public UnityEvent OnFinishView;

    private Interactables currentObject;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private bool interacting;
    private bool canFinish;

    public FirstPersonLook camMovement;


    void Start()
    {
        cam = Camera.main;
        interactAction = InputSystem.actions.FindAction("Interact");
        lookAction = InputSystem.actions.FindAction("Look");
        dropAction = InputSystem.actions.FindAction("Drop");
    }

    void Update()
    {
        InteractCheck();
    }

    void InteractCheck()
    {
        if(interacting)
        {
            if(currentObject.item.canGrab && interactAction.IsPressed())
            {
                RotateObject();
                return;
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
                if(interactAction.IsPressed())
                {
                    if(obj.isMoving)
                    {
                        return;
                    }

                    OnView.Invoke();

                    currentObject = obj;
                    interacting = true;

                    Invoke("CanFinish", 1f);

                    if(currentObject.item.canGrab)
                    {
                        originPosition = currentObject.transform.position;
                        originRotation = currentObject.transform.rotation;
            
                        StartCoroutine(MovingObject(currentObject, ObjectViewer.position));
                    }
                    else
                    {
                        
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
        UIManager.instance.InteractText(true);
    }

    void FinishView()
    {
        canFinish = false;
        interacting = false;
        UIManager.instance.InteractText(false);
        if(currentObject.item.canGrab)
        {
            currentObject.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentObject, originPosition));
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
        if(interacting == true)
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
        Vector2 rotation = lookAction.ReadValue<Vector2>();
        currentObject.transform.Rotate(cam.transform.up, -Mathf.Deg2Rad*rotation.x*rotateSpeed, Space.World);
        currentObject.transform.Rotate(cam.transform.right, -Mathf.Deg2Rad*rotation.y*rotateSpeed, Space.World);
    }
}
