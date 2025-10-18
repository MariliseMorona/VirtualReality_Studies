using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{

    public void OnInteract()
    {
        Debug.Log("Cube Interacted!");
    }

    public void StorInteract()
    {
        Debug.Log("Cube Interaction Stopped!");

    }
    
    void Update()
    {
       
        if (InputHandler.TryRayCastHit(out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
               OnInteract();
                // Add further interaction logic here
            }
        }
    }
}
