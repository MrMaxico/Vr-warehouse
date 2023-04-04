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
    public UnityEngine.XR.InputDevice device1;
    private float triggerValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        heftruck.transform.Translate(wheel.transform.right * triggerValue);
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = leftHandDevices[0];
            device1 = device;
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        device1.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerValue);

        if (triggerValue > 0.1f)
        {
            Debug.Log(triggerValue);

        }

        if (holdingStick)
        {
            heftruck.transform.Translate(wheel.transform.right * triggerValue);
            /*
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
            */
        }
        
    }

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
}
