using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeftruckJoystick : MonoBehaviour
{
    public Transform topJoystick;

    public float forwardBackwardTilt = 0;

    public float sideToSideTilt = 0;

    public GameObject forks;
    private bool canGoHigher;
    private bool canGoLower;

    private void Start()
    {
        canGoHigher = true;
        canGoLower = true;
    }

    void Update()
    {
        forwardBackwardTilt = topJoystick.rotation.eulerAngles.x;
        if (forwardBackwardTilt < 355 && forwardBackwardTilt > 290)
        {
            forwardBackwardTilt = Mathf.Abs(forwardBackwardTilt - 360);
            Debug.Log("Backward" + forwardBackwardTilt);
            if(canGoLower)
            {
                forks.transform.Translate(-Vector3.up * (forwardBackwardTilt / 1400) * 2);
                canGoHigher = true;
                if(forks.transform.position.y < 0)
                {
                    print("teLaag");
                    canGoLower = false;
                }
            }
        }

        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            Debug.Log("Forward" + forwardBackwardTilt);

            if (canGoHigher)
            {
                forks.transform.Translate(Vector3.up * (forwardBackwardTilt / 1400) * 2);
                canGoLower = true;
                if (forks.transform.position.y > 2)
                {
                    print("teHoog");
                    canGoHigher = false;
                }
            }
        }

        /*
        sideToSideTilt = topJoystick.rotation.eulerAngles.z;
        if (sideToSideTilt < 355 && sideToSideTilt > 290)
        {
            sideToSideTilt = Mathf.Abs(sideToSideTilt - 360);
            Debug.Log("Right" + sideToSideTilt);

        }

        else if (sideToSideTilt > 5 && sideToSideTilt < 74)
        {
            Debug.Log("Left" + sideToSideTilt);
        }
        */


    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == ("playerRightHand"))
        {
            print("wauw");
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
