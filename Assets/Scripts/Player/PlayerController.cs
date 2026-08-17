

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions inputActions;
    //private CharacterController controller;

    //Movement Action
    private Rigidbody rb;

    private Animator animator;
    private Vector2 moveInput;
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField]
    private float rotationSpeed  = 5f;

    private Vector3 movement = Vector3.zero;

    //Interaction Actions Variables
    [SerializeField]
    private InteractionZone interactionZone;
    void Awake()
    {
        inputActions = new InputSystem_Actions();
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();
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
        if(GameManager.Instance.GetGameState()!= GameState.Playing)
            return;
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();

        //Debug.Log("The current input are x: "+ moveInput.x + " y: " + moveInput.y);

        movement = new Vector3(moveInput.x, 0f, moveInput.y);

        if(movement.magnitude> 0.1f)
        {
            animator.SetBool("IsMoving",true);
        }
        else
        {
            animator.SetBool("IsMoving",false);
        }

        if(inputActions.Player.Interact.WasPressedThisFrame())
        {
            //call the interact function
            interactionZone.Interact();

        }

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
        if(movement.magnitude > 0.1f)
        {
            rb.linearVelocity = new Vector3(moveInput.x * moveSpeed, rb.linearVelocity.y, moveInput.y * moveSpeed);
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            rb.angularVelocity = Vector3.zero;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision with " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered a trigger zone " + other.gameObject.name);
    }
}
