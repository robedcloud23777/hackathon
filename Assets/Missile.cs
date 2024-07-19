using UnityEngine;

public class Missile : MonoBehaviour
{
    public int damage = 10; // 미사일이 줄 데미지

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 플레이어인지 확인
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // 플레이어에게 데미지를 줍니다.
            player.TakeDamage(damage);
        }

        // 충돌 시 미사일 파괴
        Destroy(gameObject);
    }
}