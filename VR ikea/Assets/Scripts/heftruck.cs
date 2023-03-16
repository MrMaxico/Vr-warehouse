using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heftruck : MonoBehaviour
{
    public GameObject playerOrigin;
    public GameObject playerCamera;
    private RaycastHit hit;
    private bool inHeftruck;
    
    void Update()
    {
        Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10);
        if (hit.transform.gameObject.tag == "heftruck" && Input.GetKeyDown(KeyCode.H)) // speler kijkt naar heftruck en klikt op "h" om in te stappen
        {
            inHeftruck = true;
            playerOrigin.transform.position = hit.transform.position;
            playerOrigin.transform.rotation = hit.transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.H) && inHeftruck)
        {
            inHeftruck = false;
            playerOrigin.transform.position = transform.position - new Vector3(2, 0, 0); // spawn speler naast heftruck, de speler stapt uit
        }

        if(inHeftruck)
        {
            GasAndBreak();
            Wheel();
            Forks();
        }
    }

    void GasAndBreak()
    {
        //met de joystick van oculus wordt de gas en de rem bepaald
    }

    void Wheel()
    {

    }

    void Forks()
    {

    }


}
