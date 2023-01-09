using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject OptionsTap;

    public void OnClickPlayButton()
    {
        gameObject.SetActive(false);
    }

    public void OnClickSettingButton()
    {
        gameObject.SetActive(false);
        OptionsTap.SetActive(true);
    }


    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
