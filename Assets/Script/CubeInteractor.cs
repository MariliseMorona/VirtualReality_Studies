using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable, IScannable
{
    private bool isHold = false;
    private bool isLocked = false;
    private bool isScanned = false;



    public void OnInteract()
    {
        if (isLocked) return;

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

    public void SetLocked(bool locked)
    {
        isLocked = locked;
    }

    public void SetScanned(bool scanned)
    {
        isScanned = scanned;
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
