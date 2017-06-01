using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(phy_Controller))]
public class input_Controller : MonoBehaviour
{

    phy_Controller phy_Controller;
    int input;
    int lastInput;
    float initDisp;

    // Use this for initialization
    void Start()
    {
        phy_Controller = gameObject.GetComponent<phy_Controller>();
        //Debug.Log(phy_Controller.Gravity);
        //Debug.Log(phy_Controller.MaxJumpHeight);

        initDisp = Time.fixedDeltaTime * Mathf.Sqrt(2 * -phy_Controller.Gravity * phy_Controller.MaxJumpHeight);
        //Debug.Log("Displacement Squared: " + 2 * phy_Controller.Gravity * phy_Controller.MaxJumpHeight);
        //Debug.Log("Displacement: " + initDisp);
    }

    // Update is called once per frame
    void Update()
    {
         input = (int)Input.GetAxisRaw("Horizontal");
        //Debug.Log(-(phy_Controller.lastPos - phy_Controller.currentPos));

        //Basic WASD Input

        if (input != lastInput)
        {
            if (input > 0)
            {
                phy_Controller.playerSpeed = 1;
                // phy_Controller.X_AccelerateTo(phy_Controller.SpeedPowerwerre);
            }
            else if (input < 0)
            {
                phy_Controller.playerSpeed = -1;
            }
            else
            {
                
                phy_Controller.playerSpeed = 0;

                //phy_Controller.lastPos.x = phy_Controller.attatched.GetComponent<phy_Controller>().lastPos.x;
                // phy_Controller.currentPos.x = phy_Controller.attatched.GetComponent<phy_Controller>().currentPos.x;
                if (!phy_Controller.attatched)
                {
                    phy_Controller.lastPos.x = phy_Controller.currentPos.x;
                }
                else
                {
                    //Debug.Log("hi");
                    //Debug.Log(phy_Controller.lastPos.x);
                    phy_Controller.lastPos.x = phy_Controller.currentPos.x - phy_Controller.attatched.GetComponent<phy_Controller>().deltaX;
                    phy_Controller.lastPos.y = phy_Controller.currentPos.y - phy_Controller.attatched.GetComponent<phy_Controller>().deltaY;
                    //Debug.Log(phy_Controller.lastPos.x);
                }
              
                //  phy_Controller.X_AccelerateTo(0);
            }
        }


        //Debug.Log(input);
        lastInput = input;
       


        
        /*   move_Horizontal(phy_Controller.SpeedPower);
        if (Input.GetKeyDown(KeyCode.A))
        {
            phy_Controller.XplayerMovement = -.25f;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            phy_Controller.XplayerMovement = .25f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            phy_Controller.XplayerMovement = .25f;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            phy_Controller.XplayerMovement = -.25f;
        }
        else
        {
            phy_Controller.XplayerMovement = 0;
        }
        */
        


        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && phy_Controller.collisions.bottom)
        {
            Debug.Log("hi");
            phy_Controller.lastPos.y -= initDisp;
        }
        



    }

    void move_Horizontal(float speed)
    {

    }



    void move_Jump()
    {

    }


}
