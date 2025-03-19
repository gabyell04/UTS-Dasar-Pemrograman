using UnityEngine;

public class camera : MonoBehaviour
{

    public Transform player; 
    public Vector3 offset; 
    public float smoothSpeed=0.125f;
    private Vector3 currentOffset;

    void Start()
    {
        // Atur offset awal
        currentOffset = offset;
    }

    void Update()
    {
        // Ubah sudut pandang kamera berdasarkan tombol yang ditekan
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            // Rotasi 90 derajat ke kiri
            currentOffset = Quaternion.Euler(0, -90, 0) * currentOffset;
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
            // Rotasi 90 derajat ke kanan
            currentOffset = Quaternion.Euler(0, 90, 0) * currentOffset;
        } 
    }


    void LateUpdate()
    {
        if (player != null)
        {
            // Tentukan posisi kamera berdasarkan offset saat ini
            Vector3 desiredPosition = player.position + currentOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // Kamera tetap menghadap player
            transform.LookAt(player);
        }
    }

}









