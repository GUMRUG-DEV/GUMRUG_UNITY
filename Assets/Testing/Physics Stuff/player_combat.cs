using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
   entity_combat Gum = new entity_combat();

	// Use this for initialization
	void Start ()
    {
        Gum.punch.strength = 15;
        Gum.kick.strength = 15;
        Gum.headbonk.strength = 10;

        Gum.punch.useage_stamina = 5;
        Gum.kick.useage_stamina = 8;
        Gum.headbonk.useage_stamina = 5;

        Gum.headbonk.recoil = 5;

            	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
