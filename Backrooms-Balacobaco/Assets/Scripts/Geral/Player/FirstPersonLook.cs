using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    private float sensitivity = 2f;
    public float baseSensivity = 2f;
    public float smoothing = 1.5f;

    [SerializeField] private Camera mcam;

    [SerializeField] private float zoomVision = 30;
    [SerializeField] private float normalVision = 60;

    Vector2 velocity;
    Vector2 frameVelocity;

    public InputActionAsset inputActions;
    private InputAction lookAction;
    private InputAction zoomAction;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        lookAction = InputSystem.actions.FindAction("Look");
        zoomAction = InputSystem.actions.FindAction("Zoom");

        sensitivity = baseSensivity;
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = lookAction.ReadValue<Vector2>();
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);


        if (zoomAction.WasPressedThisFrame())
        {
            mcam.fieldOfView = zoomVision;
        }

        if (zoomAction.WasReleasedThisFrame())
        {
            mcam.fieldOfView = normalVision;
        }
    }

    public void Freeze(bool freeze)
    {
        if(freeze)
        {
            sensitivity = 0;
        }
        else
        {
            sensitivity = baseSensivity;
        }
    }
}
