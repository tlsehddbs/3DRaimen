using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownText : MonoBehaviour
{
    private TextMeshProUGUI _Countdown;
    public float countdownTime;


    private void Awake()
    {
        _Countdown = GameObject.Find("CountdownText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        StartCoroutine(Wait());
    }

    void Countdown()
    {
        countdownTime -= Time.deltaTime;

        _Countdown.text = countdownTime < 1 ? "GO" : ((int)countdownTime).ToString();

        if (countdownTime < 0)
        {
            GameManager.state = GameManager.playerState.Play;
            return;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
        Countdown();
    }
}
