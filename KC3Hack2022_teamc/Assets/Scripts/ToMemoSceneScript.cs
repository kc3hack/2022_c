using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMemoSceneScript : MonoBehaviour
{
    public int memoid;
    public void Select()
    {
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("MemoScene");
    }
}
