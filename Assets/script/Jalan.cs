using UnityEngine;

public class Jalan : MonoBehaviour
{
    public float speed = 2f; // Kecepatan pergerakan objek
    public float leftBoundary = -5f; // Batas kiri area permainan
    public float rightBoundary = 5f; // Batas kanan area permainan

    private bool movingRight = true; // Status pergerakan (ke kanan atau ke kiri)

    void Start()
    {
        // Menyesuaikan boundary sesuai ukuran ground
        GameObject ground = GameObject.FindWithTag("Tanah");
        if (ground != null)
        {
            Bounds groundBounds = ground.GetComponent<Renderer>().bounds;
            leftBoundary = groundBounds.min.x;
            rightBoundary = groundBounds.max.x;
        }
    }

    void Update()
    {
        transform.position += (movingRight ? Vector3.right : Vector3.left) * speed * Time.deltaTime;

        if (transform.position.x >= rightBoundary || transform.position.x <= leftBoundary)
        {
            movingRight = !movingRight;
        }
    }
}
