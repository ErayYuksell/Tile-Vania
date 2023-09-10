using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float playerLives = 3;
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
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject); // bu objeyi yok etmem gerekki hersey 0 dan baslasin 
    }
}
