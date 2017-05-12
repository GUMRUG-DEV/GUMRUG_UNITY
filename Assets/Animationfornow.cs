using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationfornow : MonoBehaviour {

    public overworld Gum = new overworld();

	// Use this for initialization
	void Start () {
        Gum.animator = gameObject.GetComponent<Animator>();
	}
    
    

	// Update is called once per frame
	void Update () {

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            Gum.animator.SetInteger("D", 1);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            Gum.animator.SetInteger("D", 2);
        }
    }
}
