using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float jumpForce;
    [SerializeField] GameObject loseScreenUI;
    [SerializeField] Text scoreUI;
    [SerializeField] Text hiScoreUI;
    [SerializeField] int score;
    [SerializeField] int hiScore;
    string HISCORE = "HISCORE";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.singleton.PlaySound(0);
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void PlayerLose()
    {
        AudioManager.singleton.PlaySound(1);
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        hiScore = score;
        hiScoreUI.text = "HiScore: " + hiScore.ToString();
        loseScreenUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void AddScore()
    {
        AudioManager.singleton.PlaySound(2);
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            PlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            AddScore();
        }
    }
}
