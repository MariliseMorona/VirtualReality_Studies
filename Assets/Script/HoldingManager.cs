using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingManager : MonoBehaviour
{

    private GameObject heldObject;
    public static HoldingManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PickUp(GameObject obj)
    {
        if (heldObject == null)
        {
            heldObject = obj;
            Debug.Log("Picking up " + obj.name);

            var body = heldObject.GetComponent<Rigidbody>();
            if (body != null)
            {
                // nÃo é a fisica gravitacional que vai segurar o objeto mas sim o movimento queeu fizer
                body.isKinematic = true;
            }

            heldObject = null;
        }
    }
    
    public void Drop()
    {
        if (heldObject != null)
        {
            Debug.Log("Dropping " + heldObject.name);

            var body = heldObject.GetComponent<Rigidbody>();
            if (body != null)
            {
                body.isKinematic = false;
            }

            heldObject = null;
        }
    }
}
