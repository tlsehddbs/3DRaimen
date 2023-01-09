using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Sprite[] HpState = new Sprite[2];

    void Start()
    {
        
    }

    public void UpdateHealth(float damage)
    {
        if (GameManager.Hp < 70f && GameManager.Hp > 40f)
        {
            gameObject.GetComponent<Image>().sprite = HpState[0];
        }
        else if (GameManager.Hp < 40f )
        {
            gameObject.GetComponent<Image>().sprite = HpState[1];
        }
        
    }
}
