using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(phy_Controller))]
public class input_Controller : MonoBehaviour
{

    phy_Controller phy_Controller;

    float gravity = -4f;
    Vector2 velocity;

    // Use this for initialization
    void Start()
    {
        phy_Controller = gameObject.GetComponent<phy_Controller>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            phy_Controller.phystat_Vel.x = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            phy_Controller.phystat_Vel.x = -1;
        }
        else
        {
            phy_Controller.phystat_Vel.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            phy_Controller.phystat_Vel.y = 1.5f;
        }

    }

    void FixedUpdate()
    {
       phy_Controller.phystat_Vel.y += gravity * Time.deltaTime;
       


        phy_Controller.VerticalCollisions(ref phy_Controller.phystat_Vel);
        phy_Controller.HorizontalCollisions(ref phy_Controller.phystat_Vel);

        Debug.Log(phy_Controller.phystat_Vel);
        phy_Controller.Move();
    }
}
