using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public CameraController _getCameraController;

    [HideInInspector]
    public Rigidbody rb;

    public int JumpPower;
    [HideInInspector]
    public float duration = 0;
    public int durationLimit;

    [HideInInspector]
    public float maxheight = 0;

    [HideInInspector]
    public Vector3 _velocity;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.isPaused ||
            GameManager.state != GameManager.playerState.Play)  return;

        Jump();
        if (this.gameObject.transform.position.y > maxheight)
        {
            maxheight = this.gameObject.transform.position.y;
        }
    }

    void Jump()
    {
        // duration 초기화
        // 최대 높이를 뛸 때 마다 갱신하기 위해 초기화
        if (Input.GetKeyDown(KeyCode.Space))
        {
            duration = 0;
        }

        if (Input.GetKey(KeyCode.Space)/* && duration < durationLimit*/)
        {
            if (rb.velocity.magnitude <= 0.1f   /* 0이 되지 않았을 상황을 대비하여 0.1 보다 작을 때로 설정함*/)
            {
                maxheight = this.gameObject.transform.position.y;
                if (duration < durationLimit)
                {
                    _getCameraController.shakeAmount = (duration / durationLimit) * _getCameraController.shakeAmountMultiplier;
                    duration += Time.deltaTime;
                }
                _getCameraController.originalPosition = this.gameObject.transform.position;
                _getCameraController.transform.localPosition = _getCameraController.originalPosition + Random.insideUnitSphere * _getCameraController.shakeAmount;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y <= 0.1f  /* 0이 되지 않았을 상황을 대비하여 0.1 보다 작을 때로 설정함*/)
        {
            rb.AddForce(_getCameraController.lookDirection * (JumpPower / 2) * (duration > durationLimit ? durationLimit : duration), ForceMode.Impulse);
            rb.AddForce(Vector3.up * JumpPower * (duration > durationLimit ? durationLimit : duration), ForceMode.Impulse);
        }
    }
}
