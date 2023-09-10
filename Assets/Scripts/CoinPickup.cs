using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    //bool wasCollected = false;
    private void OnTriggerEnter2D(Collider2D collision) //yorum satirindakiler coin topladiginda scora 2 kere ekleme yapmasin diye sonradan yazdik 
    {
        if (collision.tag == "Player")
        {
            //wasCollected = true;
            FindObjectOfType<GameSession>().addToScore(pointsForCoinPickup); // her bir coin playerla temas ettiginde bu fonksiyon calisir ve score artar
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position); // cameranin konumunda ses calisacak 
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
