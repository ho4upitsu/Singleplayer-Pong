using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public TextMeshProUGUI StartGameText;
    [SerializeField] public TextMeshProUGUI ScoreText;
    [SerializeField] public Rigidbody2D Rigidbody2D;

    private Vector2 direction;
    private Vector2 BallStartPosition = new Vector2(0, 0);
    private bool EndGame = false;
    private int Score;
    void Start()
    {
        Score = 0;
        StartGameText.text = "";
        transform.position = BallStartPosition;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Random rand = new Random();
        float x = ((float)rand.NextDouble() * (1 - (-1) + (-1)));
        float y = ((float)rand.NextDouble() * (x - (-x) + (-x)));
        direction = new Vector2(x,y).normalized;
        Debug.Log(x);
        Debug.Log(y);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = direction * speed;
        ResetGame();
        ScoreText.text = Score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") || col.CompareTag("RightWall"))
        {
            direction.x = -direction.x;
            if (col.CompareTag("Player"))
            {
                Score++;
            }
        }
        else if (col.CompareTag("BottomWall") || col.CompareTag("TopWall"))
        {
            direction.y = -direction.y;
        }
        else if (col.CompareTag("EndGameObj"))
        {
            EndGame = !EndGame;
        }
    }

    private void ResetGame()
    {
        if (EndGame)
        {
            StartGameText.text = "Press Space to Restart";
            if (Input.GetKey(KeyCode.Space))
            {
                EndGame = !EndGame;
                Start();
            }
        }   
    }
}
