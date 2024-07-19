using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    private Rigidbody2D rb;
    private Vector2 movement;

    public GameObject missilePrefab; // 미사일 프리팹
    public Transform firePoint; // 미사일이 발사될 위치
    public int missileCount = 5; // 한 번에 발사될 미사일 개수
    public float spreadAngle = 30f; // 미사일 퍼지는 각도
    public float missileSpeed = 10f; // 미사일 속도
    public float missileLifetime = 1f; // 미사일 수명

    public int maxHealth = 100; // 최대 체력
    private int currentHealth; // 현재 체력

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // 초기 체력을 최대 체력으로 설정
    }

    void Update()
    {
        // 입력 처리
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 샷건 미사일 발사
        if (Input.GetButtonDown("Fire1"))
        {
            FireShotgun();
        }
    }

    void FixedUpdate()
    {
        // 물리 기반 이동 처리
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void FireShotgun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - firePoint.position).normalized;

        for (int i = 0; i < missileCount; i++)
        {
            // 미사일 생성
            GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

            // 퍼지는 각도 계산
            float angle = spreadAngle * (i / (float)(missileCount - 1) - 0.5f);
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            Vector2 spreadDirection = Quaternion.Euler(0, 0, angle) * direction;

            // 미사일 방향 설정
            missile.transform.rotation = Quaternion.LookRotation(Vector3.forward, spreadDirection);

            // 미사일 이동
            Rigidbody2D rbMissile = missile.GetComponent<Rigidbody2D>();
            rbMissile.velocity = spreadDirection * missileSpeed;

            // 미사일 수명 설정
            Destroy(missile, missileLifetime);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // 플레이어 죽음 처리
        gameObject.SetActive(false);
    }
}