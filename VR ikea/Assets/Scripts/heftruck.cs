using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class heftruck : MonoBehaviour
{
    public GameObject playerOrigin;
    public GameObject playerCamera;
    private RaycastHit hit;
    private bool inHeftruck;

    public InputActionReference gas;
    public InputActionReference inHeftruckButton;

    private void Start()
    {
        gas.action.performed += GasAndBreak;
        inHeftruckButton.action.performed += EnterHeftruck;
    }

    void Update()
    {

        if(inHeftruck)
        {
            Wheel();
            SteeringWheel();
        }
    }

    private void GasAndBreak(InputAction.CallbackContext obj)
    {
        //met de joystick van oculus wordt de gas en de rem bepaald

        // float joystick = -1, 0 of 1
        //heftruck.transform.Translate(heftruck.transform.forward * joystick);
    }

    private void EnterHeftruck(InputAction.CallbackContext obj)
    {
        if (inHeftruck)
        {
            inHeftruck = false;
            playerOrigin.transform.position = transform.position - new Vector3(2, 0, 0); // spawn speler naast heftruck, de speler stapt uit
        }

        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10);
        if (hit.transform.gameObject.tag == "heftruck")
        {
            inHeftruck = true;
            playerOrigin.transform.position = hit.transform.position;
            playerOrigin.transform.rotation = hit.transform.rotation;
        }
    }

    void Wheel()
    {

    }

    void SteeringWheel()
    {

    }


}
