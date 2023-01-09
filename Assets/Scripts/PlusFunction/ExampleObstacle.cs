using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleObstacle : MonoBehaviour
{
    [SerializeField]private GameObject Obstacle;
    private bool ismovel = false;
    private bool isFall = false;
    [SerializeField]private float speed = 0;
    private Vector3 expos;
    
    
    [Header("최대 좌표 값")]
    [SerializeField] float X = 0;
    [SerializeField] float Z = 0;
    [SerializeField] float Y = 0;
    public enum  ObstacleTag
    {
        Spawn, Throw, Boom
    }

    public ObstacleTag obtag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bone") && obtag == ObstacleTag.Throw)
        {
            ismovel = true;
        }
        else if (other.CompareTag("bone") && obtag == ObstacleTag.Spawn)
        {
            Obstacle.SetActive(true);
            Obstacle.gameObject.AddComponent<Rigidbody>();
            isFall = true;
        }
        else if (other.CompareTag("bone") && obtag == ObstacleTag.Boom)
        {
            Obstacle.SetActive(true);
            Obstacle.gameObject.AddComponent<Rigidbody>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        expos = Obstacle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
        {
            var velo = Obstacle.GetComponent<Rigidbody>().velocity;
            velo.y -= Y;
            Obstacle.GetComponent<Rigidbody>().velocity = velo;
        }
        if (ismovel && transform.position.z <Z)
        {
            var pos = Obstacle.transform.position;
            pos.z += speed * Time.deltaTime;
            Obstacle.transform.position = pos;
        }
        else if (Obstacle.transform.position.z >= Z && ismovel)
        {
            ismovel = false;
            Obstacle.transform.position = expos;
        }
    }
}
