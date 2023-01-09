using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    private TextMeshProUGUI _Time;

    [Tooltip("초 단위로 입력")]
    public static float currentTime = 0;

    private int mm;
    private float ss;


    private void Awake()
    {
        _Time = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        mm = (int)currentTime / 60;
        ss = (int)currentTime % 60;
    }

    void Update()
    {
        if (GameManager.startingCount == false || currentTime < 0) return;

        currentTime += Time.deltaTime;
        mm = (int)currentTime / 60;
        ss = (int)currentTime % 60;

        _Time.text = string.Format("{0:D1}:{1:D2}", mm, (int)ss);
    }
}