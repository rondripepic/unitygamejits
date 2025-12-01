using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraAnchor;
    public Quaternion cameraRotation;
    public GameObject cameraobject;

    private PlayerControls controls;
    private Vector2 moveInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    void OnEnable() => controls.Player.Enable();
    void OnDisable() => controls.Player.Disable();

    void Update()
    {
        Vector3 moveDir = cameraobject.transform.eulerAngles;
        if (moveDir.sqrMagnitude > 0.01f) 
        {
            moveDir.Normalize();
            transform.position += moveDir * speed * Time.deltaTime;
        }
    }
}
