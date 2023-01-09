using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticleGen : MonoBehaviour
{
    private PlayerHitCheck _playerHitCheck;

    public GameObject effect0, effect1;

    void Start()
    {
        _playerHitCheck = GameObject.Find("HitChecker").GetComponent<PlayerHitCheck>();

        var particleGenerateAmount = (int)_playerHitCheck.damageValue / 3;
        var particleGenerateScale = (int)_playerHitCheck.damageValue / 6;

        for(int i = 0; i < particleGenerateAmount; i++)
        {
            var pos = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
            Instantiate(effect0, pos + _playerHitCheck.transform.position, Quaternion.identity);
            Instantiate(effect1, pos + _playerHitCheck.transform.position, Quaternion.identity);
            var scale = Random.Range(0.1f, 0.8f);
            effect0.transform.localScale = new Vector3(scale, scale, scale) * particleGenerateScale;
            effect1.transform.localScale = new Vector3(scale, scale, scale) * particleGenerateScale;
        }
    }
}
