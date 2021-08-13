using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController gm;

    public GameObject player, finish;
    public Image lifebar;

    public CinemachineVirtualCamera cam;

    public TextMeshProUGUI gameEnd;

    public bool hasGameFinished = false;

    void Awake()
    {
        if (gm == null) // If there is no instance already
        {
            gm = this;
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
        }
        else if (gm != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        gameEnd.gameObject.SetActive(true);
        gameEnd.text = "Game Over! :(";
        gameEnd.color = Color.red;
        hasGameFinished = true;
    }
}
