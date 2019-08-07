using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform HoldPoint;
    public float throwforce;
    public LayerMask notgrabbed;
    private float vertical;


    public Transform leftFootStart;
    public Transform leftFootEnd;
    public Transform rightFootStart;
    public Transform rightFootEnd;

    public bool leftFootHurts;
    public bool rightFootHurts;

    public LayerMask thingsICanJumpOn;

    void Update()
    { 
        leftFootHurts = Physics2D.Linecast(new Vector2(leftFootStart.position.x, leftFootStart.position.y), new Vector2(leftFootEnd.position.x, leftFootEnd.position.y), thingsICanJumpOn);
        rightFootHurts = Physics2D.Linecast(new Vector2(rightFootStart.position.x, rightFootStart.position.y), new Vector2(rightFootEnd.position.x, rightFootEnd.position.y), thingsICanJumpOn);

        if (leftFootHurts)
        {
            Debug.DrawLine(new Vector2(leftFootStart.position.x, leftFootStart.position.y), new Vector2(leftFootEnd.position.x, leftFootEnd.position.y), Color.red);
        }
        else
        {
            Debug.DrawLine(new Vector2(leftFootStart.position.x, leftFootStart.position.y), new Vector2(leftFootEnd.position.x, leftFootEnd.position.y), Color.white);
        }
        if (rightFootHurts)
        {
            Debug.DrawLine(new Vector2(rightFootStart.position.x, rightFootStart.position.y), new Vector2(rightFootEnd.position.x, rightFootEnd.position.y), Color.red);
        }
        else
        {
            Debug.DrawLine(new Vector2(rightFootStart.position.x, rightFootStart.position.y), new Vector2(rightFootEnd.position.x, rightFootEnd.position.y), Color.white);
        }
        

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
     vertical = Input.GetAxis("Vertical") * (runSpeed / 4);
        if (Input.GetButtonDown("Jump") && (leftFootHurts || rightFootHurts)) 
        {
            jump = true;
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                if (hit.collider != null && hit.collider.tag == "grabbable")
                {
                    grabbed = true;
                    runSpeed = 20f;
                }
            }
            else if (!Physics2D.OverlapPoint(HoldPoint.position, notgrabbed))
            {
                grabbed = false;
                runSpeed = 80f;
            }
        }
        if (grabbed)
        {
            hit.collider.gameObject.transform.position = HoldPoint.position;
            Debug.Log("Check 1: " + runSpeed);
        }
            
        if (Input.GetKeyDown(KeyCode.T) && !Physics2D.OverlapPoint(HoldPoint.position, notgrabbed) && grabbed)
        {
            grabbed = false;
            runSpeed = 80f;
            Debug.Log("Check 2: " + runSpeed);
            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                Debug.Log("Check 3: " + runSpeed);
            }
        }
        
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, grabbed);
        jump = false;

        Debug.Log("Check 4: " + runSpeed);
        

    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Debug.DrawLine(new Vector3 (transform.position.x, transform.position.y -0.1f,transform.position.z), Vector2.down, Color.red, 1f);
    }
    
    
}
