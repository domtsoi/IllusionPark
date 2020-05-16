using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashcan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "PurpCrystal03")
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 400, 0));
        }
        
    }
}
