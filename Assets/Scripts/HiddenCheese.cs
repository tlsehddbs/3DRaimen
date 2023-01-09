using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCheese : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cheese")
        {
            other.gameObject.SetActive(false);
            GameManager.isEatCheese = true;
        }
    }
}
