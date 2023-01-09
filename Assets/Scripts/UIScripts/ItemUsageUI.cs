using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUsageUI : MonoBehaviour
{
    private Image ItemUsageBarSlider;


    void Start()
    {
        ItemUsageBarSlider = GetComponentInChildren<Image>();
        ItemUsageBarSlider.fillAmount = 1f;
    }

    public void UpdateRemains(float usage)
    {
        ItemUsageBarSlider.fillAmount = usage;
    }
}
