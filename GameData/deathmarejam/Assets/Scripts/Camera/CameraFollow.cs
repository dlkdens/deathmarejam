using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Transform target;
    public Vector3 offset;
    public float smooth;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        /*
        if(Input.GetKey(KeyCode.Q)) offset.x = -15;
        else if(Input.GetKey(KeyCode.E)) offset.x = 15;
        else offset.x = 0;

        if(Input.GetKey(KeyCode.W)) offset.y = 6.5f;
        else if(Input.GetKey(KeyCode.S)) offset.y = -6.5f;
        else offset.y = 0;
        */

        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, smooth);
    }
}
