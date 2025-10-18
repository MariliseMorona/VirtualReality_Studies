using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    public static bool TryRayCastHit(out RaycastHit hit)
    {
        #if ENABLE_INPUT_SYSTEM
        if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                return true;
            }
        }
        #endif

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                return true;
            }
        }

        hit = default;
        return false;
    }
}
