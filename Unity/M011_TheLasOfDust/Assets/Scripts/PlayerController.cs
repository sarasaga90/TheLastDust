using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;

    private Vector3 moveDirection;
    public float VerticalVelocity => moveDirection.y;

    public CharacterController charController;
    public Camera playerCamera;

    public bool isKnocking;
    public float knocbackLength = .5f;
    private float knockbackCounter;
    public Vector2 knockbackPower;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(!isKnocking)
        {
            float yStore = moveDirection.y;

            //Movimiento
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection = moveDirection * moveSpeed;
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

    
}
