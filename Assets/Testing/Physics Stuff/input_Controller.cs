using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(phy_Controller))]
public class input_Controller : MonoBehaviour
{

    phy_Controller phy_Controller;


    // Use this for initialization
    void Start()
    {
        phy_Controller = gameObject.GetComponent<phy_Controller>();

    }

    // Update is called once per frame
    void Update()
    {

        //Basic WASD Input
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            phy_Controller.phystat_XvelSetPoint = .25f;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            phy_Controller.phystat_XvelSetPoint = -.25f;
        }
        else
        {
            phy_Controller.phystat_XvelSetPoint = 0;
        }


        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hi");
            phy_Controller.phystat_YvelSetPoint = 1f;
        }



    }


}
