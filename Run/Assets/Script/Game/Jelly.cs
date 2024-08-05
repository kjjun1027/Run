using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int scoreValue = 10; // Á©¸®¸¦ ¸ÔÀ» ¶§ È¹µæÇÏ´Â Á¡¼ö

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Á¡¼ö Áõ°¡
            ScoreManager.Instance.AddScore(scoreValue);

            // Á©¸® Á¦°Å
            Destroy(gameObject);
        }
    }
}
