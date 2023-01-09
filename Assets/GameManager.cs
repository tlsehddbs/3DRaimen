using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public static float Hp = 100;

    public GameObject MenuUI;
    public GameObject OptionsUI;
    public GameObject TimerUI;
    public GameObject CountdownUI;
    public GameObject EggUI;
    public GameObject ResultUI;

    public GameObject HealthBarUI;
    public GameObject ItemGaugeUI;

    public static bool startingCount = false;
    public static bool isPaused = false;
    public static bool isCleared = false;
    public static bool isEatEgg = false;
    public static bool isEatCheese = false;


    public enum playerState
    {
        Ready,
        Play,
        Finish,
        Fail
    }

    [HideInInspector]
    public static playerState state;


    private void Awake()
    {
        state = playerState.Ready;

        // √ ±‚»≠
        Hp = 100;
        TimerText.currentTime = 0;
        startingCount = false;
        isCleared = false;
        isEatEgg = false;
        isEatCheese = false;
    }

    private void Update()
    {
        if (isEatEgg == true)
        {
            EggUI.SetActive(true);
        }

        if (state != playerState.Ready)
        {
            // Main menu
            if (Input.GetButtonDown("Cancel"))
            {
                if (MenuUI.activeSelf)
                    MenuUI.SetActive(false);
                else if (!isPaused)
                    MenuUI.SetActive(true);
            }
        }

        if (MenuUI.activeSelf || OptionsUI.activeSelf)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
        }

        Cursor.visible = isPaused;

        PlayerStateManager();


        if (Hp <= 0)
        {
            state = playerState.Fail;
        }
    }


    private void PlayerStateManager()
    {
        switch (state)
        {
            case playerState.Ready:
                {
                    TimerUI.SetActive(false);
                    CountdownUI.SetActive(true);
                    break;
                }
            case playerState.Play:
                {
                    HealthBarUI.SetActive(true);
                    ItemGaugeUI.SetActive(true);
                    TimerUI.SetActive(true);
                    CountdownUI.SetActive(false);
                    startingCount = true;
                    break;
                }
            case playerState.Finish:
                {
                    HealthBarUI.SetActive(false);
                    ItemGaugeUI.SetActive(false);
                    TimerUI.SetActive(false);
                    ResultUI.SetActive(true);
                    startingCount = false;
                    isCleared = true;
                    Cursor.visible = true;
                    break;
                }
            case playerState.Fail:
                {
                    HealthBarUI.SetActive(false);
                    ItemGaugeUI.SetActive(false);
                    TimerUI.SetActive(false);
                    ResultUI.SetActive(true);
                    startingCount = false;
                    Cursor.visible = true;
                    break;
                }
        }
    }
}
