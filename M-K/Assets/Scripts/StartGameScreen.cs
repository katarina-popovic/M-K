using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StartGameScreen : MonoBehaviour
{
    public void RestartButton1() {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame1() {
        //Application.Quit();
        //SceneManager.LoadScene("SampleScene");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
