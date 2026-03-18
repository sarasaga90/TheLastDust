using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    //Movimiento
    public float moveSpeed;
    public float sprintSpeed;
    private float currentSpeed;
    public float jumpForce;
    public float gravityScale = 5f;
   
    private Vector3 moveDirection;
    public float VerticalVelocity => moveDirection.y;
    //Componentes
    public CharacterController charController;
    public Camera playerCamera;
    //Knockback
    public bool isKnocking;
    public float knocbackLength = .5f;
    private float knockbackCounter;
    public Vector2 knockbackPower;
    //Tackle
    public float tackleForce = 12f;
    public float tackleDuration = 0.3f;
    private bool isTackling;
    private float tackleCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!isKnocking && !isTackling)
        {
            //Tackle
            if (Input.GetButtonDown("Fire1"))
            {
                StartTackle();
            }

            float yStore = moveDirection.y;

            //Movimiento
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));

            //Sprint
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = sprintSpeed;
            }
            else
            {
                currentSpeed = moveSpeed;
            }

            moveDirection = moveDirection * currentSpeed;
            moveDirection.y = yStore;

            //Salto
            if (charController.isGrounded && Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            }
        }

        if(isKnocking)
        {
            
            knockbackCounter -= Time.deltaTime;

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (knockbackCounter <= 0)
            {
                isKnocking = false;
            }
        }

        if (isTackling)
        {
            tackleCounter -= Time.deltaTime;

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (tackleCounter <= 0)
            {
                isTackling = false;
            }

            return; 
        }


    }
    
    public void Knockback(Vector3 enemyPosition)
    { 
        isKnocking= true;
        knockbackCounter = knocbackLength;

        Vector3 knockDirection = (transform.position - enemyPosition).normalized;

        moveDirection = knockDirection * knockbackPower.x;
        moveDirection.y = knockbackPower.y;
        
        Debug.Log("Knocking back");

    }

    public void Bounce()
    {
        moveDirection.y = jumpForce * 0.6f;
    }

    public void StartTackle()
    {
        isTackling = true;
        tackleCounter = tackleDuration;

        Vector3 forward = transform.forward;

        moveDirection = forward * tackleForce;
        moveDirection.y = 0f;
    }


}
