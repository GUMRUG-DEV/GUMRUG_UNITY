using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
public class phy_Controller : MonoBehaviour
{
    //Pure Physics Stats  
    public Vector2
        phystat_Vel,
        phystat_Accl;

    //This is where we'll start the raycasts

    public Transform[]
        RightRaycastOrigins,
        LeftRaycastOrigins,
        UpRaycastOrigins,
        DownRaycastOrigins;


    //Serializable Variables

    public float
        JumpPower,
        SpeedPower,
        SkinWidth;



    public LayerMask CollisionMask;


    public float
         phystat_Mass;



    public test_Character test_One = new test_Character();

    // Use this for initialization
    void Start()
    {


       

    }

    public void VerticalCollisions(ref Vector2 velocity)
    {
        float dirY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + SkinWidth;

        if (dirY == 1)
        {
            foreach (Transform point in UpRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast((point.transform.position + Vector3.down * SkinWidth * dirY), Vector2.up * dirY, rayLength, CollisionMask);

                if (hit)
                {
                    velocity.y = (hit.distance - SkinWidth) * dirY;
                    rayLength = (hit.distance - SkinWidth);
                }
            }
        }
        else
        {
            foreach (Transform point in DownRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast((point.transform.position + Vector3.down * 5 * dirY), Vector2.up * dirY, rayLength, CollisionMask);

                if (hit)
                {
                    velocity.y = (hit.distance - SkinWidth) * dirY;
                    rayLength = (hit.distance - SkinWidth);
                }
            }
        }

    }

    public void HorizontalCollisions(ref Vector2 velocity)
    {
        float dirX = Mathf.Sign(velocity.x);
        float rayLength = Mathf.Abs(velocity.x) + SkinWidth;

        if (dirX == 1)
        {
            foreach (Transform point in RightRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast((point.transform.position + Vector3.left * SkinWidth * dirX), Vector2.up * dirX, rayLength, CollisionMask);

                if (hit)
                {
                    velocity.x = (hit.distance - SkinWidth) * dirX;
                    rayLength = (hit.distance - SkinWidth);
                }
            }
        }
        else
        {
            foreach (Transform point in LeftRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast((point.transform.position + Vector3.left * SkinWidth * dirX), Vector2.up * dirX, rayLength, CollisionMask);

                if (hit)
                {
                    velocity.x = (hit.distance - SkinWidth) * dirX;
                    rayLength = (hit.distance - SkinWidth);
                }
            }
        }

    }

    void Move(float force)
    {


    }

    void debug_Raycasts()
    {

        foreach (Transform point in RightRaycastOrigins)
        {
            Debug.DrawRay((point.transform.position + Vector3.left * SkinWidth), Vector2.right * 4, Color.black);
        }

        foreach (Transform point in LeftRaycastOrigins)
        {
            Debug.DrawRay((point.transform.position + Vector3.right * SkinWidth), Vector2.left * 4, Color.black);
        }

        foreach (Transform point in UpRaycastOrigins)
        {
            Debug.DrawRay((point.transform.position + Vector3.down * SkinWidth), Vector2.up * 4, Color.black); ;
        }

        foreach (Transform point in DownRaycastOrigins)
        {
            Debug.DrawRay((point.transform.position + Vector3.up * SkinWidth), Vector2.down * 4, Color.black);
        }
    }




    // Update is called once per frame
    void Update()
    {
        debug_Raycasts();
    }

    // FixedUpdate is ALWAYS called once every 20 milliseconds 
    void FixedUpdate()
    {

    }
}