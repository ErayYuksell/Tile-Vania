using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float playerLives = 3;
    [SerializeField] float score = 0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        int numaGameSesions = FindObjectsOfType<GameSession>().Length;
        if (numaGameSesions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        livesText.text= playerLives.ToString();
        scoreText.text= score.ToString();
    }
    public void ProcessPlayerDeath() // elemanin canini genel kontrol saglayan fonksiyon 
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

     void TakeLife() // eleman olecek bir sey yaptiginda 1 canini aliyoruz ve o leveli tekrar yukluyoruz 
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString(); // bu texte yazdirma islemi burda olmali cunku playerMovement taki die fonksiyonu calistiginda bu da calisir 

    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject); // bu objeyi yok etmem gerekki hersey 0 dan baslasin 
    }
    public void addToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text= score.ToString();


    }
}
