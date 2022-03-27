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

[Serializable]
public class MemoDataList{
    public List<MemoData> memoDatas;
    public MemoDataList(){
        memoDatas = new List<MemoData>();
    }
}

public class SaveJson : MonoBehaviour
{
    public Time_Manager push;
    string filePath;
    string filePathM;
    ItemDataList saveItamData;
    MemoDataList saveMemoData;

    void Awake()
    {
        //変数の初期化処理を行う
        filePath = Application.persistentDataPath + "/" + ".savedata.json"; 
        filePathM = Application.persistentDataPath + "/" + ".savedataM.json"; 
        Load();
        LoadM();
    }

    //ItemDataを引数に呼び出すとListを更新しJsonに登録します
    public void Save(ItemData item)
    {
        if(item != null){saveItamData.itemDatas.Add(item);}
        
        string json = JsonUtility.ToJson(saveItamData);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json); streamWriter.Flush();
        streamWriter.Close();
        push.SettingPush(saveItamData.itemDatas);
    }

    public void SaveM(MemoData memo)
    {
        if(memo != null){saveMemoData.memoDatas.Add(memo);}
        
        string json = JsonUtility.ToJson(saveMemoData);
        StreamWriter streamWriter = new StreamWriter(filePathM);
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
            return saveItamData.itemDatas;
        }
        else{
            saveItamData = new ItemDataList();
            return new List<ItemData>();
        }
        
    }

    public List<MemoData> LoadM()
    { 
        if (File.Exists(filePathM))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePathM);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            saveMemoData = JsonUtility.FromJson<MemoDataList>(data);
            return saveMemoData.memoDatas;
        }
        else{
            saveMemoData = new MemoDataList();
            return new List<MemoData>();
        }
        
    }

    public void Pop(int id, int value){
        Load();
        saveItamData.itemDatas[id].ItemV -= value;
        if(saveItamData.itemDatas[id].ItemV <= 0){saveItamData.itemDatas.RemoveAt(id);}
        Save(null);
    }
    public void PopM(int id){
        LoadM();
        saveMemoData.memoDatas.RemoveAt(id);
        SaveM(null);
    }

}
