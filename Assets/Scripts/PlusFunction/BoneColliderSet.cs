using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoneColliderSet : MonoBehaviour
{
    public float JointSpring;

    public float JointDamper;

    public GameObject[] Bones = new GameObject[8];
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!");
        int Num = 0;
        var obj = GameObject.FindGameObjectsWithTag("bone");
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].name.Contains("Bone"))
            {
                Bones[Num] = obj[i];
                Num++;
            }
        }   
    }


    public void PlayerStateCheck()
    {
        if ( GameManager.Hp < 100f && GameManager.Hp > 70f)
        {
            collideradd(3);
            collideradd(7);
        }
        else if ( GameManager.Hp < 70f)
        {
            collideradd(0);
            collideradd(4);
            collideradd(2);
            collideradd(6);
        }
        else if (GameManager.Hp > 40f)
        {
            collideradd(1);
            collideradd(5);
        }
    }

    private void collideradd(int a)
    {
        if (!Bones[a].GetComponent<BoxCollider>())
        {
            Bones[a].AddComponent<BoxCollider>();
            var obj = Bones[a].GetComponent<BoxCollider>();
            if (obj.gameObject.name.Contains("RightBone"))
            {
                obj.size = new Vector3(0.5f, 0.6f, 2);
                obj.center = new Vector3(0.3f, 0,0);
            }
            else
            {
                obj.size = new Vector3(2, 0.6f, 0.5f);
                obj.center = new Vector3(0, 0, 0.3f);
            }
        }
        return;
    }
    
    
    //타이틀 씬
    //엔딩 팝업//메뉴 씬

    // Update is called once per frame
    void Update()
    {
        
    }
}
