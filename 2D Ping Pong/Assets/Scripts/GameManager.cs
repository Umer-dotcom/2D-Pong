using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] float ballPushForce;
    [SerializeField] bool pushed;
    [SerializeField] bool firstPush;
    [SerializeField] bool paused;
    [SerializeField] Text p1Score;
    [SerializeField] Text p2Score;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject pauseButton;
    private int p1Points;
    private int p2Points;
    private GameObject currentBall;
    private string lastRoundWinner;
    private bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        currentBall = Instantiate(ballPrefab, Vector2.zero, Quaternion.identity);
        p1Points = 0;
        p2Points = 0;
        paused = false;
        firstPush = true;
        gameEnded = false;
        UpdateScore();

        StartCoroutine(RalleyEnded());
    }

    private void Update()
    {
        if(gameEnded)
        {
            StartCoroutine(GameWon());
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PushBall()
    {
        Vector2 direction;
        float x;
        float y;

        if(firstPush)
        {
            x = Random.value < 0.5f ? -1.0f : 1.0f;
            firstPush = false;
        }
        else
        {
            x = lastRoundWinner == "P1" ? -1.0f : 1.0f;
        }
        y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);
        direction = new Vector2(x, y);
        currentBall.GetComponent<Rigidbody2D>().AddForce(direction * ballPushForce);
        pushed = true;
    }

    private void ResetBall()
    {
        currentBall.GetComponent<Transform>().position = Vector3.zero;  //Reset Position of ball
    }

    public void AddPoints(string winner)
    {
        if(winner == "P1")
        {
            ++p1Points;
        }
        else if(winner == "P2")
        {
            ++p2Points;
        }
        lastRoundWinner = winner;
        UpdateScore();

        if (p1Points > 10 || p2Points > 10)
        {
            gameEnded = true;
        }
        else
        {
            StartCoroutine(RalleyEnded());
        }
    }

    private void UpdateScore()
    {
        p1Score.text = p1Points.ToString();
        p2Score.text = p2Points.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        pauseButton.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        paused = false;
        Time.timeScale = 1;
    }

    IEnumerator GameWon()
    {
        yield return new WaitForSeconds(3f);

        winScreen.transform.Find("WinningStrip").Find("WinnerName").GetComponent<Text>().text = p1Points > 10 ? "Player 1 Wins!" : "Player 2 Wins!";
        winScreen.SetActive(true);
        pauseButton.SetActive(false);

        yield return null;
    }

    IEnumerator RalleyEnded()
    {
        yield return new WaitForSeconds(5f);

        ResetBall();
        pushed = false;
        currentBall.SetActive(true);

        yield return new WaitForSeconds(3f);

        PushBall();

        yield return null;
    }
}
