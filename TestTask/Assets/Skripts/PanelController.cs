using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public FixedJoystick joy;
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        
        Quaternion rotX = Quaternion.AngleAxis(speed, new Vector3 (1, 0, 0));
        Quaternion rotXM = Quaternion.AngleAxis(speed, new Vector3(-1, 0, 0));
        Quaternion rotZ = Quaternion.AngleAxis(speed, new Vector3(0, 0, 1));
        Quaternion rotZM = Quaternion.AngleAxis(speed, new Vector3(0, 0, -1));
        
        if (joy.Horizontal < 0)
        {
            transform.rotation *= rotZ;
            
        }
        if (joy.Horizontal > 0)
        {
            transform.rotation *= rotZM;
            
        }
        if (joy.Vertical > 0)
        {
            transform.rotation *= rotX;

        }
        if (joy.Vertical < 0)
        {
            transform.rotation *= rotXM;

        }
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation*= rotX;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation*= rotXM;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation *= rotZ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation *= rotZM;
        }
    }
}
