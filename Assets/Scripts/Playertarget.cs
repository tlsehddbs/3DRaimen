using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertarget : MonoBehaviour
{
    public GameObject target;

    [Range(0.0f, 0.5f)]
    public float targetFollowingSpeed = 0.1f;


    void FixedUpdate()
    {
        if (GameManager.isPaused)   return;
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z), targetFollowingSpeed);
    }
}
