using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{

    public static Vector2 GetMousePosition2d()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);  //konvertera position på skärmen till world position samt musets position
        
    }
}
