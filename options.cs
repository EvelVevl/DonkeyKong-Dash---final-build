using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.UI;

public class options : MonoBehaviour
{

    public void LevelOne()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelTwo()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
