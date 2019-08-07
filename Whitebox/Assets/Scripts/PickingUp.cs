using UnityEngine;
using System.Collections;

public class PickingUp : MonoBehaviour
{

    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 2f;
    public Transform HoldPoint;
    public float throwforce;
    public LayerMask notgrabbed;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                if (hit.collider != null && hit.collider.tag == "grabbable")
                {
                    grabbed = true;
                }
                //grab
            }
            else if (!Physics2D.OverlapPoint(HoldPoint.position, notgrabbed))
            {
                grabbed = false;
               if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
              {                  
                 hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwforce;
                }
                //throw
            }
        }
        if (grabbed)
            hit.collider.gameObject.transform.position = HoldPoint.position;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}