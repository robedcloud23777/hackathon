using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update4

    public InputField InputField;
    public GameObject scanObject;
    
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
    }
    void Update()

    {
        
    }
}
