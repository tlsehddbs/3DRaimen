using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private Image RaimenImage;
    [SerializeField] private GameObject EggImage;
    [SerializeField] private TextMeshProUGUI ScoreText;

    private int Score = 0;
    private bool IsEnd = true;

    void Start()
    {
        if (GameManager.isEatEgg == true)
        {
            EggImage.SetActive(true);
        }
        else
        {
            EggImage.SetActive(false);
        }

        var eggPoint = (GameManager.isEatEgg ? 500 : 1);
        var doubleJump = (useItem.useShortJump ? 1 : 2);
        var score = 0.2 * (Mathf.Pow(GameManager.Hp, 2) * eggPoint * (useItem.longJumpRemainAmount * 100) * doubleJump) / MathF.Cbrt(TimerText.currentTime);

        if (useItem.useShortJump == false && useItem.longJumpRemainAmount > 0)
        {
            RaimenImage.sprite = Resources.Load<Sprite>("raimenComple");
        }
        else if (useItem.useShortJump == false && useItem.longJumpRemainAmount <= 0)
        {
            RaimenImage.sprite = Resources.Load<Sprite>("RaimenNoSup");
        }
        else if (useItem.useShortJump == true && useItem.longJumpRemainAmount <= 0)
        {
            RaimenImage.sprite = Resources.Load<Sprite>("RaimenNoSupNoGun");
        }
        else
        {
            RaimenImage.sprite = Resources.Load<Sprite>("raimenComple");
        }

        var ScoreText = "Hp\t: " +  Mathf.RoundToInt(GameManager.Hp) + 
                        "\nTime\t: " +  Mathf.RoundToInt(TimerText.currentTime) + "(sec)" +
                        "\nEgg\t: " + eggPoint + " X" +
                        "\n\nJump\t: " + doubleJump + " X" +
                        "\nBoost\t: " + Math.Truncate(useItem.longJumpRemainAmount * 100) + " X" +
                        "\n\nScore\t: " + (Mathf.RoundToInt((float)score) > 9999999 ? 9999999 : Mathf.RoundToInt((float)score));
        
        StartCoroutine(Typing(this.ScoreText, ScoreText, 0.2f));
    }
    
    void Update()
    {

    }
    
    IEnumerator Typing(TextMeshProUGUI typingText, string message, float speed) 
    { 
        for (int i = 0; i < message.Length; i++) 
        { 
                typingText.text = message.Substring(0, i + 1); 
                yield return new WaitForSeconds(speed); 
        }
        yield return new WaitForSeconds(2);

    } 
}
