using UnityEngine;
using System.Collections;




public class NewBehaviourScript : MonoBehaviour {

    public character hero_Test = new character();
    
    void Start ()
    {
        hero_Test.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        hero_Test.power_Speed = 4;
        hero_Test.power_Jump = 500;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        handler_PlayerMovement();
        
	}

    bool isGrounded()
    {
        bool isGrounded;

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down);
        
        return isGrounded;
    }




    private void handler_PlayerMovement()
    {
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            hero_Test.rigidbody.velocity = new Vector2(-hero_Test.power_Speed, hero_Test.rigidbody.velocity.y);
                 
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            hero_Test.rigidbody.velocity = new Vector2(hero_Test.power_Speed, hero_Test.rigidbody.velocity.y);


        }

        if (Input.GetButtonDown("Jump") && hero_Test.grounded == true)
        {
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
