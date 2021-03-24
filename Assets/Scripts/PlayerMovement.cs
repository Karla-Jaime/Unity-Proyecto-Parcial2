using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput inputActions;

    Animator anim;

    private Vector2 movementInput;
    [SerializeField]

    private float moveSpeed = 50f;


    private Vector3 inputDirection;

    private Vector3 moveVector;

    private Quaternion currentRotation;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    
    public GameObject inventoryUI;

    void Awake()
    {
        anim = GetComponent<Animator>();
        inputActions = new PlayerInput();
        inputActions.Player.Movement.performed += context => movementInput = context.ReadValue<Vector2>();
        inputActions.Player.Inventory.performed += context => Inventory();
    }

    void Start(){
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    
    void FixedUpdate()
    {
        float h = movementInput.x;
        float v = movementInput.y;

        Vector3 targetInput = new Vector3(h,0,v);

        inputDirection = Vector3.Lerp(inputDirection, targetInput, Time.deltaTime * 10f);

        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;
        camForward.y = 0f;
        camRight.y =0f;

        Vector3 desiredDirection = camForward * inputDirection.z + camRight * inputDirection.x;

        Move(desiredDirection);
        Turn(desiredDirection);

        if(Keyboard.current.dKey.isPressed || Keyboard.current.aKey.isPressed || Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            anim.SetBool("Walk_Anim", true);
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
        }
    }

    void Move(Vector3 desiredDirection)
    {
        moveVector.Set(desiredDirection.x, 0f, desiredDirection.z);
        moveVector = moveVector * moveSpeed * Time.deltaTime;
        transform.position += moveVector;
    }
        

    void Turn(Vector3 desiredDirection)
    {
        if((desiredDirection.x > 0.1 || desiredDirection.x < -0.1) || (desiredDirection.z > 0.1 || desiredDirection.z < -0.1))
        {
            currentRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = currentRotation;
        }
        else
            transform.rotation = currentRotation;
    }

    void Inventory(){
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
        
        private void OnEnable()
        {
            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }
}
