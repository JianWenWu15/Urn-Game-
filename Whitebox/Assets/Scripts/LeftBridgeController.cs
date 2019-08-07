using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBridgeController : MonoBehaviour
{
    public GameObject LeftBridge;
    private GameObject playerObject;
    private GameObject LeftLever;

    void Start()
    {
        LeftLever = GameObject.FindGameObjectWithTag("LeftLever");
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E) && (playerObject.transform.position.x >= LeftLever.transform.position.x - 3f && playerObject.transform.position.x < LeftLever.transform.position.x + 3f))
        {
            LeftBridge.GetComponent<Animator>().Play("LeftDrawing");

        }
    }

}
