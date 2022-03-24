using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class ItemDataList{
    public List<ItemData> itemDatas;
    public ItemDataList(){
        itemDatas = new List<ItemData>();
    }
}

public class SaveJson : MonoBehaviour
{
    string filePath;
    ItemDataList save;


    void Awake()
    {
        //変数の初期化処理を行う
        filePath = Application.persistentDataPath + "/" + ".savedata.json"; 
        save = new ItemDataList();
        ItemData testitem = new ItemData();
    }

    public void Save(ItemData item)
    {
        save.itemDatas.Add(item);

        Debug.Log(filePath);
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
    }

    public ItemDataList Load()
    { 
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<ItemDataList>(data);
            Debug.Log(save.itemDatas);
            return save;
        }
        return null;
    }

}
