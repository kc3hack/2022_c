using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour
{
    public GameObject mestxt;
    // Start is called before the first frame update
    void Start()
    {
        int MN = Random.Range(1,4);

        if (MN == 1)
        {
            mestxt.GetComponent<Text>().text = "あるもの確認した？";
        }
        else if (MN == 2)
        {
            mestxt.GetComponent<Text>().text = "今日は何食べよう？";
        }
        else if (MN == 3)
        {
            mestxt.GetComponent<Text>().text = "お腹すいた...";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
