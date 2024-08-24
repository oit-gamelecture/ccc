using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    public Animator enemyanimator;
    public bool down;
    public bool help;
    public Vector3 targetPosition;
    public float speed = 3.0f;
    public float downspeed = -0.6f;
    [SerializeField] Transform movetarget;
    // Start is called before the first frame update
    void Start()
    {
        down = false;
        help = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (down == false)
        {
            Vector3 direction = (movetarget.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, movetarget.position, speed * Time.deltaTime);
        }

        if (down == true)
        {
            StartCoroutine(Down());
        }

    }

    IEnumerator Down()
    {
        enemyanimator.SetTrigger("Fall");
        transform.Translate(Vector3.back * downspeed * Time.deltaTime, Space.World);
        yield return new WaitForSeconds(0.8f);
        downspeed = 0;
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            down = true;
        }
    }
}
