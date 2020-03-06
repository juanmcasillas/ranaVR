using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasButtonActions : MonoBehaviour
{
    public void Button_Play_Clicked()
    {
        SceneManager.LoadScene("Game");
    }

    public void Button_Quit_Clicked()
    {
#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
