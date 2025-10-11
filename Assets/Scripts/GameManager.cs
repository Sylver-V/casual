using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static bool isRestarting = false;

    public void RestartGame()
    {
        isRestarting = true;

        foreach (GameObject obj in FindObjectsOfType<GameObject>())
        {
            if (obj.scene.name == null || obj.scene.name == "")
            {
                Destroy(obj);
            }
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

