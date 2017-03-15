using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class character
    {

        public Rigidbody2D rigidbody;
        public Transform transform;
        public Animator animator;
        public SpriteRenderer spr_renderer;
        public CircleCollider2D col_Circle;
        public BoxCollider2D col_Box;
        public PolygonCollider2D col_Polygon;
        public int direction;
        public float power_Jump;
        public float power_Speed;
        public float mass;
        public float altitude;
        public bool grounded;

    }


    public class test_Character
    {

        public Transform transform;
        public BoxCollider2D col_Box;
        public Animator animator;






    }

    public class overworld
    {
        public float Fly_Power;
        public Transform flyform;
        public Animator flymator;
        public Collider2D Fly_Circle;


    }

