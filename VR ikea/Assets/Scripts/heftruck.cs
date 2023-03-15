using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heftruck : MonoBehaviour
{
    public GameObject playerOrigin;
    private RaycastHit hit;
    private bool inHeftruck;
    
    void Update()
    {
        Physics.Raycast(playerOrigin.transform.position, playerOrigin.transform.forward, out hit, 10);
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
            Gas();
            Brake();
            Forks();
        }
    }

    void Gas()
    {

    }

    void Brake()
    {

    }

    void Forks()
    {

    }


}
