using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
        
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //build settingsde kenarlarinda index numaralari yaziyor 
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) //next olan toplam sahne sayima esitlendiyse 0 la bastan baslasin cunku sonraki level olmadigi icin hata verir 
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex); // temas oldugunda bir sonraki leveli yukler 

    }
}
