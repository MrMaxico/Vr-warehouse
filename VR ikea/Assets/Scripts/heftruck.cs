using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.XR;

public class heftruck : MonoBehaviour
{
    public GameObject playerOrigin;
    public GameObject playerCamera;
    private bool inHeftruck;
    public InputActionReference inHeftruckButton;
    public GameObject wheel;
    public Transform trigger;
    private RaycastHit hit;
    private void Start()
    {
        inHeftruckButton.action.performed += EnterHeftruck;
    }

    void Update()
    {

        if (inHeftruck)
        {
            playerOrigin.transform.position = trigger.position;
            playerOrigin.transform.rotation = trigger.rotation;
        }

        //test
        if (inHeftruck && Input.GetKeyDown(KeyCode.H))
        {
            inHeftruck = false;
            playerOrigin.transform.position = transform.position - new Vector3(2, 0, 0); // spawn speler naast heftruck, de speler stapt uit
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            print("poep");
            inHeftruck = true;
        }
        //test
    }

    private void EnterHeftruck(InputAction.CallbackContext obj)
    {
        if (inHeftruck)
        {
            inHeftruck = false;
            playerOrigin.transform.position = transform.position - new Vector3(2, 0, 0); // spawn speler naast heftruck, de speler stapt uit
        }

        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10);
        if (hit.transform.gameObject.tag == "forklift")
        {
            inHeftruck = true;
        }
    }
}
