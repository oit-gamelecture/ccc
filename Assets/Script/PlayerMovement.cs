using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float acceleration = 0.01f;
    public float leftRightSpeed = 4f;
    public float limit = 5f;
    public Animator animator;
    private bool hitchecker;
    public bool hit;
    public bool stand;
    public bool climb;
    public bool start;
    public bool clear;
    public bool goal;
    private GameObject mainCamera;
    private GameObject subCamera;
    private GameObject clearObject;
    private GameObject Character;
    public Vector3 targetPosition;
    private float goalspeed = 2.0f;
    [SerializeField] Transform target;
    public float rotationspeed = 60f;




    // Start is called before the first frame update
    void Start()
    {

        mainCamera = GameObject.Find("MainCamera");
        subCamera = GameObject.Find("SubCamera");
        clearObject = GameObject.Find("ClearObject");
        Character = GameObject.Find("m01_blazer_000_h");
        hitchecker = false;

        subCamera.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {



        if (hit == true &&  hitchecker==false)
        {
            StartCoroutine(Hoge());
        }

        else if (climb == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        }

        else if (clear == true)
        {
            mainCamera.SetActive(false);
            subCamera.SetActive(true);
            Destroy(clearObject);
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, goalspeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
        }

        else if (start == true)
        {
          
        }

        else
        {
            subCamera.SetActive(false);
            mainCamera.SetActive(true);
            animator.SetTrigger("Run");

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
            moveSpeed += Time.deltaTime * acceleration;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (transform.position.x > -limit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (transform.position.x < limit)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("a_Jump");
            }
        }

    }
    IEnumerator Hoge()
    {
        animator.SetTrigger("Fall");
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        yield return new WaitForSeconds(0.8f);

        moveSpeed = 0;
        animator.SetTrigger("Stand");
        Debug.Log(moveSpeed);
        yield return new WaitForSeconds(2.0f);

        animator.SetTrigger("Run");
        moveSpeed = 4.5f;
        hit = false;
        hitchecker = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Stairs")
        {
            climb = true;
        }

        if (collision.gameObject.name == "ClearObject")
        {
            clear = true;
        }

        if(collision.gameObject.name == "GoalObject")
        {
            goal = true;
            animator.SetBool("Goal", goal);
            Destroy(Character);
        }
    }

    void OnCollisionStay(Collision collision)
    {
         if (collision.gameObject.CompareTag ("Stairs"))
        {
            climb = true;          
        }

         if (collision.gameObject.name == "StartObject")
        {
            start = true; 
        }
        if (collision.gameObject.CompareTag ("enemy"))
        {
            hit = true;
        }

    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag ("Stairs"))
        {
            climb = false;
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            animator.SetTrigger("Run");
        }
    }
}