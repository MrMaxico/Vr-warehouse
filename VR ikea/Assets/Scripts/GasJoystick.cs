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
    public UnityEngine.XR.InputDevice deviceL;
    public UnityEngine.XR.InputDevice deviceR;
    private float triggerLeftValue;
    private float triggerRightValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //left gas forward
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device1L = leftHandDevices[0];
            deviceL = device1L;
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device1L.name, device1L.role.ToString()));
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        deviceL.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerLeftValue);

        if (triggerLeftValue > 0.1f)
        {
            Debug.Log(triggerLeftValue);
            heftruck.transform.Translate(wheel.transform.right * triggerLeftValue);
        }

        //rightGasForward

        var RightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, RightHandDevices);

        if (RightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device1R = RightHandDevices[0];
            deviceR = device1R;
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device1R.name, device1R.role.ToString()));
        }
        else if (RightHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        deviceR.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerRightValue);

        if (triggerRightValue > 0.1f)
        {
            Debug.Log(triggerRightValue);
            heftruck.transform.Translate(wheel.transform.right * -triggerRightValue);
        }

        /*
        if (holdingStick)
        {
            heftruck.transform.Translate(wheel.transform.right * triggerLeftValue);
            
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
        */

    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == ("playerLeftHand"))
        {
            print("wauw");
            transform.LookAt(other.transform.position, transform.up);
            holdingStick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("playerLeftHand"))
        {
            holdingStick = false;
        }
    }
    */
}
