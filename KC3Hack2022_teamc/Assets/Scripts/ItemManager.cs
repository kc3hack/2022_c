using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public int itemid;
    public SaveJson save;
    public Text nametext;
    public Text datetext;
    public Text valuetext;
    ItemData item;
    void Start(){
       itemid = GameObject.Find("ListImage(Clone)").GetComponent<ToItemSceneScript>().itemid;
       Destroy(GameObject.Find("ListImage(Clone)"));
       item = save.Load()[itemid];
       nametext.text = item.ItemName;
       datetext.text = item.ItemY + "年 " + item.ItemM + "月 " + item.ItemD + "日";
       valuetext.text = item.ItemV + "個";
    }

    public void Use(){
        save.Pop(itemid,1);
    }
}
