using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarehouseManager : MonoBehaviour
{
    int levelCounter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int num) {
        if(levelCounter == num) {
            SceneManager.LoadScene("Level" + num);
        }
    }
}
