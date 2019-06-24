using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto : MonoBehaviour
{
    Animator anim;
    public Rigidbody rb;
    public static bool isAuto;
    public float speedV;
    private bool inTrigger;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        isAuto = true;
        anim = this.GetComponent<Animator>();
        inTrigger = false;
        rb = this.GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Load" && isAuto)
        {
            inTrigger = true;
            this.transform.position = other.transform.position;
            // this.transform.rotation = other.transform.rotation;
            target = other.transform;
            //delta = Mathf.Abs(transform.rotation.y - ) < Mathf.Abs(nodeRotation - transform.rotation.y) ? transform.rotation.y - nodeRotation : nodeRotation - transform.rotation.y;
        }
        if (other.tag == "Finish")
        {
            isAuto = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
            anim.SetFloat("inputV", 1.0F);
            if (!inTrigger)
            {
                float moveZ = 200f * Time.deltaTime;
                rb.velocity = transform.forward * speedV * moveZ * Time.deltaTime;
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 100 * Time.deltaTime);

                if (Mathf.Abs(this.transform.rotation.y - target.rotation.y) < 0.01F)
                {
                    inTrigger = false;
                }
            }

    }
}

