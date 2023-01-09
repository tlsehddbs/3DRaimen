using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    private Text _Result;


    void Start()
    {
        _Result = GameObject.Find("ResultText").GetComponent<Text>();
    }

    void Update()
    {
        if(GameManager.state == GameManager.playerState.Fail)
        {
            _Result.text = "Fail";
        }
        if(GameManager.isCleared)
        {
            _Result.text = "Clear!";
        }
    }
}
