using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyf : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.01f;
    private float downspeed = 0.1f;
    public bool down;
    public bool enemystop;
    public bool destroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destroy == true)
        {
            Destroy (this.gameObject);
        }
        if(down == true)
        {
            StartCoroutine("StopHoge");
        }
        else if(down == false && enemystop == true)
        {
            transform.Translate(0f,0f,0f);
        }
        else
        {
            transform.Translate(0f,0f,-speed);
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
        transform.Translate(0f,0f,downspeed);
        yield return new WaitForSeconds(0.3f);
        down = false;
        enemystop = true;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "DestroyArea" )
        {
            destroy = true;
        }
    }
}
