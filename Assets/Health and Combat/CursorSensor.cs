using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	if	(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button pressed");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right mouse button pressed");
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("middle mouse button pressed");
        }
        Vector2 mousePos = Input.mousePosition;
        Debug.Log(mousePos.x);
        Debug.Log(mousePos.y);
    }
}
