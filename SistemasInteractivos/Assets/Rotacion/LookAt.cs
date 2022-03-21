using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] Vector3 diff, velocity, mousePos, aceleration;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = GetWorldMousePosition();
        diff = mousePos - transform.position;
        float angle=Mathf.Atan2(velocity.y,velocity.x);
        
        //Vector3 tangent = new Vector3(-Mathf.Sin(angle), Mathf.Cos(angle));
        //float tetha= Mathf.Atan2(tangent.y, tangent.x);

        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
        //velocity = diff.normalized*speed;
        aceleration = diff;
        Move();
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
    void Move()
    {
        velocity += aceleration*Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
    
}
