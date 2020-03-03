using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStatus : MonoBehaviour
{
    public static GameStatus instance = null;
    public int score = 0;
    private TextMeshProUGUI ui_text;

    private void Awake()
    {
        if (instance == null) { 
            instance = this;
            instance.ui_text = GameObject.Find("score_text").GetComponent<TextMeshProUGUI>();
        }
        else if (instance != this)
            Destroy(gameObject);
    }



    public static int AddScore(int score)
    {
        instance.score += score;

        //Debug.Log("Score: " + instance.score);
        //TextMeshProUGUI ui_text = GameObject.Find(score_text_label).GetComponent<TextMeshProUGUI>();
        //Debug.Log("Obj: " + ui_text);

        //Debug.Log("Score: " + ui_text.text + "|" + instance.score);
        //ui_text.text = "Score: " + instance.score;
        instance.ui_text.text = instance.score.ToString();
        return instance.score;
    }

    public static int  GetScore()
    {
        return instance.score;
    }
}
