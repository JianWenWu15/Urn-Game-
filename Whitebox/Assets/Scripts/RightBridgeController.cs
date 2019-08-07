using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBridgeController : MonoBehaviour
{
    public GameObject RightBridge;
    private GameObject playerObject;
    private GameObject RightLever;

    void Start()
    {
        RightLever = GameObject.FindGameObjectWithTag("RightLever");
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && (playerObject.transform.position.x >= RightLever.transform.position.x - 3f && playerObject.transform.position.x < RightLever.transform.position.x + 3f))
        {
            Debug.Log("right");
            RightBridge.GetComponent<Animator>().Play("RightDrawing");
        }
    }
   
        
}
