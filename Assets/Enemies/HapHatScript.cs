using UnityEngine;
using System.Collections;

public class HapHatScript : MonoBehaviour
{
    public character HapHat = new character();
    
    [SerializeField]
    float SizeOfTerritory;

    [SerializeField]
    LayerMask Layer;

    [SerializeField]
    Transform CenterOfHapHat;

    [SerializeField]
    float PowerJump;

    [SerializeField]
    float PowerSpeed;

    //public float playerTargetDistance;
    // public float enemyLookDistance;
    // public float attackDistance;
    // public float enemyMovementSpeed;
    // public float damping;
    // public Transform playerTarget;
    //public float HapHat;

    character Hero_Test = new character(); 
    void Start()
        {
        HapHat.rigidbody = gameObject.GetComponent<Rigidbody2D>();
        HapHat.transform = gameObject.GetComponent<Transform>();
        HapHat.animator = gameObject.GetComponent<Animator>();
        HapHat.spr_renderer = gameObject.GetComponent<SpriteRenderer>();
        HapHat.col_Circle = gameObject.GetComponent<CircleCollider2D>();
        HapHat.col_Polygon = gameObject.GetComponent<PolygonCollider2D>();
      
       


        Hero_Test.col_Box = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Hero_Test.transform = GameObject.Find("Player").GetComponent<Transform>();
        HapHat.power_Speed = PowerSpeed;

        HapHat.power_Jump = PowerJump;


    }

    void Move()
    {     
        if (HapHat.col_Circle.bounds.Intersects(Hero_Test.col_Box.bounds))
        {
            if (HapHat.transform.position.x > Hero_Test.transform.position.x )
            {
               // Debug.Log("I see you doubly...");
                HapHat.animator.SetInteger("Direction", 0);
                HapHat.rigidbody.velocity = new Vector2(-HapHat.power_Speed, HapHat.rigidbody.velocity.y);
            }
            if (HapHat.transform.position.x < Hero_Test.transform.position.x)
            {
                HapHat.animator.SetInteger("Direction", 1);
                HapHat.rigidbody.velocity = new Vector2(HapHat.power_Speed, HapHat.rigidbody.velocity.y);
            }
        }     
    }
 
    void Update()
    {

        Move();
        while (HapHat.animator.Int("Direction", 1)) {

        }
        //gameObject.GetComponent<SpriteRenderer>().flipX = true;


    }

}

     


 