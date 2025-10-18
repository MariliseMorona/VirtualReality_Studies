using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation; 

public class StartExperience : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    // Start is called before the first frame update
    public void OnStratExperiente(ARPlane plane)
    {
        Instantiate(cube, plane.center, Quaternion.identity);
    }
}
