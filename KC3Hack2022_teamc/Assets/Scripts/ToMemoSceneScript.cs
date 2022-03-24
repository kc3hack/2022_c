using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMemoSceneScript : MonoBehaviour
{
    public void Select()
    {
        SceneManager.LoadScene("MemoScene");
    }
}
