using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public float cameraSmoothingFactor = 1;
    public float lookUpMax = 40;
    public float lookUpMin = -30;
    [Space(10)]

    public Transform playerTransform;
    public Transform targetCamera;

    private Quaternion cameraRotation;
    private RaycastHit hit;
    private Vector3 cameraOffset;

    [SerializeField]
    private Transform CameraHandler;

    [HideInInspector]
    public Vector3 lookDirection;
    [Space(10)]

    [Header("Mouse Snesitivity Setting")]
    public MouseSensitivity _ms;
    [Range(0.1f, 1.0f)]
    public float mouseSensitivityMultiplier;
    [Space(10)]

    [Header("Camera Shake Setting")]
    public float shakeAmount = 1.0f;
    [Range(0.1f, 1.0f)]
    public float shakeAmountMultiplier = 0.3f;
    [HideInInspector]
    public Vector3 originalPosition;


    private void Awake()
    {
        cameraRotation = transform.localRotation;
        cameraOffset = targetCamera.localPosition;
        originalPosition = this.gameObject.transform.localPosition;
    }

    void Update()
    {
        if (GameManager.isPaused || 
            GameManager.state != GameManager.playerState.Play)    return;

        LookForward();

        cameraRotation.x += Input.GetAxis("Mouse Y") * cameraSmoothingFactor * -1 * _ms.mouseXSensitivitySlider.value * mouseSensitivityMultiplier;
        cameraRotation.y += Input.GetAxis("Mouse X") * cameraSmoothingFactor * _ms.mouseYSensitivitySlider.value * mouseSensitivityMultiplier;

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, lookUpMin, lookUpMax);

        transform.localRotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, cameraRotation.z);

        int layerMask = 1 << LayerMask.NameToLayer("JointBone");

        if (Physics.Linecast(playerTransform.position, targetCamera.position, out hit, ~layerMask))
        {
            targetCamera.position = hit.point;
        }
        else
        {
            targetCamera.localPosition = Vector3.Lerp(targetCamera.localPosition, cameraOffset, Time.deltaTime);
        }
    }

    void LookForward()
    {
        lookDirection = new Vector3(CameraHandler.forward.x, 0f, CameraHandler.forward.z).normalized;
    }
}