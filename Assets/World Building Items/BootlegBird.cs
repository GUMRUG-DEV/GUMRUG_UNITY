using UnityEngine;
using System.Collections;

public class BootlegBird : MonoBehaviour {

    public character Bootlegbird = new character();
    public character Wall = new character();
    public character Wall2 = new character();

    // Use this for initialization
    void Start () {
        Bootlegbird.transform = gameObject.GetComponent<Transform>();
        Bootlegbird.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        Bootlegbird.animator = gameObject.GetComponent<Animator>();
        Bootlegbird.spr_renderer = gameObject.GetComponent<SpriteRenderer>();
        Bootlegbird.col_Polygon = gameObject.GetComponent<PolygonCollider2D>();
        Bootlegbird.rigidbody.velocity += new Vector2(15, 0);
        Wall.col_Box = GameObject.Find("BubbleWall").GetComponent<BoxCollider2D>();
        Wall2.col_Box = GameObject.Find("BubbleWall (1)").GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Check();
    }
    void Check()
    {
        if (Bootlegbird.col_Polygon.bounds.Intersects(Wall.col_Box.bounds))
        {
            Bootlegbird.rigidbody.velocity += new Vector2(15, 0);
            Bootlegbird.spr_renderer.flipX = true;
            
        }
        if (Bootlegbird.col_Polygon.bounds.Intersects(Wall2.col_Box.bounds))
        {
            Bootlegbird.rigidbody.velocity += new Vector2(-15, 0);
           
            Bootlegbird.spr_renderer.flipX = true;

        }
    }
}
