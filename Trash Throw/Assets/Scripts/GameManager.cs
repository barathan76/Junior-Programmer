using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private int health = 10;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject mainUI;
    [SerializeField] private Button restartButton;
    public bool isGameOver = true;
    void Start()
    {
        healthText.text = "Health:" + health;
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ReduceHealth()
    {
        health--;
        if (health == 0)
        {
            GameOver();
        }
        else
        {
            healthText.text = "Health:" + health;
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score:" + score;
    }
    private void GameOver()
    {
        isGameOver = true;
        gameUI.SetActive(false);
        restartButton.gameObject.SetActive(true);

    }
    public void StartGame()
    {
        gameUI.SetActive(true);
        isGameOver = false;
        mainUI.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
