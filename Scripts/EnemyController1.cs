using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class EnemyController1 : MonoBehaviour
{
    public float speed = 2.0f;      // Tốc độ di chuyển của đối tượng
    public float changeTime = 3.0f; // Thời gian để chuyển hướng di chuyển

    Rigidbody2D rigidbody2d;
    float timer;
    int directionIndex = 0;         // Dùng để xác định hướng hiện tại (0 = lên, 1 = phải, 2 = xuống, 3 = trái)
    Vector2[] directions = new Vector2[4]; // Mảng chứa các hướng di chuyển

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>(); // Lấy thành phần Rigidbody2D của đối tượng

        // Định nghĩa bốn hướng di chuyển: lên, phải, xuống, trái
        directions[0] = Vector2.up;    // Hướng lên (trục Y)
        directions[1] = Vector2.right; // Hướng phải (trục X)
        directions[2] = Vector2.down;  // Hướng xuống (trục Y)
        directions[3] = Vector2.left;  // Hướng trái (trục X)

        // Khởi tạo bộ đếm thời gian bằng giá trị changeTime
        timer = changeTime;
    }

    void Update()
    {
        // Đếm ngược timer
        timer -= Time.deltaTime;

        // Khi timer về 0, thay đổi hướng di chuyển
        if (timer <= 0)
        {
            // Tăng chỉ số hướng để chuyển sang hướng tiếp theo trong mảng
            directionIndex = (directionIndex + 1) % 4; // Chu kỳ giữa 0, 1, 2, 3
            timer = changeTime; // Reset lại timer
        }
    }

    void FixedUpdate()
    {
        // Di chuyển đối tượng theo hướng hiện tại
        Vector2 position = rigidbody2d.position;
        position += directions[directionIndex] * speed * Time.deltaTime;

        // Cập nhật vị trí của đối tượng bằng Rigidbody2D
        rigidbody2d.MovePosition(position);
    }

// Update is called once per frame
private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

}
