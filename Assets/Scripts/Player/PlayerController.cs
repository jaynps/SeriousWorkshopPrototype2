
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    //private CharacterController controller;
    private Rigidbody rb;
    private Vector2 moveInput;
    [SerializeField]
    public float moveSpeed = 5f;

    private float rotationSpeed  = 5f;

    private Vector3 movement;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        inputActions.Enable();

    }

    void OnDisable()
    {
        inputActions.Disable();
    }
    
    void Update()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        Debug.Log("The current input are x: "+ moveInput.x + " y: " + moveInput.y);

        movement = new Vector3(moveInput.x, 0f, moveInput.y);

      /*  if(movement.magnitude > 0.1f)
        {
            //transform.Translate(movement * movespeed * Time.deltaTime);

            //movement character controll

            Quaternion targetRotation = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }*/
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, rb.linearVelocity.y, moveInput.y * moveSpeed);

         Quaternion targetRotation = Quaternion.LookRotation(movement);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
    }
}
