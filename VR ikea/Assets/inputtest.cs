using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class inputtest : MonoBehaviour {
    // Start is called before the first frame update
    public UnityEngine.XR.InputDevice device1;
    void Start() {

    }
    private void Update() {
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1) {
            UnityEngine.XR.InputDevice device = leftHandDevices[0];
            device1 = device;
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        } else if (leftHandDevices.Count > 1) {
            Debug.Log("Found more than one left hand!");
        }
        float triggerValue;
        device1.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out triggerValue);

        if (triggerValue > 0.1f) {
            Debug.Log(triggerValue);

        }
    }
}