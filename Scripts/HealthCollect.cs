using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    /*OnTriggerEnter2D là một hàm Unity cụ thể được gọi trong khung hình đầu tiên khi hệ thống vật lý phát
     hiện một GameObject có thành phần Rigidbody chạm vào bộ va chạm GameObject đóng vai trò là bộ kích hoạt.
    Tham số (khác) sẽ chứa tham chiếu đến thành phần va chạm vừa nhập vào trình kích hoạt.*/
    void OnTriggerEnter2D(Collider2D other)
    {
        //Thao tác này sẽ in tham chiếu đến bộ va chạm trong cửa sổ Console , kèm theo một chuỗi văn bản để giúp bạn hiểu thông báo dễ hơn.
        /* Debug.Log("Object that entered the trigger: " + other);*/
        PlayerController controller = other.GetComponent<PlayerController>();

        // sẽ chỉ được thực hiện nếu biến điều khiển chứa tham chiếu đến tập lệnh PlayerController
        if (controller != null && controller.health < controller.maxHealth)
        {
           
                /*(1) gán giá trị 1 cho tham số của hàm ChangeHealth
                    * gọi một hàm Unity tích hợp sẵn để hủy bất kỳ thứ gì bạn truyền cho nó (cung cấp cho nó) dưới dạng tham số. Trong trường hợp này
                    * ,bạn đã truyền tham chiếu đến GameObject mà tập lệnh này được đính kèm: CollectibleHealth GameObject*/
                controller.ChangeHealth(1);
                Destroy(gameObject);

            }
               
        }
    }

