using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitCheck : MonoBehaviour
{
    public PlayerMovement _player;
    public HealthUI _healthUI;

    public Vector3 getVelocity;

    public float damageThreshold = 10;

    [SerializeField] private BoneColliderSet _boneColliderSet;
    [HideInInspector] 
    public float damageValue = 0;

    public float DamageMultiplier;
    public float DamageValueDivider;
    public GameObject HitParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.state != GameManager.playerState.Play)  return;
        if (other.tag == "FinishPoint") return;
        
        getVelocity = _player.rb.velocity;
        damageValue = DamageMultiplier * Mathf.Abs(Mathf.Pow(0.99f, Mathf.Pow(_player.rb.velocity.magnitude, 2) / DamageValueDivider) - 1);

        if(_player.rb.velocity.magnitude > damageThreshold)
        {
            _healthUI.UpdateHealth(damageValue);
            GameManager.Hp -= damageValue;
            _boneColliderSet.PlayerStateCheck();
        }

        Vector3 hitpoint = other.ClosestPointOnBounds(transform.position);
        Instantiate(HitParticle, hitpoint, Quaternion.identity);
        var soundEffect = GameObject.Find("Player").GetComponent<AudioSource>();
        soundEffect.clip = soundEffect.GetComponent<SoundEffect>().hitEffect;
        soundEffect.volume = (damageValue / 10) + 0.4f;
        soundEffect.Play();
    } 
}
