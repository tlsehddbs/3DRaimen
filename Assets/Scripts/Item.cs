using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float lifeSpan;

    private void Update()
    {
        Destroy(this, lifeSpan);
    }
}
