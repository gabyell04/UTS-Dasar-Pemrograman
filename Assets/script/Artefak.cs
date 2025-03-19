using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Artefak : MonoBehaviour
{

    public TextMeshProUGUI winText; 
    public player playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Awalnya teks tidak ditampilkan
        if (winText != null)
        {
            winText.text = "";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ketika objek ini bertabrakan dengan objek lain
        if (collision.gameObject.CompareTag ("Player"))
        { 
            if (winText != null && playerScript != null)
            {
                // Ambil skor dari player dan tampilkan pesan kemenangan
                winText.text = "YOU WIN!\nFinal Score: " + playerScript.GetTotalScore().ToString();
            }
            Debug.Log("Pemain menang dengan skor: " + playerScript.GetTotalScore());
            Time.timeScale = 0; // Menghentikan permainan
        }
        
    }
}


