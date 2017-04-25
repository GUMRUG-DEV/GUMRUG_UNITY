using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreOwnerScript : MonoBehaviour {
    

    public overworld StoreOwnerMic = new overworld();

	// Use this for initialization
	void Start () {

        StoreOwnerMic.animator = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a"))
        {
            StoreOwnerMic.animator.SetBool("IsCrushed", true);
        
        }
	}
}
