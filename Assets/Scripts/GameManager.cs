using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text hiscoreText;
    [SerializeField] private float initialScrollSpeed; // Velocidad inicial seteable

    private float score; // Puntaje
    private float timer;
    private float scrollSpeed;

    public static GameManager Instance {get; private set;}

    //public TextMeshProGUI scoreText;
    //public TextMeshProGUI hiscore; //Hiscore


    private void Awake() {
        if(Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateSpeed();
        UpdateHiscore();
    }
    public void ShowGameOverScreen(){
        gameOverScreen.SetActive(true);
        UpdateHiscore();
    }

    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    
    // Actualizamos muestro Score
    private void UpdateScore(){
        int scorePerSeconds = 10;

        timer += Time.deltaTime;
        score=(float)(timer * scorePerSeconds);
        //scoreText.text=string.Format("{0:000000}", score);
        scoreText.text = Mathf.FloorToInt(score).ToString("D4");
    }

    public float GetScrollSpeed(){
        return scrollSpeed;
    }

    private void UpdateSpeed(){
        float speedDivider = 10f;
        scrollSpeed=initialScrollSpeed + timer / speedDivider;
    }

    private void UpdateHiscore() {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if(score > hiscore) {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }
        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D4");
    }
}