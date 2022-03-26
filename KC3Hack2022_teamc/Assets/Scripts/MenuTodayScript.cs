using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MenuTodayScript : MonoBehaviour
{
    public Text todayText;
    DateTime todayNow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        todayNow = DateTime.Now;

        todayText.text = todayNow.Month.ToString() + "月" + todayNow.Day.ToString() + "日";
    }
}
