using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//
// this is the singleton with the GameState (variables)
// create an empty object and assign the Script, only
// ONE object in the system, across all the scenes.
//

public class GameState : MonoBehaviour
{
    public static GameState instance = null;
    public int score = 0;
    public int coins = 6;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Start()
    {
    }

}
