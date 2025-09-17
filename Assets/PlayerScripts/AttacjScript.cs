using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacjScript : MonoBehaviour
{   

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("hey im attacking lol");
        }
    }
}
