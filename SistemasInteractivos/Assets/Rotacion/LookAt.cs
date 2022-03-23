using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Vector3 diff, velocity, mousePos, aceleration;
    [SerializeField] float speed, angle;
    [SerializeField] bool acelerationON, moveON;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            acelerationON = !acelerationON;
        }
        if (Input.GetKeyDown("x"))
        {
            moveON = !moveON;
        }
        mousePos = GetWorldMousePosition();
        diff = mousePos - transform.position;

        RotateTo(acelerationON);
        //Vector3 tangent = new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle));
        //float tetha= Mathf.Atan2(tangent.y, tangent.x);

        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
        if (moveON == true)
        {
            Move(acelerationON);
        }


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
    void Move(bool acelerationON)
    {
        if (acelerationON == true)
        {
            aceleration = diff;
            velocity += aceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
        else
        {
            velocity = diff.normalized * speed;
            transform.position += velocity * Time.deltaTime;
        }
    }
    void RotateTo(bool acelerationO)
    {
        if (acelerationO == true)
        {
            if (moveON == true)
            {
                angle = Mathf.Atan2(velocity.y, velocity.x);
            }
            else
            {
                angle = Mathf.Atan2(diff.y, diff.x);
            }

        }
        else
        {
            angle = Mathf.Atan2(diff.y, diff.x);
        }
    }

}
