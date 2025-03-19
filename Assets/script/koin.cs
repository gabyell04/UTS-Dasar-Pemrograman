using UnityEngine;

public class koin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int coinValue; // Nilai poin untuk koin ini
    public float rotationSpeed = 100f; // Kecepatan rotasi koin

    private void Update()
    {
        // Membuat koin berotasi di tempat
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ambil script player dari objek pemain
            player playerScript = other.GetComponent<player>();

            if (playerScript != null) 
            {
                // Tambahkan nilai koin ke skor pemain
                playerScript.AddScore(coinValue);
            }

            // Hancurkan koin setelah dikumpulkan
            Destroy(gameObject);
        }
    }


}


