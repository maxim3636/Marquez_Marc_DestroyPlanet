using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    private int score = 0;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioClip explosionSound;
    public AudioClip eliminationSound;
    public AudioClip victorySound;
    public AudioClip loseSound;
    private bool gameOver = false;
    public Canvas final;
    
    public TMP_Text lbl_Score;
    public TMP_Text lbl_FinalScore;
    public TMP_Text lbl_BestScore;
    public TMP_Text lbl_Lives;
    public TMP_Text lbl_Result;
    // Start is called before the first frame update
    void Start()
    {
        int Scores = PlayerPrefs.GetInt("Score", 0);
        gameOver = false;
        final.gameObject.SetActive(false);
        SpawnManager.gameOver1 = true;
        lives = 3;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            check();
        }
        else
        {
            
        }
    }
    public void AddScore()
    {
        // Play elimination sound
        audioSource1.clip = eliminationSound;
        audioSource1.Play();
        score++;
        lbl_Score.text = "Score: " + score;
    }
    
    public void TakeDamage()
    {
        // Play explosion sound
        audioSource2.clip = explosionSound;
        audioSource2.Play();
        if (lives > 0)
        {
            lives--;
        }
        lbl_Lives.text = "Lives: " + lives;
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(1);
        Debug.Log("botó restart");
        final.gameObject.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        
    }

    void check()
    {
        if (!gameOver)
        {
            final.gameObject.SetActive(true);
            SpawnManager.gameOver1 = false;

            if (score > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", score);
                lbl_FinalScore.text = "Score: " + score;
                lbl_BestScore.text = "Best Score: " + PlayerPrefs.GetInt("Score");
                lbl_Result.text = "VICTORY";
                audioSource3.clip = victorySound;
                audioSource3.Play();
                Debug.Log("Victory");
            }
            else if (score <= PlayerPrefs.GetInt("Score"))
            {
                lbl_FinalScore.text = "Score: " + score;
                lbl_BestScore.text = "Best Score: " + PlayerPrefs.GetInt("Score");
                lbl_Result.text = "GAME OVER";
                audioSource3.clip = loseSound;
                audioSource3.Play();
                Debug.Log("Lose");
            }

            
            gameOver = true;
        }
    }

    
}
