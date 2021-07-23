using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    public Text textName;

    public void PlayButton()
    {
        SaveName();
        SceneManager.LoadScene("main");
    }

    public void SaveName()
    {
        string name = textName.text;
        DataManager.Instance.PlayerName = name;
    }


}
