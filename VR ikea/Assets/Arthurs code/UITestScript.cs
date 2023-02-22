using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITestScript : MonoBehaviour
{
    public TMP_InputField testInput;
    public TMP_Text testText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestInputSave() {
        testText.text = testInput.text;
    }
}
