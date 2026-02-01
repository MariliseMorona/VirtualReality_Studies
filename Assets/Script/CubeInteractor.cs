using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{

    private bool isHold = false;



    public void OnInteract()
    {
        Debug.Log("Cube Interacted!");
        HoldingManager.Instance.PickUp(gameObject);

        isHold = true;

        if (HoldingManager.Instance.TryPickUp(gameObject))
        {
            isHold = true;
        } else if (isHold)
        {
            HoldingManager.Instance.Drop();
            isHold = false;
        }
    }

    public void StorInteract()
    {
        Debug.Log("Cube Interaction Stopped!");

    }
    
    void Update()
    {
       
        if (InputHandler.TryRayCastHit(out RaycastHit hitObject))
        {
            if (hitObject.transform == transform)
            {
               OnInteract();
            }
        }
    }
}
