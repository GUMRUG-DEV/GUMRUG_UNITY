using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat_Controller : MonoBehaviour
{

    stat_Controller player = new stat_Controller();
    stat_Controller enemy = new stat_Controller();


    public bool is_playerTurn = false;
    public bool is_battling = false;
    action[] plrActions = new action[4];
    action[] foeActions = new action[3];
    int count = 0;
    //int NumberOfActions;
    


	// Use this for initialization
	void Start ()
    {
        enemy.health = 80;

        enemy.actions = new List<action>(new action[2]);
        for (int i = 0; i < 2; i++)
        {
            enemy.actions[i] = new action();
        }

        enemy.actions[0].name = "ram";
        enemy.actions[0].strength = 10;

        enemy.actions[1].name = "the sun is a deadly lazer";
        enemy.actions[1].strength = 10;

        player.health = 100;
        player.stamina = 100;

        player.actions = new List<action>(new action[5]);

        for (int i = 0; i < 5; i++)
        {
            player.actions[i] = new action();
        }

        player.actions[0].name = "punch";
        player.actions[0].strength = 10;
        player.actions[0].useage_stamina = 7;
        player.actions[0].recoil = 0;
        player.actions[0].healing = 0;
        
        player.actions[1].name = "kick";
        player.actions[1].strength = 15;
        player.actions[1].useage_stamina = 10;
        player.actions[1].recoil = 0;
        player.actions[1].healing = 0;

        player.actions[2].name = "headbonk";
        player.actions[2].strength = 15;
        player.actions[2].useage_stamina = 7;
        player.actions[2].recoil = 4;
        player.actions[2].healing = 0;

        player.actions[3].name = "rest";
        player.actions[3].strength = 0;
        player.actions[3].useage_stamina = 0;
        player.actions[3].recoil = 0;
        player.actions[3].healing = 15;
        player.actions[3].healingtype = healing_type.Stamina;

        player.actions[4].name = "recover";
        player.actions[4].strength = 0;
        player.actions[4].useage_stamina = 25;
        player.actions[4].recoil = 0;
        player.actions[4].healing = 20;
        player.actions[4].healingtype = healing_type.HP;



        /*
        Gum.actions.Find(x => x.name == "punch");
        Gum.punch.strength = 15;
        Gum.kick.strength = 15;
        Gum.headbonk.strength = 10;

        Gum.punch.useage_stamina = 5;
        Gum.kick.useage_stamina = 8;
        Gum.headbonk.useage_stamina = 5;

        Gum.headbonk.recoil = 5;

        Gum.rest.healing = 30;
        */


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (is_battling)
        {
            if (is_playerTurn)
            {
                Debug.Log("Not so fast! You've just triggered my trap card!");
                if (count <= 3)
                {
                    plrPlan();
                }
                else if (count == 4 && Input.GetKeyDown(KeyCode.End))
                {
                    plrExecute();

                    if (enemy.health <= 0)
                    {
                        is_battling = false;
                        Debug.Log("You win.");
                        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                    }
                }
            }
            else
            {
                foePlan();
                foeExecute();
            }
        }

	}

    void plrExecute()
    {

        
        foreach (action move in plrActions)
        {
            if (move.healing > 0)
            {
                if (move.healingtype == healing_type.HP)
                {
                    player.health += move.healing;
                    player.stamina -= move.useage_stamina;
                }
                else if (move.healingtype == healing_type.Stamina)
                {
                    player.stamina += move.healing;
                }

            }
            else
            {
                if (player.stamina >= move.useage_stamina)
                {
                    player.stamina -= move.useage_stamina;
                    enemy.health -= move.strength;
                    Debug.Log(enemy.health);
                }
                else
                {
                    Debug.Log("Too tired...");
                }
            }
        }
        is_playerTurn = false;
    }



    void plrPlan()
    {
        //Player's turn
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("punch");
            //add to display panel
            plrActions[count] = player.actions.Find(move => move.name == "punch");

            count++;

            Debug.Log("You have " + (4 - count) + " moves left to use.");

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("kick");
            //add to display panel
            plrActions[count] = player.actions.Find(move => move.name == "kick");

            count++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("headbonk");
            //add to display panel
            plrActions[count] = player.actions.Find(move => move.name == "headbonk");

            count++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("rest");
            //add to display panel
            if (count == 0)
            {
                plrActions[count] = player.actions.Find(move => move.name == "rest");
                count = 4;
            }
            else
            {
                Debug.Log("Rest uses up all attack slots. Please decide against doing other attacks if you wish to rest.");
            }


        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("recover");
            if (count == 0)
            {
                plrActions[count] = player.actions.Find(move => move.name == "recover");
                Debug.Log("Recover uses up all attack slots. Please decide against doing other attacks if you wish to recover.");
                count = 4;
            }

        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (count > 0)
            {
                count--;
                plrActions[count] = null;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {

        }
    }
     
    void foePlan()
    {
        ;
        for (int i = 0; i <= 2; i++)
        { 
            //Ai goes here.
            if (Random.Range(-1, 1) >= 0)
            {
                Debug.Log("Foe decides to use mostly safe laser.");
                foeActions[i] = enemy.actions.Find(move => move.name == "the sun is a deadly lazer");
            }
            else
            {
                Debug.Log("Foe decides to ram you.");
                foeActions[i] = enemy.actions.Find(move => move.name == "ram");
            }

        }
    }

    void foeExecute()
    {
        //More AI goes here.
        foreach (action move in foeActions)
        {
            player.health -= move.strength;
            Debug.Log("Gum's Health: " + player.health);
            
        }
        is_playerTurn = true;
        count = 0;
    }
}
