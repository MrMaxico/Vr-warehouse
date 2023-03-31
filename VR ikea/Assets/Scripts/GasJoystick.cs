using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasJoystick : MonoBehaviour
{
    public Transform topJoystickGas;
    public float forwardBackwardTiltGas = 0;
    public GameObject heftruck;
    public GameObject wheel;
    private bool holdingStick;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(holdingStick)
        {
            heftruck.transform.Translate(wheel.transform.right * speed);
            forwardBackwardTiltGas = topJoystickGas.rotation.eulerAngles.x;
            if (forwardBackwardTiltGas < 355 && forwardBackwardTiltGas > 290)
            {
                forwardBackwardTiltGas = Mathf.Abs(forwardBackwardTiltGas - 360);
                Debug.Log("Backward" + forwardBackwardTiltGas);
                speed = (-forwardBackwardTiltGas / 1400) / 2;
            }

            else if (forwardBackwardTiltGas > 5 && forwardBackwardTiltGas < 74)
            {
                Debug.Log("Forward" + forwardBackwardTiltGas);
                speed = (forwardBackwardTiltGas / 1400) / 2;

            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("playerRightHand"))
        {
            print("wauw");
            transform.LookAt(other.transform.position, transform.up);
            holdingStick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("playerRightHand"))
        {
            holdingStick = false;
        }
    }
}
