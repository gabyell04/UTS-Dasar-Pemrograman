using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using TMPro;

public class player : MonoBehaviour
{
    //konfigurasi gerakan
    public float BesarGaya = 15f;
    public float kecepatan = 5f;
    public Transform cameraTransform; // Transform kamera untuk menentukan arah
    private Rigidbody rb;
    private bool DiTanah;

    public float groundLimit = -5f; // Batas bawah ground
    //public GameObject gameOverUI; // UI Game Over (misalnya Text atau Canvas)

    //game point
    private int totalScore = 0;
    public int GetTotalScore()
    {
        return totalScore; // Mengembalikan skor total
    }


    [Header("UI Elements")]
    public TextMeshProUGUI scoreText; // Text UI untuk menampilkan skor
    public GameObject gameOverUI; // Panel game over
    public TextMeshProUGUI finalScoreText; // Text UI untuk skor akhir

    
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //mengunci objek player agar tetap tegak
        rb.freezeRotation = true;
        gameOverUI?.SetActive( false );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tanah"))
        {
            DiTanah = true;
        }

        if (collision.gameObject.CompareTag("balok")) // Jika bertabrakan dengan objek ber-tag "balok"
        {
            TriggerGameOver();
        }
    }

    //mendetek game over
    private void TriggerGameOver()
    {
        // Aktifkan UI Game Over dan hentikan waktu
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        //skor akhir ditampilkan
        ShowGameOverScreen();

        Time.timeScale = 0; // Menghentikan permainan
        Debug.Log("Game Over!");

    }

    // Update is called once per frame
    void Update()
    {
        //lompat
        if (Input.GetKeyDown(KeyCode.Space) && DiTanah)
        {
            rb.AddForce(Vector3.up * BesarGaya, ForceMode.Impulse);
            DiTanah = false;
        }

        //menambahkan gerak selain lompat

        // Gerakan sesuai dengan arah pandang kamera
        float horizontal = Input.GetAxis("Horizontal"); // Input A/D
        float vertical = Input.GetAxis("Vertical"); // Input W/S
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Sudut arah relatif kamera
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;

            // Menggerakkan player ke arah yang sesuai
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.MovePosition(transform.position + moveDirection.normalized * kecepatan * Time.deltaTime);
        }
        //pendetek keluar tanah
        if (transform.position.y < groundLimit) // Jika posisi Y lebih rendah dari batas
        {
            TriggerGameOver();
        }
    }


    public void AddScore(int score)
    {
        totalScore += score;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore.ToString();

        }
    }

    public void ShowGameOverScreen()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        if(finalScoreText != null) 
        {
          finalScoreText.text = "Final Score: " + totalScore.ToString();
        }
    }
}
