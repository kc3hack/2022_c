using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{
    public string ItemName;
    public int ItemV;
    public int ItemY;
    public int ItemM;
    public int ItemD;
    public int ItemND;
}

public class ItemSaveJsonScript : MonoBehaviour
{
    //登録ボタンを押したときの処理
    public void select()
    {
        ItemData itemDataWrap = new ItemData();
        itemDataWrap.ItemName = ItemRegisterScript.RegIName();
        itemDataWrap.ItemV = ItemRegisterScript.RegIV();
        itemDataWrap.ItemY = ItemRegisterScript.RegIY();
        itemDataWrap.ItemM = ItemRegisterScript.RegIM();
        itemDataWrap.ItemD = ItemRegisterScript.RegID();
        itemDataWrap.ItemND = ItemRegisterScript.RegIND();
    }
}