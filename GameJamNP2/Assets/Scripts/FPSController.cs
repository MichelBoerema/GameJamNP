using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90f;
    public float normalHeight, crouchHeight;
    public float crouchSpeed = 3.5f;
    public bool IsCrouching = false;
    public float CrouchJumpSpeed = 5.0f;
    public int Health;
    public TextMeshProUGUI text;
    public bool TakingDamage;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public Animator animator;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        text.SetText(Health.ToString());
        if (Health <= 0)
        {
            canMove = false;
            animator.SetBool("Dead", true);
        }
        if (!IsCrouching) //Is currently NOT crouching
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            this.GetComponent<CapsuleCollider>().height = 1;
            characterController.height = 2f;
            this.GetComponentInChildren<Transform>().localScale = new Vector3(1, 1, 1);
        }
        else   //IS currently crouching
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = crouchSpeed * Input.GetAxis("Vertical");
            float curSpeedY = crouchSpeed * Input.GetAxis("Horizontal");
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = CrouchJumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            this.GetComponent<CapsuleCollider>().height = crouchHeight;
            characterController.height = crouchHeight * 2;
            this.GetComponentInChildren<Transform>().localScale = new Vector3(1, crouchHeight, 1);
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) //Crouch Controller
        {
            IsCrouching = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            IsCrouching = false;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)

    } 
 
  

    public bool OnBox()
    {
        int horizontalRays = 3; // Adjust the number of horizontal rays as needed
        int verticalRays = 3; // Adjust the number of vertical rays as needed
        float horizontalSpreadAngle = 69f; // Adjust the horizontal spread angle as needed
        float verticalSpreadAngle = 69f; // Adjust the vertical spread angle as needed
        float maxDistance = 2.5f; // Maximum distance to check for collision

        for (int i = 0; i < horizontalRays; i++)
        {
            for (int j = 0; j < verticalRays; j++)
            {
                // Calculate the direction of the ray with a spread in both horizontal and vertical directions
                Vector3 direction = Quaternion.AngleAxis(i * horizontalSpreadAngle / (horizontalRays - 1) - horizontalSpreadAngle / 2f, Vector3.up) *
                                    Quaternion.AngleAxis(j * verticalSpreadAngle / (verticalRays - 1) - verticalSpreadAngle / 2f, Vector3.right) *
                                    Vector3.down;

                Debug.DrawRay(transform.position, direction * maxDistance, Color.blue); // Draw the ray

                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit, maxDistance))
                {
                    if (hit.collider.CompareTag("Box"))
                    {
                        return true; // If any ray hits the box, return true
                    }
                }
            }
        }

        return false; // If no ray hits the box, return false
    }


    IEnumerator CallFunctionRepeatedly()
    {
        while (TakingDamage)
        {
            TakeDamage(10);
            yield return new WaitForSeconds(1f);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (Health > 0)
        {
            Health -= damageAmount;
        }
    }

    public void GainHealth(int healthAmount)
    {
        Health += healthAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            TakingDamage = true;
            StartCoroutine(CallFunctionRepeatedly());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            TakingDamage = false;
        }
    }
}
