using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggUI : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EGG")
        {
            other.gameObject.SetActive(false);
            GameManager.isEatEgg = true;
        }
    }
}
