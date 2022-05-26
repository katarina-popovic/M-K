using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameOverScreen : MonoBehaviour
{
    public void RestartButton() {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame() {
        //Application.Quit();
        //SceneManager.LoadScene("SampleScene");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
