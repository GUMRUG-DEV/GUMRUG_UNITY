using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class action
{
    public healing_type healingtype;
    public int healing;
    public int strength;
    public int useage_stamina;
    public int recoil;

    public string name;

}

public enum healing_type
{
    HP, Stamina
};

public enum action_type
{
    buff, attack, defense
};
