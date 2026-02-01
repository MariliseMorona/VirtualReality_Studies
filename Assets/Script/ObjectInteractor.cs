using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour, IInteractable
{
    private bool isHeld = false;
    private bool isLocked = false;
    private bool isScanned = false;

    // Código referente ao desafio #4 
    private Animator animator;
    private bool isBouncing = true;

    [SerializeField] private SOObjectInfo objectInfo;
    [SerializeField] private float infoDisplayHeight = 2f;

    public void OnInteract()
    {
        Debug.Log("Interagindo com o cubo!");

        if (isLocked) return;

        if (HoldingManager.Instance.TryPickUp(gameObject))
        {
            isHeld = true;

            // ** Código referente ao desafio #4
            if (isBouncing)
            {
                animator.SetBool("isBouncing", true);
                animator.speed = 0; 
                isBouncing = false;
            }
            // ** Código referente ao desafio #4 

            ShowObjectInfo();
        }
        else if (isHeld)
        {
            HoldingManager.Instance.Drop();
            isHeld = false;

            // ** Código referente ao desafio #4
            if (!isBouncing)
            {
                animator.SetBool("isBouncing", false);
                animator.speed = 0; 
                isBouncing = false;
            }
            // ** Código referente ao desafio #4 

            HideObjectInfo();
        }
    }

    public void StopInteract()
    {
        Debug.Log("Parando de interagir com o cubo!");
    }

    // Update is called once per frame
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

    private void ShowObjectInfo()
    {
        if (objectInfo == null || isScanned == false) return;

        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetObjectInfo(objectInfo);
            infoController.SetVisible(true);

            infoController.transform.SetParent(transform);
            infoController.transform.localPosition = new Vector3(0, infoDisplayHeight, 0);
        }
    }

    private void HideObjectInfo()
    {
        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetVisible(false);
            infoController.transform.SetParent(null);
        }
    }

    public void SetLocked(bool locked = true)
    {
        isLocked = locked;
    }

    public void SetScanned(bool scanned = true)
    {
        isScanned = scanned;
    }
}

