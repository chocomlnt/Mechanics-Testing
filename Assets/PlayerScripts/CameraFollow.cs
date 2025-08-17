using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 8.5f;
    public Transform target;

    void Start()
    {
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, target.position.z - 15f);
    } 
    void Update()
    {
        UnityEngine.Vector3 newPos = new UnityEngine.Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = UnityEngine.Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
