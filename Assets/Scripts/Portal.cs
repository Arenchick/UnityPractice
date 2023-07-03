using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Transform positionTeleportA;
    public int levelNumber = 1;

    private void OnTriggerEnter(Collider collider)
    {
        // collider.transform.position = positionTeleportA.position;
        SceneManager.LoadScene(levelNumber);

        Debug.Log("Enter " + collider.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit " + other.name);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay " + other.name);
    }
}
