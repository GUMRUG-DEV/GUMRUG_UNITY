using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(phy_Controller))]
public class input_Controller : MonoBehaviour {

    phy_Controller phy_Controller;

    float gravity = -20;
    Vector2 velocity;

	// Use this for initialization
	void Start ()
    {
        phy_Controller = gameObject.GetComponent<phy_Controller>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        phy_Controller.phystat_Vel.y = gravity * Time.deltaTime;

    }
}
