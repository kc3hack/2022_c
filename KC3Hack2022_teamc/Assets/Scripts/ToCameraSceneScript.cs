using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCameraSceneScript : MonoBehaviour
{
    public void Select()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
