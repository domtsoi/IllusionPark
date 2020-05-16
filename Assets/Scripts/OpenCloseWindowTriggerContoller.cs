using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseWindowTriggerContoller : MonoBehaviour
{
    public GameObject reactable;
    public GameObject player;
    bool isOpen = false;
    bool isMoving = false;
    Vector3 current_loc;
    Vector3 open_vector;
    Vector3 close_vector;

    // Start is called before the first frame update
    void Start()
    {
        current_loc = transform.localPosition;
        open_vector = new Vector3(-0.001f, 0.0f, 0.0f);
        close_vector = new Vector3(0.001f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("Update isOpen: " + isOpen);
        //Debug.Log("Update isMoving: " + isOpen);
        //Debug.Log("Update Current_Loc_x: " + current_loc.x);
        if (!isOpen && isMoving)
        {
            //Debug.Log("Opening..");
            current_loc += open_vector;
            this.transform.Translate(open_vector, Space.Self);
        }
        if (isOpen && isMoving)
        {
            //Debug.Log("Closing..");
            current_loc += close_vector;
            this.transform.Translate(close_vector, Space.Self);
        }
        if (current_loc.x <= 0.0f)
        {
            isMoving = false;
            isOpen = true;

        }
        if (current_loc.x >= 0.595f)
        {
            isMoving = false;
            isOpen = false;
        }
    }

    void OnMouseDown()
    {
        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        //Debug.Log("Mouse isOpen: " + isOpen);
        //Debug.Log("Mouse isMoving: " + isOpen);
        //Debug.Log("Mouse Current_Loc_x: " + current_loc.x);
        if (distance > 2.0f)
        {
            return;
        }
        if (current_loc.x <= 0.0f)
        {
            isMoving = true;
            isOpen = true;
        }
        if (current_loc.x >= 0.595f)
        {
            isMoving = true;
            isOpen = false;
        }
    }
}
