using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChase : MonoBehaviour
{
    private GameObject target;
    private float sphereSpeed = 3.0f;
 
    void Start ()
    {
        target = GameObject.Find("Cube");
    }
 
    void Update ()
    {
        if(target.GetComponent<CubeMove>().invaded == true)
        {
            transform.position += transform.forward * sphereSpeed * Time.deltaTime;
        }
    }
}