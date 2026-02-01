using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{

<<<<<<< HEAD
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
=======
    public void OnInteract()
    {
        Debug.Log("Cube Interacted!");
>>>>>>> 8c05bc99 (add files project)
    }

    public void StorInteract()
    {
        Debug.Log("Cube Interaction Stopped!");

    }
    
    void Update()
    {
       
<<<<<<< HEAD
        if (InputHandler.TryRayCastHit(out RaycastHit hitObject))
        {
            if (hitObject.transform == transform)
            {
               OnInteract();
=======
        if (InputHandler.TryRayCastHit(out RaycastHit hit))
        {
            if (hit.transform == transform)
            {
               OnInteract();
                // Add further interaction logic here
>>>>>>> 8c05bc99 (add files project)
            }
        }
    }
}
