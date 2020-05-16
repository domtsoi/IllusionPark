using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript2 : MonoBehaviour
{
    public float charge;
    MagnetScript1 other_magnet_script;
    public Vector3 position;
    public GameObject other_magnet;
    public float control_constant;


    // Start is called before the first frame update
    void Start()
    {
        this.charge = 1.0f;
        this.control_constant = 50.0f;
        if (other_magnet == null)
        {
            Debug.Log("Set the other magnet");
        };
        other_magnet = GameObject.Find("MoonStone04");
        other_magnet_script = other_magnet.GetComponent<MagnetScript1>(); 
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(this.control_constant * this.CalculateForceVector() * this.CalculateForce());
    }

    float CalculateForce()
    {
        float other_charge = other_magnet_script.charge;
        float distance = Vector3.Distance(this.transform.position, other_magnet.transform.position);
        float force = Mathf.Abs(this.charge * other_charge) / Mathf.Pow(distance, 2);
        return force;
    }

    Vector3 CalculateForceVector()
    {
        Vector3 force_vector;
        float other_charge = other_magnet_script.charge;
        if (other_charge < 0 && charge < 0)
        {
            //Debug.Log("They're both same charge");
            force_vector = this.transform.position - other_magnet.transform.position;
        }
        else if (other_charge > 0 && this.charge > 0)
        {
            //Debug.Log("They're both same charge");
            force_vector = this.transform.position - other_magnet.transform.position;
        }
        /*if (other_charge > 0 && charge < 0)
        {
            force_vector = other_magnet.transform.position - this.transform.position;
        }
        if (other_charge > 0 && charge < 0)*/
        else
        {
            //Debug.Log("They're both oposite charge");
            force_vector = other_magnet.transform.position - this.transform.position;
        }
        return Vector3.Normalize(force_vector);
    }
}
