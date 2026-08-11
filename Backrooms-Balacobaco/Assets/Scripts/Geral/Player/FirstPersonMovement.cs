using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public InputActionAsset inputActions;
    private InputAction runAction;
    private InputAction moveAction;

    Rigidbody rigidbody;
    Rigidbody box;
    [SerializeField] private float offset;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        runAction = InputSystem.actions.FindAction("Run");
    }

    void FixedUpdate()
    {

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = moveAction.ReadValue<Vector2>() * targetMovingSpeed;

        // Apply movement.
        rigidbody.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y);
        if(box != null)
        {
            Debug.Log("OI");
            box.linearVelocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.linearVelocity.y, targetVelocity.y + offset);
        }
    }

    public void PushingObject(Rigidbody rigidbody)
    {
        box = rigidbody;
    }
    public void StopPushing()
    {
        box = null;
    }

    public void Stop(bool stoporNot)
    {
        if(stoporNot)
        {
        speed = 0;
        runSpeed = 0;
        }
        else
        {
            speed = 5;
            runSpeed = 9;
        }
    }
}