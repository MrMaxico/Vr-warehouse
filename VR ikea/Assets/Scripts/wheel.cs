using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    public Transform handPosition;  // the position of the hand
    public float wheelRadius = 1.0f;  // the radius of the wheel

    private float prevAngle = 0.0f;
    private bool holdingWheel;

    public GameObject[] wheels;
    public GameObject middleWheel;

    void Start()
    {
        
    }

    void Update()
    { 
        if (holdingWheel)
        {
            Vector3 handDir = handPosition.position - transform.position;
            handDir.y = 0.0f;

            float angle = Vector3.SignedAngle(transform.forward, handDir, Vector3.up);

            if (Mathf.Abs(angle) > 1e-3)
            {
                float deltaAngle = angle - prevAngle;
                prevAngle = angle;

                transform.Rotate(Vector3.up, deltaAngle, Space.Self);
                for (int i = 0; i < wheels.Length; i++)
                {
                    wheels[i].transform.Rotate(0, 0, -transform.rotation.y);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playerLeftHand")
        {
            holdingWheel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "playerLeftHand")
        {
            holdingWheel = false;
        }
    }
}
