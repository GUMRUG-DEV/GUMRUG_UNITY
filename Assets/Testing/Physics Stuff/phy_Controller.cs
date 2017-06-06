using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(BoxCollider2D))]
public class phy_Controller : MonoBehaviour
{
    //Pure Physics Stats  
    public Vector2
        initialVelocity,
        transAccl;

    public float slopeAngle;

    public float
        angleAccl;

    public bool
        hasGravity,
        isPlayer;

    public float
        deltaTheta,
        deltaX,
        deltaY;

    public float
        lastAngle,
        currentAngle;

    public Vector2
        lastPos,
        currentPos;

    //This is where we'll start the raycasts

    public Transform[]
        RightRaycastOrigins,
        LeftRaycastOrigins,
        UpRaycastOrigins,
        DownRaycastOrigins;


    //Serializable Variables

    public float
        MaxJumpHeight,
        SpeedPower,
        SkinWidth,
        Gravity;


    public float playerSpeed;

    public LayerMask CollisionMask;

    public GameObject attatched = null;

    public CollisionInfo collisions;

    public float
         Mass;


    public float collision;

    







    // Use this for initialization
    void Start()
    {
        currentPos = gameObject.transform.localPosition;
        lastPos = currentPos - initialVelocity;

        raycasts_UpdateOrigins();

        if (hasGravity)
        {
            transAccl.y = Gravity;
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
        Move();
        CalcInput();
    //    X_AccelerateTo();
     //   Y_AccelerateTo();
    }








 
    public void addForce(float x_Force, float y_Force) //Adds a constant force that the object will experience
    {
        transAccl += new Vector2(x_Force/Mass, y_Force/Mass);
    }
    /*
    public void X_AccelerateTo(float XSetPoint) //Instantly accelerates the gameobject to a speed (accelerates over a single fixed frame)
    {

        
        if ((currentPos.x - lastPos.x) < XSetPoint)  
        {
            Debug.Log("hi.");
            float acclNeeded = transAccl.x - ((XSetPoint - (currentPos.x - lastPos.x)) / (Time.fixedDeltaTime * Time.fixedDeltaTime));
            float deltaX = (currentPos.x - lastPos.x) + (transAccl.x * Time.fixedDeltaTime * Time.fixedDeltaTime);
            gameObject.transform.Translate(new Vector2(deltaX, 0));
        }




    }

    public void Y_AccelerateTo(float YSetPoint) //Instantly accelerates the gameobject to a speed (accelerates over a single fixed frame)
    {
        if ((currentPos.y - lastPos.y) != YSetPoint)
        {
            float acclNeeded = (transAccl.y - (YSetPoint - (currentPos.y - lastPos.y)) / (Time.fixedDeltaTime * Time.fixedDeltaTime));
            float deltaY = (currentPos.y - lastPos.y) + (transAccl.y * Time.fixedDeltaTime * Time.fixedDeltaTime);
            gameObject.transform.Translate(new Vector2(0, deltaY));

        }
        
    }
    */

    public void Accelerate(float x_Accl, float y_Accl) //Adds an acceleration to an object
    {
        transAccl += new Vector2(x_Accl, y_Accl);
    }  

    public void Spin()
    {
        deltaTheta = (currentAngle - lastAngle) + (angleAccl * Time.fixedDeltaTime * Time.fixedDeltaTime);


    }

    public void Move()
    {
        collisions.Reset();

        deltaX = (currentPos.x - lastPos.x) + (transAccl.x * Time.fixedDeltaTime * Time.fixedDeltaTime);
        deltaY = (currentPos.y - lastPos.y) + (transAccl.y * Time.fixedDeltaTime * Time.fixedDeltaTime);

        VerticalCollisions(ref deltaY); //Pasing a ref to a function passes the variable rather than a copy of it
        HorizontalCollisions(ref deltaX, ref deltaY);
        

        gameObject.transform.Translate(new Vector2(deltaX, deltaY));
        lastPos = currentPos; //After updating the current position variable becomes the last position.
        currentPos = gameObject.transform.position; //Update the position
        

    }

    public void CalcInput()
    {
        float run = SpeedPower * playerSpeed;
        float rise = 0;
        


        HorizontalCollisions(ref run, ref rise);

       

        currentPos += new Vector2(run, rise);
        lastPos += new Vector2(run, rise);
        gameObject.transform.Translate(new Vector2(run, rise));

    }


    public void VerticalCollisions(ref float deltaY)
    {
        float dirY = Mathf.Sign(deltaY);
        float rayLength = Mathf.Abs(deltaY) + SkinWidth;


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

                    if (collisions.climbing)
                    {
                        lastPos.x = lastPos.y / Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(deltaX);
                    }


                    collisions.top = true;
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



                    {
                        if (Mathf.Abs(deltaY) < .000001 && attatched != hit.transform.gameObject && isPlayer)
                        {

                            attatched = hit.transform.gameObject;
                            deltaX += hit.transform.gameObject.GetComponent<phy_Controller>().deltaX;

                        }


                        //   Debug.Log((hit.distance - SkinWidth) * dirY);
                        rayLength = hit.distance;

                        collisions.bottom = true;
                    }

                    if (collisions.climbing)
                    {
                        float directionX = Mathf.Sign(deltaX);
                        rayLength = Mathf.Abs(deltaX) + SkinWidth;
                        Vector2 rayOrigin;

                        if (directionX == -1)
                        {
                            rayOrigin = DownRaycastOrigins[2].transform.position + Vector3.up * deltaY;
                        }
                        else
                        {
                            rayOrigin = DownRaycastOrigins[0].transform.position + Vector3.up * deltaY;
                        }

                        RaycastHit2D hit2 = Physics2D.Raycast(rayOrigin, Vector2.right * deltaX, rayLength, CollisionMask);

                        if (hit2)
                        {
                            float slope = Vector2.Angle(hit.normal, Vector2.up);

                            if (slope != slopeAngle)
                            {
                                deltaX = (hit.distance - SkinWidth) * directionX;
                            }
                        }
                    }

                }



            }
        }
    }

    public void HorizontalCollisions(ref float deltaX, ref float rise)
    {
        //Debug.Log("Preprocessing lastpos: " + lastPos.x);
        float dirX = Mathf.Sign(deltaX);
        float rayLength = Mathf.Abs(deltaX) + SkinWidth;

        if (dirX == 1)
        {
            foreach (Transform point in RightRaycastOrigins)
            {
                
                RaycastHit2D hit = Physics2D.Raycast(point.transform.position, Vector2.right * dirX, rayLength, CollisionMask);
                

                if (hit)
                {
                    
                    slopeAngle = Vector2.Angle(Vector2.up, hit.normal);


                    if (!collisions.climbing || slopeAngle <= 80)
                    {
                        float DistToSlope = 0;
                        if (slopeAngle != collisions.old_slopeAngle)
                        {
                            DistToSlope = hit.distance - SkinWidth;
                            deltaX -= DistToSlope;
                        }

                        climb_Slope(ref deltaX, ref rise, slopeAngle);
                    }
                    else
                    {
                        deltaX = (hit.distance - SkinWidth) * dirX;
                        rayLength = hit.distance;

                        collisions.right = true;
                    }


                    //Debug.Log(slopeAngle);
                    //Debug.Log(slopeAngle);

                    // Debug.Log("Horizontal Hit");


                    
                   
                    
                    

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
                    
                   slopeAngle = Vector2.Angle(hit.normal, Vector2.up);


                    float DistToSlope = 0;
                    if (slopeAngle != collisions.old_slopeAngle)
                    {
                        DistToSlope = hit.distance - SkinWidth;
                        deltaX += DistToSlope;
                    }
                    else
                    {
                        deltaX = (hit.distance - SkinWidth) * dirX;
                        rayLength = hit.distance;

                        collisions.left = true;
                    }
                    //Debug.Log(slopeAngle);
                    //   Debug.Log("Horizontal Hit");

                    
                    

                }
            }
        }

    }


    public void climb_Slope(ref float run, ref float rise, float slopeAngle)
    {
        //Debug.Log("Last position: " + lastPos.x);
       // Debug.Log("Current position: " + currentPos.x);
        //Debug.Log("DeltaX: " + linear_deltaX);
       // Debug.Log("Cosine: " + Mathf.Cos(slopeAngle * Mathf.Deg2Rad));
        
        float movedistance = Mathf.Abs(run);
        rise = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * movedistance;
         
        run = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * movedistance * Mathf.Sign(run);
        collisions.climbing = true;
        collisions.slopeAngle = slopeAngle;

       // Debug.Log("New Last Position: " + lastPos.x);
    }


    private void raycasts_Debug()
    {
        /*
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
        */
    }

    private void raycasts_UpdateOrigins()
    {
        /*

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
        */
    }




    public struct CollisionInfo
    {
        public bool top, bottom, left, right, climbing;

        public float slopeAngle, old_slopeAngle;

        public void Reset()
        {
            climbing = false;
            top = false;
            bottom = false;
            left = false;
            right = false;

            old_slopeAngle = slopeAngle;

            slopeAngle = 0;
        }

    }
}