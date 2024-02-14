using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxReseter : MonoBehaviour
{
    public Transform playerObject;
    public Vector3 playerSpawnLocation;
    string scene;
    private CharacterController characterController; // Reference to CharacterController component

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;

        playerObject = GameObject.FindGameObjectWithTag("Player").transform;
        playerSpawnLocation = playerObject.transform.position;

        // Get reference to CharacterController component
        characterController = playerObject.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            SceneManager.LoadScene(scene);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            print("collision player");
            // Disable CharacterController temporarily
            characterController.enabled = false;
            playerObject.transform.position = playerSpawnLocation;
            // Re-enable CharacterController after setting position
            characterController.enabled = true;
        }
    }
}