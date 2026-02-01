using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler
{
    public static bool TryRayCastHit(out RaycastHit hitObject)
    {

        //         if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
        //         {
        //             Ray ray = Camera.main.ScreenPointToRay(UnityEngine.InputSystem.Mouse.current.position.ReadValue());
        //             if (Physics.Raycast(ray, out hitObject))
        //             {
        //                 return true;
        //             }
        //         }
        // #endif

        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            var position = Touchscreen.current.primaryTouch.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out hitObject))
            {
                Debug.Log("Raycast hit: " + hitObject.transform.name);
                return true;
            }
        }

        hitObject = default;
        return false;
    }
}
