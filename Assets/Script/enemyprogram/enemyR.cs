using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyR : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.01f;
    private float downspeed = 0.1f;
    private float rotateSpeed = 10f;
    public bool down;
    public bool enemystop;
    public bool invaded;
    public bool invadeded;
    public bool destroy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(down == true)
        {
            StartCoroutine("StopHoge");
        }
        else if(down == false && enemystop == true)
        {
            transform.Translate(0f,0f,0f);
        }
        else if(invaded == true && invadeded == false)
        { 
            Vector3 movedira= new Vector3(speed, 0, 0);
            transform.position += movedira;
            transform.forward = Vector3.Slerp(transform.forward, movedira, Time.deltaTime * rotateSpeed);
        }
        else if(invaded == true && invadeded == true)
        {
            Vector3 movedirb= new Vector3(0, 0,-speed );
            transform.position += movedirb;
            transform.forward = Vector3.Slerp(transform.forward, movedirb, Time.deltaTime * rotateSpeed);
        }
        else
        {
            Vector3 movedir= new Vector3(0, 0,-speed );
            transform.position += movedir;
            transform.forward = Vector3.Slerp(transform.forward, movedir, Time.deltaTime * rotateSpeed);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="m01_blazer_000_h")
        {
            down = true;
        }
    }
    IEnumerator StopHoge()
    {
        Vector3 movedirc= new Vector3(0, 0,-speed );
            transform.position += movedirc;
            transform.forward = Vector3.Slerp(transform.forward, movedirc, Time.deltaTime * rotateSpeed);
        yield return new WaitForSeconds(0.3f);
        down = false;
        enemystop = true;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "PlayerArea" )
        {
            invaded = true;
        }else if(other.gameObject.name == "SideArea")
        {
            invadeded = true;
        }else if (other.gameObject.name == "DestroyArea" )
        {
            destroy = true;
        }
    }
}
