using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public GameObject MenuTap;

    public void Apply()
    {
        gameObject.SetActive(false);
    }

    public void Back()
    {
        gameObject.SetActive(false);
        MenuTap.SetActive(true);
    }
}
