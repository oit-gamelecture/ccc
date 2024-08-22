using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public bool invaded;
    private float speed = 3.0f;

    void Update()
    {
        if (Input.GetKey (KeyCode.UpArrow)) {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.DownArrow)) {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }
 
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CautionArea" )
        {
            invaded = true;
        }
    }
 
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CautionArea" )
        {
            invaded = false;
        }
    }
}