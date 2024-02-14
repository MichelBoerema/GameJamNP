using UnityEngine;

public class FPSPickup : MonoBehaviour
{
    private Rigidbody heldObject; // Reference to the object being held.
    public Camera cam;
    public float originalDistance; // Distance from camera to the picked-up object.
    private Vector3 smoothVelocity; // Velocity for smoothing the movement.
    public float smoothSpeed = 5.0f; // Adjust this to control the smoothing amount.
    public float scrollSensitivity = 1.0f; // Adjust this to control scroll sensitivity.
    public float rotationSpeed = 10.0f; // Adjust this to control the rotation speed.
    public bool isThrowing = false; // Flag to track if the object is in throw state.
    public FPSController controller;
    public bool canJump;

    void Update()
    {
        if (originalDistance > 5)
        {
            originalDistance = 5;
        }
        if (!controller.OnBox())
        {
            if (Input.GetMouseButtonDown(1)) // Left mouse button pressed
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide))
                {
                    if (hit.collider.CompareTag("Box"))
                    {
                        heldObject = hit.collider.GetComponent<Rigidbody>();
                        heldObject.freezeRotation = true;
                        heldObject.useGravity = false;
                        originalDistance = Vector3.Distance(cam.transform.position, heldObject.transform.position);
                    }
                }
            }
            else if (Input.GetMouseButtonUp(1) && heldObject != null) // Left mouse button released
            {
                heldObject.freezeRotation = false;
                heldObject.useGravity = true;
                if (isThrowing)
                {
                    heldObject.velocity = Vector3.zero; // Clear any existing velocity.
                    Vector3 throwDirection = (heldObject.transform.position - cam.transform.position).normalized;
                    heldObject.AddForce(throwDirection * 10.0f, ForceMode.Impulse); // Adjust the force for the throw.
                }
                heldObject = null;
                isThrowing = false;
            }
            
            // If we're holding an object, move it smoothly with the mouse.
            if (heldObject != null)
            {
                Vector3 targetPosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, originalDistance));
                heldObject.transform.position = Vector3.SmoothDamp(heldObject.transform.position, targetPosition, ref smoothVelocity, 1.0f / smoothSpeed);
            }
        }
        if (controller.OnBox() && heldObject != null)
        {
            heldObject.freezeRotation = false;
            heldObject.useGravity = true;
            if (isThrowing)
            {
                heldObject.velocity = Vector3.zero; // Clear any existing velocity.
                Vector3 throwDirection = (heldObject.transform.position - cam.transform.position).normalized;
                heldObject.AddForce(throwDirection * 10.0f, ForceMode.Impulse); // Adjust the force for the throw.
            }
            heldObject = null;
            isThrowing = false;
        }
       
        if (!controller.OnBox())
        {


            // Scroll to change the distance from camera to object.
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0 && heldObject != null)
            {
                originalDistance += scrollInput * scrollSensitivity;
            }

            // Rotate the held object with Q and E keys.
            if (heldObject != null)
            {
                float rotationInput = Input.GetAxis("Rotation");
                heldObject.transform.Rotate(Vector3.forward, rotationInput * rotationSpeed * Time.deltaTime);
            }

            if (isThrowing)
            {
                originalDistance = 1f;
            }
            else
            {
                originalDistance += scrollInput * scrollSensitivity;
            }
        }
        // Toggle the throwing state when pressing "F".
        if (Input.GetKeyDown(KeyCode.F) && heldObject != null)
        {
            isThrowing = !isThrowing;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            originalDistance = originalDistance + 2.3f;
        }
        
    }
}
