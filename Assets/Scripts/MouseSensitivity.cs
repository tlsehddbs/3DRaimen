using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MouseSensitivity : MonoBehaviour
{
    public Slider mouseXSensitivitySlider;
    public Slider mouseYSensitivitySlider;

    private TextMeshProUGUI _xSensitivityValue;
    private TextMeshProUGUI _ySensitivityValue;


    void Start()
    {
        _xSensitivityValue = GameObject.Find("MouseXSensitivityValueText").GetComponent<TextMeshProUGUI>();
        _ySensitivityValue = GameObject.Find("MouseYSensitivityValueText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _xSensitivityValue.text = mouseXSensitivitySlider.value.ToString();
        _ySensitivityValue.text = mouseYSensitivitySlider.value.ToString();
    }
}
