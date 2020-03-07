using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Over_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("score_text").GetComponent<TextMeshProUGUI>().text = GameState.instance.score.ToString();
    }

}
