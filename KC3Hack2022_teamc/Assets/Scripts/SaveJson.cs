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
    ItemDataList saveItamData;

    void Awake()
    {
        //変数の初期化処理を行う
        filePath = Application.persistentDataPath + "/" + ".savedata.json"; 
        Load();
    }

    //ItemDataを引数に呼び出すとListを更新しJsonに登録します
    public void Save(ItemData item)
    {
        saveItamData.itemDatas.Add(item);

        Debug.Log(filePath);
        string json = JsonUtility.ToJson(saveItamData);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
    }


    //JsonからロードしてItemDataのListを返す
    //Jsonファイルが存在しない場合nullが返される
    public List<ItemData> Load()
    { 
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            saveItamData = JsonUtility.FromJson<ItemDataList>(data);
            Debug.Log(saveItamData.itemDatas);
            return saveItamData.itemDatas;
        }
        else{
            saveItamData = new ItemDataList();
            return new List<ItemData>();
        }
        
    }

}
