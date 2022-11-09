using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject headSnakePrefab;
    public GameObject pnMenuStart;
    public GameObject spawnerFood;
    public GameObject pnMenuGameOver;
    public GameObject pnMenuScore;
    public SpawnFood spawnFood;
    public Text scoreGame;
    public Text scoreGameOver;

    private bool gamePlay;
    private int score = 0;
    // Start is called before the first frame update
    void Start() {
        pnMenuScore.SetActive(false);
        pnMenuGameOver.SetActive(false);
        spawnerFood.SetActive(false);
        pnMenuStart.SetActive(true);
        gamePlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gamePlay == false) {
            StartGame();

        }
        scoreGame.text = "SCORE: " + score.ToString();
    }

    public void StartGame() {
        pnMenuScore.SetActive(true);
        score = 0;
        gamePlay = true;
        headSnakePrefab.SetActive(true);
        pnMenuGameOver.SetActive(false);
        pnMenuStart.SetActive(false);
        spawnerFood.SetActive(true);
        Instantiate(headSnakePrefab, new Vector2(0f, 0f), Quaternion.identity);
    }
    public void GameOver() {
        pnMenuScore.SetActive(false);
        scoreGameOver.text = "SCORE: " + score.ToString();
        pnMenuGameOver.SetActive(true);
        spawnerFood.SetActive(false);
        Invoke("RestartGame", 3);

    }
    public void RestartGame() {
        SceneManager.LoadScene("Main");
    }
    public void IncScore() {
        score += 10;
    }
}
