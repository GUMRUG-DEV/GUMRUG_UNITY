using UnityEngine;
using System.Collections;




public class NewBehaviourScript : MonoBehaviour {




    [SerializeField]
    double Speed, MaxJumpHeight, TimetoJumpApex, asdf;

    [SerializeField]
    float GroundDetectionPrecision;

    [SerializeField]
    LayerMask WhatIsGround;

    [SerializeField]
    Transform[] Feet;

    [SerializeField]
    float PowerSpeed;


    bool isGrounded;
    bool jumping;
         

    public character hero_Test = new character();
    
    void Start ()
    {

        hero_Test.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        hero_Test.transform = gameObject.GetComponent<Transform>();
        hero_Test.animator = gameObject.GetComponent<Animator>();

        hero_Test.power_Speed = PowerSpeed;
        hero_Test.power_Jump = 500;
   
    }

// Update is called once per frame
void Update ()
    {
        isGrounded = Grounded();
        get_Input();


    }

  bool Grounded()
    {

        foreach (Transform point in Feet)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, GroundDetectionPrecision, WhatIsGround);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.tag == "Ground")
                {
                    return true;
                }
                else if (colliders[i].gameObject.tag == "Death Box")
                    {
                    isDead();
                }
            }
        }

        return false;
    }
    private void isDead()
    {

        hero_Test.transform.position = new Vector2(-28.87f, 2.1f);
        hero_Test.rigidbody.velocity = Vector2.zero;      

    }



    private void get_Input()
    {

        

        if (isGrounded)
        {
          //  Debug.Log("My mom grounded me");
        }
        else
        {
            //Debug.Log("Wheeeeeeeeeeeee.");
        }


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            hero_Test.animator.SetInteger("Direction", 0);
            hero_Test.rigidbody.velocity = new Vector2(-hero_Test.power_Speed, hero_Test.rigidbody.velocity.y);


        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            hero_Test.animator.SetInteger("Direction", 1);
            hero_Test.rigidbody.velocity = new Vector2(hero_Test.power_Speed, hero_Test.rigidbody.velocity.y);

        }
        else
        {
            hero_Test.rigidbody.velocity = new Vector2(0.0f, hero_Test.rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            isGrounded = false;

            if (Input.GetKeyDown(KeyCode.RightAlt))
            {
                isGrounded = true;
            }

            hero_Test.rigidbody.AddForce(Vector2.up * hero_Test.power_Jump);
            
        }

        
        
        /*
        Debug.Log("Up: " + moving[Up]);
        Debug.Log("Down: " + moving[Down]);
        Debug.Log("Left: " + moving[Left]);
        Debug.Log("Right: " + moving[Right]);

        
        if (moving[Up] == true && moving[Down] == false)
        {
            transform.Translate(Vector2.up);
            Debug.Log("Up");
        }
        else if (moving[Up] == false && moving[Down] == true)
        {
            transform.Translate(Vector2.down);
            Debug.Log("Down");
        }
        else if (moving[Right] == true && moving[Left] == false)
        {
            transform.Translate(Vector2.right);
            Debug.Log("Right");
        }
        else if (moving[Right] == false && moving[Left] == true)
        {
            transform.Translate(Vector2.left);
            Debug.Log("Left");
        }

        */
    }


}
