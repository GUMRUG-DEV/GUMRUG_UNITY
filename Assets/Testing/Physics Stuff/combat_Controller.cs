using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_Controller : MonoBehaviour
{

    entity_combat Gum = new entity_combat();

    bool condition;
    attack[] actions = new attack[4];
    int count = 0;
    


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

        Gum.rest.healing = 30;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (condition)
        {
            Begin();
            foreach (attack action in actions)
            {
                if (action.healing > 0)
                {
                    if (action.healingtype == healing_type.HP)
                    {
                        Gum.Health += action.healing;
                    }
                    else if (action.healingtype == healing_type.Stamina)
                    {
                        Gum.Stamina += action.healing;
                    }

                }
                else
                {

                }
            }
        }

	}

   

    void Begin()
    {
        //Player's turn
        while (count <= 3)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                actions[count] = Gum.punch;
                count++;

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                actions[count] = Gum.kick;
                count++;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                actions[count] = Gum.headbonk;
                count++;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                actions[count] = Gum.rest;
                count++;
            }
        }
    }
}
