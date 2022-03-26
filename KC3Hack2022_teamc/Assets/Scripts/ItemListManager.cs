using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListManager : MonoBehaviour
{
    public SaveJson save;
    GameObject itemPrefab;
    void Awake()
    {
        itemPrefab = (GameObject)Resources.Load("Prefabs/ListImage");
    }

    void Start()
    {
        List<ItemData> list = save.Load();
        foreach(ItemData item in list){
            GameObject _item = Instantiate (itemPrefab, this.transform);
            _item.transform.Find("BackgroundImage/NameText").GetComponent<Text>().text = item.ItemName;
            _item.transform.Find("BackgroundImage/DateText").GetComponent<Text>().text = item.ItemY + "年" + item.ItemM + "月" + item.ItemD + "日";
        }
    }
}
