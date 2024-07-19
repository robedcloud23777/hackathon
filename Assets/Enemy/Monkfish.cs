using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Monkfish : MonoBehaviour
{
    public float minTimeBetweenSkills = 2f;
    public float maxTimeBetweenSkills = 5f;
    public float detectionRadius = 5f;

    public GameObject player;
    private bool playerInRange = false;

    public Image screenOverlay; // UI 캔버스에 투명한 이미지를 추가하여 화면 밝기 조절
    public float dashDistance = 5f; // 돌진 거리
    public float dashSpeed = 10f; // 돌진 속도
    public int damage = 20; // 돌진 시 플레이어에게 줄 데미지

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
        screenOverlay.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 화면을 밝게 설정
        yield return new WaitForSeconds(1.5f); // 1.5초 동안 유지
        screenOverlay.color = originalColor; // 원래 색으로 복원
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

        // 플레이어에게 데미지를 줍니다.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }

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
}