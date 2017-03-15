using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlakeScript : MonoBehaviour {

    public character Snowflake = new character();
    public character Wall = new character();
    public Vector2 velocity;

	// Use this for initialization
	void Start () {
        Snowflake.col_Box = gameObject.GetComponent<BoxCollider2D>();
        Snowflake.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        Snowflake.transform = gameObject.GetComponent<Transform>();
        Snowflake.rigidbody.velocity = new Vector2(0, -10);
        velocity = Snowflake.rigidbody.velocity;
        Wall.col_Box = GameObject.Find("BubbleWall (3)").GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Check();
		
	}
    void Check()
    {
        if (Snowflake.col_Box.bounds.Intersects(Wall.col_Box.bounds))
        {
            Snowflake.transform.position = new Vector2(Snowflake.transform.position.x, Snowflake.transform.position.y + 603);
        }
    }
}
