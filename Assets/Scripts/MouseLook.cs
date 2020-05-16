using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Variables
    float mouse_x = 0.0f;
    float mouse_y = 0.0f;
    public float sensitivity = 150.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float cur_mouse_x = Input.GetAxis("Mouse X");
        float cur_mouse_y = Input.GetAxis("Mouse Y");
        
        mouse_x += cur_mouse_x * Time.deltaTime * sensitivity;
        mouse_y += cur_mouse_y * Time.deltaTime * sensitivity;
        if (mouse_y < -90)
        {
            mouse_y = -90;
        }
        else if (mouse_y > 90)
        {
            mouse_y = 90;
        }

        transform.localEulerAngles = new Vector3(-mouse_y, mouse_x, 0.0f);
    }
}
