using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeftruckJoystick : MonoBehaviour
{
    public Transform topJoystickFork;
    public float forwardBackwardTiltFork = 0;
    public GameObject forks;
    private bool forkCanGoHigher;
    private bool forkCanGoLower;


    private void Start()
    {
        forkCanGoHigher = true;
        forkCanGoLower = true;
    }

    void Update()
    {
        Forklift();
    }

    public void Forklift()
    {
        forwardBackwardTiltFork = topJoystickFork.rotation.eulerAngles.x;
        if (forwardBackwardTiltFork < 355 && forwardBackwardTiltFork > 290)
        {
            forwardBackwardTiltFork = Mathf.Abs(forwardBackwardTiltFork - 360);
            Debug.Log("Backward" + forwardBackwardTiltFork);
            if (forkCanGoLower)
            {
                forks.transform.Translate(-Vector3.up * (forwardBackwardTiltFork / 1400) * 2);
                forkCanGoHigher = true;
                if (forks.transform.position.y < 0)
                {
                    print("teLaag");
                    forkCanGoLower = false;
                }
            }
        }

        else if (forwardBackwardTiltFork > 5 && forwardBackwardTiltFork < 74)
        {
            Debug.Log("Forward" + forwardBackwardTiltFork);

            if (forkCanGoHigher)
            {
                forks.transform.Translate(Vector3.up * (forwardBackwardTiltFork / 1400) * 2);
                forkCanGoLower = true;
                if (forks.transform.position.y > 2)
                {
                    print("teHoog");
                    forkCanGoHigher = false;
                }
            }
        }
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
