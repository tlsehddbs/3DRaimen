using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPointCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bone") && GameManager.startingCount)
        {
            GameManager.state = GameManager.playerState.Finish;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
