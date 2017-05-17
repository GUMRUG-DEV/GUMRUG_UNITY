using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class overworld
{
    public Rigidbody2D rigidbody;
    public Transform transform;

    public Animator animator;
    public SpriteRenderer spr_renderer;

    public CircleCollider2D col_Circle;
    public BoxCollider2D col_Box;
    public PolygonCollider2D col_Polygon;

    public float power_Speed;
    public float power_Jump;

    public int[] animationTransitions;



    public void GoTo(float distance, float speed)
    {

    }

    public void Jump(float height, float time)
    {

    }

    public void Wander(float range, float speedVariation)
    {

    }

    public void Find(float range, string tag)
    {

        
    }

    public void Chase(float range)
    {

    }


    public void Avoid(float range)
    {

    }

    public void Follow(string tagTarget, float distance)
    {

    }



}
