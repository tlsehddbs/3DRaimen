using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaimenExplain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI explaintext;
    [SerializeField] private new string name;
    [SerializeField] private string Bonus;
    [SerializeField] private string Skill;
    [SerializeField] private string HowtoGet;
    // Start is called before the first frame update
    
    private void Start()
    {
       
    }

    public void UpdateExplain()
    {
        explaintext.text = name + "\n" + Bonus +"\n"+ Skill +"\n"+ HowtoGet;
    }
}
