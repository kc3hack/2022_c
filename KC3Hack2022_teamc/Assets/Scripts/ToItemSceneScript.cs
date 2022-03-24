using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToItemSceneScript : MonoBehaviour
{
    public void Select()
    {
        SceneManager.LoadScene("Itemscene");
    }
}