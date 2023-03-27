using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class heftruck : MonoBehaviour
{
    public GameObject playerOrigin;
    public GameObject playerCamera;
    private RaycastHit hit;
    private bool inHeftruck;
    public InputActionReference inHeftruckButton;
    public float movementAxis;

    private void Start()
    {
        inHeftruckButton.action.performed += EnterHeftruck;
    }

    void Update()
    {
        
        
        if (inHeftruck)
        {
            Wheel();
            GasAndBreak();
        }
    }

    private void GasAndBreak()
    {
        //met de joystick van oculus wordt de gas en de rem bepaald
        Vector2 axis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        movementAxis = axis.x;
        // float joystick = -1, 0 of 1
        transform.Translate(transform.forward * movementAxis);
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
}
