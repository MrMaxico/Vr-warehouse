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
    public float wheelRotation;

    void Start()
    {
        
    }

    void Update()
    {

        Vector3 rotation = wheels[0].transform.rotation.eulerAngles;
        float zRotation = rotation.z;

        // Clamp the z rotation between the min and max values
        zRotation = Mathf.Clamp(zRotation, -50, 50);

        // Set the new rotation
        wheels[0].transform.rotation = Quaternion.Euler(rotation.x, rotation.y, zRotation);


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
                wheelRotation = wheels[1].transform.rotation.z;
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
