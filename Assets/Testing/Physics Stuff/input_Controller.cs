using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(phy_Controller))]
public class input_Controller : MonoBehaviour
{

    phy_Controller phy_Controller;
    int input;
    int lastInput;

    // Use this for initialization
    void Start()
    {
        phy_Controller = gameObject.GetComponent<phy_Controller>();

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
            else if (input == 0)
            {
                phy_Controller.playerSpeed = 0;

                //phy_Controller.lastPos.x = phy_Controller.attatched.GetComponent<phy_Controller>().lastPos.x;
                // phy_Controller.currentPos.x = phy_Controller.attatched.GetComponent<phy_Controller>().currentPos.x;
                if (phy_Controller.attatched = null)
                {
                    phy_Controller.lastPos.x = phy_Controller.currentPos.x;
                }
                else if (phy_Controller.attatched != null)
                {
                    phy_Controller.lastPos.x = phy_Controller.currentPos.x - phy_Controller.attatched.GetComponent<phy_Controller>().deltaX;
                }
                



                //  phy_Controller.X_AccelerateTo(0);
            }
        }
        Debug.Log(input);
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
        


        Debug.Log(phy_Controller.XplayerMovement);

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hi");
            phy_Controller.YplayerMovement = .01f;
        }
        



    }

    void move_Horizontal(float speed)
    {

    }



    void move_Jump()
    {

    }


}
