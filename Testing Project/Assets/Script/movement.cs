using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = -9.1f;
    public float jumpHeight = 1f;

    public Transform ground_check;
    public float ground_dis = 0.4f;
    public LayerMask ground_mask;
    public bool isGround;

    public Vector3 velocity;
    public Vector3 move = new Vector3(0f,0f,0f);
    public CharacterController controller;
    public Animator animator;
    public float x;
 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(ground_check.position, ground_dis, ground_mask);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = 0;
        if (Input.GetKey(KeyCode.A))
        {
            x = -0.5f ;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 0.5f ;
        }


        //float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float z = Input.GetAxis("Vertical");

        animator.SetFloat("forward", z);
        //animator.SetFloat("right", x);

        this.transform.Rotate(new Vector3(0,x,0));
        move = transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (isGround) {
            animator.SetBool("jump", false);
        }
        else {
            animator.SetBool("jump", true);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.SetBool("attack", false);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
