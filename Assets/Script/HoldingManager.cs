using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingManager : MonoBehaviour
{

    public static HoldingManager Instance { get; private set; }
    private GameObject heldObject;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float holdDistance = 0.5f;
    [SerializeField] private float spead = 10f;

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
    
    void Update()
    {
        if (heldObject != null)
        {
            Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * holdDistance;
            heldObject.transform.position = Vector3.Lerp(heldObject.transform.position, targetPosition, Time.deltaTime * spead);
        }
    }
}
