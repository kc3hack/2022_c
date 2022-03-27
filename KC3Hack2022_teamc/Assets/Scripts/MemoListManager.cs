using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoListManager : MonoBehaviour
{
    public SaveJson save;
    GameObject memoPrefab;
    void Awake()
    {
        memoPrefab = (GameObject)Resources.Load("Prefabs/MemoList");
    }

    void Start()
    {
        List<MemoData> list = save.LoadM();
        int id = 0;
        foreach(MemoData memo in list){
            GameObject _memo = Instantiate (memoPrefab, this.transform);
            _memo.transform.Find("BackgroundImage/NameText").GetComponent<Text>().text = memo.MemoTitle;
            _memo.GetComponent<ToMemoSceneScript>().memoid = id;
            id++;
        }
    }
}
