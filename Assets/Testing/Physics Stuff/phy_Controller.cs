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


    public float collision;

    

    // Use this for initialization
    void Start()
    {
        raycasts_UpdateOrigins();


    }

    public void VerticalCollisions(ref Vector2 velocity)
    {
        float dirY = Mathf.Sign(velocity.y);
        float rayLength = Mathf.Abs(velocity.y) + SkinWidth;
        

        if (dirY == 1)
        {
            ;
            foreach (Transform point in UpRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.up * dirY, rayLength, CollisionMask);
            
                if (hit)
                {
                    
                   
                    velocity.y = (hit.distance - SkinWidth) * dirY;
                    Debug.Log((hit.distance - SkinWidth) * dirY);
                    rayLength = hit.distance;
                }
            }
        }
        else
        {
            
            foreach (Transform point in DownRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.up * dirY, rayLength, CollisionMask);
                
                if (hit)
                {
                                       
                    velocity.y = (hit.distance - SkinWidth) * dirY;
                    Debug.Log((hit.distance - SkinWidth) * dirY);
                    rayLength = hit.distance;
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
                
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.right * dirX, rayLength, CollisionMask);
                

                if (hit)
                {
                    Debug.Log("Horizontal Hit");
                    velocity.x = (hit.distance - SkinWidth) * dirX;
                    rayLength = hit.distance;
                }
            }
        }
        else
        {
            foreach (Transform point in LeftRaycastOrigins)
            {
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.right * dirX, rayLength, CollisionMask);
               

                if (hit)
                {
                    Debug.Log("Horizontal Hit");
                    
                    velocity.x = (hit.distance - SkinWidth) * dirX;
                    rayLength = hit.distance;
                }
            }
        }

    }

    public void Move()
    {
        
        gameObject.transform.Translate(phystat_Vel); 
        

    }

    private void raycasts_Debug()
    {

        foreach (Transform point in RightRaycastOrigins)
        {
            Debug.DrawRay(point.transform.position, Vector2.right * 4, Color.black);
        }

        foreach (Transform point in LeftRaycastOrigins)
        {
            Debug.DrawRay(point.transform.position, Vector2.left * 4, Color.black);
        }

        foreach (Transform point in UpRaycastOrigins)
        {
            Debug.DrawRay(point.transform.position, Vector2.up * 4, Color.black); ;
        }

        foreach (Transform point in DownRaycastOrigins)
        {
            Debug.DrawRay(point.transform.position, Vector2.down * 4, Color.black);
        }
    }

    private void raycasts_UpdateOrigins()
    {
        float insetProportion = (1 - SkinWidth * 2);

        foreach (Transform point in RightRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

        foreach (Transform point in LeftRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

        foreach (Transform point in UpRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

        foreach (Transform point in DownRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
        raycasts_Debug();
    }

    // FixedUpdate is ALWAYS called once every 20 milliseconds 
    void FixedUpdate()
    {


    }
}