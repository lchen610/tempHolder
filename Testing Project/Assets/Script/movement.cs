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

    public static int playerHP;
    public static int playerDMG = 1;
    public static bool isGameOver;

    float ab1 = 0;
    float ab2 = 0;

    public healthBarController healthBarController;
    public int maxHp = 100;

    public static bool isDmgMotion = false;
 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        isGameOver = false;
        healthBarController.SetMax(100);
        playerHP = maxHp;
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
            isDmgMotion = true;
        }
        else
        {
            animator.SetBool("attack", false);
            isDmgMotion = false;
        }

        if (ab1 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                animator.SetTrigger("combo");
                isDmgMotion = true;
                ab1 = 5;
            }
        }
        
     
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("combo"))
        {
            animator.SetBool("combo", false);
            isDmgMotion = false;
        }

        if (ab2 <= 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                animator.SetTrigger("spin");
                isDmgMotion = true;
                ab2 = 5;
            }
        }


        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("spin"))
        {
            animator.SetBool("spin", false);
            isDmgMotion = false;
        }

        ab1 -= Time.deltaTime;
        ab2 -= Time.deltaTime;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //positive damage and negative healing
    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP < 0)
        {
            playerHP = 0;
        }
        healthBarController.SetHealth(playerHP);
        if (playerHP <= 0)
        {
            isGameOver = true;
        }

    }

}
