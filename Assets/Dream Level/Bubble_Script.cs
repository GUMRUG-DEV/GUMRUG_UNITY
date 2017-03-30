using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Script : MonoBehaviour {

    public overworld Bubble = new overworld();
    public overworld Wall = new overworld();
    public overworld Wall2 = new overworld();
    public overworld Wall3 = new overworld();
    public overworld Wall4 = new overworld();

    


    float RanRange1 = Random.Range(-50f, 50f);
    float RanRange2 = Random.Range(-50f, 50f);
    

    // Use this for initialization
    void Start () {

        Bubble.col_Circle = gameObject.GetComponent<CircleCollider2D>();
        Bubble.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        Bubble.rigidbody.velocity = new Vector2(RanRange1, RanRange2);
        Wall.col_Box = GameObject.Find("BubbleWall").GetComponent<BoxCollider2D>();
        Wall2.col_Box = GameObject.Find("BubbleWall (1)").GetComponent<BoxCollider2D>();
        Wall3.col_Box = GameObject.Find("BubbleWall (2)").GetComponent<BoxCollider2D>();
        Wall4.col_Box = GameObject.Find("BubbleWall (3)").GetComponent<BoxCollider2D>();

        
           
        
    }

    // Update is called once per frame
    void Update () {
        Check();
        Bubble.rigidbody.velocity = new Vector2(RanRange1, RanRange2);
    }

    void Check()
    {
        if (Bubble.col_Circle.bounds.Intersects(Wall.col_Box.bounds))
        {
            RanRange1 = -RanRange1;
        }
        if (Bubble.col_Circle.bounds.Intersects(Wall2.col_Box.bounds))
        {
            RanRange1 = -RanRange1;
        }
        if (Bubble.col_Circle.bounds.Intersects(Wall3.col_Box.bounds))
        {
            RanRange2 = -RanRange2;
        }
        if (Bubble.col_Circle.bounds.Intersects(Wall4.col_Box.bounds))
        {
            RanRange2 = -RanRange2;
        }
    }
}
