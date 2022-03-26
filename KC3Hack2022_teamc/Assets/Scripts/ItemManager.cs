using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public int id;
    public SaveJson save;
    public Text nametext;
    public Text datetext;
    ItemData item;
    void Start(){
       item = save.Load()[id];
       nametext.text = item.ItemName;
       datetext.text = item.ItemY + "年 " + item.ItemM + "月 " + item.ItemD + "日";
    }
}
