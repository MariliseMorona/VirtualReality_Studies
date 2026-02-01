using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsOccupied()
    {
        return transform.childCount > 0;
    }
}
