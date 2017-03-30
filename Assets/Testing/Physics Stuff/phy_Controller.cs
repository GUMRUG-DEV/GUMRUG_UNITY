using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(BoxCollider2D))]
public class phy_Controller : MonoBehaviour
{
    //Pure Physics Stats  
    public Vector2
        phystat_initVel,
        phystat_Accl;


    private Vector2
        phystat_lastPos,
        phystat_currentPos;

    public float phystat_XvelSetPoint;
    public float phystat_YvelSetPoint;

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
        SkinWidth,
        Gravity;



    public LayerMask CollisionMask;


    public float
         phystat_Mass;


    public float collision;

    


    







    // Use this for initialization
    void Start()
    {
        phystat_currentPos = gameObject.transform.position;
        phystat_lastPos = phystat_currentPos - phystat_initVel;

        raycasts_UpdateOrigins();

    }

    // Update is called once per frame
    void Update()
    {
        Accelerate(0, Gravity);
        
        raycasts_Debug();
    }

    // FixedUpdate is ALWAYS called once every 20 milliseconds 
    void FixedUpdate()
    {     
        Move();
        X_AccelerateTo();
        Y_AccelerateTo();
    }









 
    public void addForce(float x_Force, float y_Force) //Adds a constant force that the object will experience
    {
        phystat_Accl += new Vector2(x_Force/phystat_Mass, y_Force/phystat_Mass);
    }

    public void X_AccelerateTo() //Instantly accelerates the gameobject to a speed (over a single fixed frame)
    {
        if ((phystat_currentPos.x - phystat_lastPos.x) != phystat_XvelSetPoint)
        {
            
            phystat_Accl.x = (phystat_XvelSetPoint - (phystat_currentPos.x - phystat_lastPos.x))/ (Time.fixedDeltaTime * Time.fixedDeltaTime);
            
        }
        else
        {
            phystat_Accl.x = 0;
        }
    }

    public void Y_AccelerateTo() //Instantly accelerates the gameobject to a speed (over a single fixed frame)
    {
        if ((phystat_currentPos.y - phystat_lastPos.y) < phystat_YvelSetPoint)
        {
            float accl;
            accl = (phystat_YvelSetPoint - (phystat_currentPos.y - phystat_lastPos.y)) / (Time.fixedDeltaTime * Time.fixedDeltaTime);

            gameObject.transform.Translate(new Vector2(0, accl * Time.fixedDeltaTime * Time.fixedDeltaTime));
        }
        
    }

    public void Accelerate(float x_Accl, float y_Accl) //Adds an acceleration to an object
    {
        phystat_Accl += new Vector2(x_Accl, y_Accl);
    }  

    public void Move()
    {

        float phystat_deltaX;
        float phystat_deltaY;

        phystat_deltaX = (phystat_currentPos.x - phystat_lastPos.x) + (phystat_Accl.x * Time.fixedDeltaTime * Time.fixedDeltaTime);
        phystat_deltaY = (phystat_currentPos.y - phystat_lastPos.y) + (phystat_Accl.y * Time.fixedDeltaTime * Time.fixedDeltaTime);

        VerticalCollisions(ref phystat_deltaY); //Pasing a ref to a function passes the variable rather than a copy of it
        HorizontalCollisions(ref phystat_deltaX);
        
        gameObject.transform.Translate(new Vector2(phystat_deltaX, phystat_deltaY));
        phystat_lastPos = phystat_currentPos; //After updating the current position variable becomes the last position.
        phystat_currentPos = gameObject.transform.position; //Update the position
        

    }



    public void VerticalCollisions(ref float deltaY)
    {
        float dirY = Mathf.Sign(deltaY);
        float rayLength = Mathf.Abs(deltaY) + SkinWidth * 2;
        

        if (dirY == 1)
        {
            
            foreach (Transform point in UpRaycastOrigins) //For each critical point in the set up upward shooting rays
            {
                //Shoot a ray out and store any collider collisions into "hit"
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.up * dirY, rayLength, CollisionMask);
            
                //If we have hit something:
                if (hit)
                {
                    
                   //The new velocity is equal to the distance of the hit minus the skinwidth times the direction
                    deltaY = (hit.distance - SkinWidth) * dirY;
                   // Debug.Log((hit.distance - SkinWidth) * dirY);
                    rayLength = hit.distance; //The new shoot distance must be set equal to the hit distance
                    
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
                                       
                    deltaY = (hit.distance - SkinWidth) * dirY;
                 //   Debug.Log((hit.distance - SkinWidth) * dirY);
                    rayLength = hit.distance;
                   
                }
            }
        }

    }

    public void HorizontalCollisions(ref float deltaX)
    { 
        float dirX = Mathf.Sign(deltaX);
        float rayLength = Mathf.Abs(deltaX) + SkinWidth;

        if (dirX == 1)
        {
            foreach (Transform point in RightRaycastOrigins)
            {
                
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.right * dirX, rayLength, CollisionMask);
                

                if (hit)
                {
                   // Debug.Log("Horizontal Hit");
                    deltaX = (hit.distance - SkinWidth) * dirX;
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
                 //   Debug.Log("Horizontal Hit");
                    
                    deltaX = (hit.distance - SkinWidth) * dirX;
                    rayLength = hit.distance;
                }
            }
        }

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
            Debug.DrawRay(point.transform.position, Vector2.up * 4, Color.black); 
        }

        foreach (Transform point in DownRaycastOrigins)
        {
            Debug.DrawRay(point.transform.position, Vector2.down * 4, Color.black);
        }
    }

    private void raycasts_UpdateOrigins()
    {
        

        foreach (Transform point in RightRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;

            float insetProportion = ((-SkinWidth) + posX / posX);

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

        foreach (Transform point in LeftRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;
            float insetProportion = ((-SkinWidth) + posX / posX);

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

        foreach (Transform point in UpRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;
            float insetProportion = ((-SkinWidth) + posY / posY);

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

        foreach (Transform point in DownRaycastOrigins)
        {
            float posX = point.transform.localPosition.x;
            float posY = point.transform.localPosition.y;
            float insetProportion = ((-SkinWidth) + posY / posY);

            point.transform.localPosition = new Vector2(posX * insetProportion, posY * insetProportion);
        }

    }



}