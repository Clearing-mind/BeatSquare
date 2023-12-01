using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadController3 : MonoBehaviour
{
    public float horizontalForce = 20f; // 水平弹射力

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 检测到与角色的碰撞
        {
            // 获取碰撞点在世界坐标中的位置
            Vector2 collisionPoint = collision.GetContact(0).point;

            // 将碰撞点转换为相对于板子的本地坐标
            Vector2 localCollisionPoint = transform.InverseTransformPoint(collisionPoint);

            // 如果碰撞点在板子的下侧（根据你的描述，即板子的上侧），则施加水平向右的力
            if (localCollisionPoint.y < 0f)
            {
                // 施加水平向右的力
                transform.Translate(new Vector2(horizontalForce * Time.deltaTime, 0));
            }
        }
    }
}
