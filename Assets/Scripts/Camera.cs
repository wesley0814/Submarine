using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Target;
    public float follow_speed = 4.0f;
    public float z = -10.0f;

    Transform this_transform;
    Transform Target_transform;

    void Start()
    {
        this_transform = GetComponent<Transform>();
        Target_transform = Target.GetComponent<Transform>();
    }
    void Update()
    {
        this_transform.position = Vector2.Lerp(this_transform.position, Target_transform.position, follow_speed * Time.deltaTime);
        this_transform.Translate(0, 0, z);
    }
}
