using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateTimeTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(System.DateTime.Now.ToString("yyyyMMddHHmmss"));
        Debug.Log(System.DateTime.Now.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
