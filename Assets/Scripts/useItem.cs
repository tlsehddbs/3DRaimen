using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItem : MonoBehaviour
{
    private PlayerMovement _player;

    [Header("Particles")]
    public GameObject _longParticle;
    public GameObject _shortParticle;
    [Space(10)]

    [Tooltip("For ItemUsageSlider")]
    public ItemUsageUI _itemUsageUI;

    [Header("Jump Items")]
    public int shortJump;
    static public bool useShortJump = false;


    [SerializeField] private GameObject doublejump;
    public int longJump;
    [HideInInspector]
    static public float longJumpRemainAmount = 1f;

    private void Awake()
    {
        _player = GetComponent<PlayerMovement>();
        useShortJump = false;
        longJumpRemainAmount = 1f;
    }

    void Update()
    {
        if (GameManager.isPaused ||
            GameManager.state != GameManager.playerState.Play) return;

        if (Input.GetKeyDown(KeyCode.X) && !useShortJump)
        {
            _player.rb.AddForce(Vector3.up * shortJump, ForceMode.Impulse);
            _player.rb.AddForce(_player._getCameraController.lookDirection * shortJump, ForceMode.Impulse);
            jumpItemParticleEffect(_shortParticle, new Vector3(-90f, 0f, 0f));
            useShortJump = true;
            doublejump.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.isPaused ||
            GameManager.state != GameManager.playerState.Play) return;

        if (Input.GetKey(KeyCode.Z) && longJumpRemainAmount > 0)
        {
            _player.rb.AddForce(Vector3.up * longJump, ForceMode.Acceleration);
            _player.rb.AddForce(_player._getCameraController.lookDirection * longJump, ForceMode.Acceleration);
            jumpItemParticleEffect(_longParticle, new Vector3(0f, 0f, 0f));
            longJumpRemainAmount -= Time.deltaTime * 0.2f;
            _itemUsageUI.UpdateRemains(longJumpRemainAmount);
        }
    }

    private void jumpItemParticleEffect(GameObject particle, Vector3 rotate)
    {
        Instantiate(particle, _player.transform.position, Quaternion.Euler(rotate));
    }
}
