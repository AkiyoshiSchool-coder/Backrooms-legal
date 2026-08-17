using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;
    private InputAction jumpAction;
    Rigidbody box;

    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        // Get rigidbody.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Jump when the Jump button is pressed and we are on the ground.
        if (jumpAction.triggered && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            
            if (box != null)
            {
                box.AddForce(Vector3.up * 100 * jumpStrength);
            }
            
            Jumped?.Invoke();
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
}
