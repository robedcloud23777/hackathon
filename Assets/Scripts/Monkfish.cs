using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Monkfish : MonoBehaviour
{
    public float minTimeBetweenSkills;
    public float maxTimeBetweenSkills;
    public float detectionRadius;

    public GameObject player;
    private bool playerInRange = false;

    public Image screenOverlay; // UI 캔버스에 투명한 이미지를 추가하여 화면 밝기 조절
    public float dashDistance = 5f; // 돌진 거리
    public float dashSpeed = 10f; // 돌진 속도
    public int damage = 1; // 돌진 시 플레이어에게 줄 데미지
    public bool noDamage;
    public int hp;

    private Vector3 initialPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        StartCoroutine(UseSkillRoutine());
    }

    private void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        playerInRange = distanceToPlayer <= detectionRadius;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator UseSkillRoutine()
    {
        while (true)
        {
            float timeToNextSkill = Random.Range(minTimeBetweenSkills, maxTimeBetweenSkills);
            yield return new WaitForSeconds(timeToNextSkill);

            if (playerInRange)
            {
                UseRandomSkill();
            }
        }
    }

    private void UseRandomSkill()
    {
        int skillIndex = Random.Range(0, 2); // 0 또는 1을 랜덤으로 선택
        if (skillIndex == 0)
        {
            StartCoroutine(SkillOne());
        }
        else
        {
            StartCoroutine(SkillTwo());
        }
    }

    private IEnumerator SkillOne()
    {
        Debug.Log("Skill One used!");

        // 화면을 밝게 만들기
        Color originalColor = screenOverlay.color;
        Color brightColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 완전히 밝은 색상

        float duration = 1.0f; // 밝아지는 데 걸리는 시간
        float elapsedTime = 0f;

        // 서서히 화면을 밝게 만들기
        while (elapsedTime < duration)
        {
            screenOverlay.color = Color.Lerp(originalColor, brightColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        screenOverlay.color = brightColor; // 밝게 된 상태로 유지

        // 밝은 화면 상태로 잠시 유지
        yield return new WaitForSeconds(0.2f);

        elapsedTime = 0f;

        // 서서히 화면을 원래 색으로 복원
        while (elapsedTime < duration)
        {
            screenOverlay.color = Color.Lerp(brightColor, originalColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        screenOverlay.color = originalColor; // 원래 색상으로 복원
    }

    private IEnumerator SkillTwo()
    {
        Debug.Log("Skill Two used!");
        // 플레이어를 향해 돌진했다가 제자리로 돌아오기
        Vector3 dashDirection = (player.transform.position - transform.position).normalized; // 플레이어 방향으로의 단위 벡터
        Vector3 dashPosition = transform.position + dashDirection * dashDistance; // 돌진할 위치 계산
        float elapsedTime = 0f;

        // 돌진
        while (elapsedTime < dashDistance / dashSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, dashPosition, (elapsedTime * dashSpeed) / dashDistance);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 정확히 목표 위치로 설정
        transform.position = dashPosition;

        elapsedTime = 0f;

        // 제자리로 돌아오기
        while (elapsedTime < dashDistance / dashSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, (elapsedTime * dashSpeed) / dashDistance);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 정확히 원래 위치로 설정
        transform.position = initialPosition;
    }

    private float _lastEnterTime = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time - _lastEnterTime > 1)
            {
                Player playerScript = collision.gameObject.GetComponent<Player>();
                if (playerScript != null)
                {
                    playerScript.TakeDamage(damage);
                    noDamage = true;
                    _lastEnterTime = Time.time;
                }
            }
        }
    }
}