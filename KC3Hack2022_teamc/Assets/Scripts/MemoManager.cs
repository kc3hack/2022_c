using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoManager : MonoBehaviour
{
    public int memoid;
    public SaveJson save;
    public Text titletext;
    public Text memotext;
    MemoData memo;
    void Start(){
       memoid = GameObject.Find("MemoList(Clone)").GetComponent<ToMemoSceneScript>().memoid;
       Destroy(GameObject.Find("MemoList(Clone)"));
       memo = save.LoadM()[memoid];
       titletext.text = memo.MemoTitle;
       memotext.text = memo.Memo;
    }

    public void Use(){
        save.PopM(memoid);
    }
}
