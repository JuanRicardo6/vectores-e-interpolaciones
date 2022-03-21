using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] Vector3 mousePos;
    
    void Update()
    {
        mousePos = GetWorldMousePosition();
        transform.position = mousePos;
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        worldPos.x = CheckLimits(worldPos.x);
        worldPos.y = CheckLimits(worldPos.y);
        return worldPos;
    }
    float CheckLimits(float x)
    {
        if (x > 5)
        {
            x = 5;
        }
        if (x < -5)
        {
            x = -5;
        }
        return x;
    }
}
