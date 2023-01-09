using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scenename;


    public void ChagneScene()
    {
        // HiddenEnding
        if(GameManager.isEatEgg && GameManager.isEatCheese)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            LoadingSceneController.LoadScene(scenename);
        }
    }
}
