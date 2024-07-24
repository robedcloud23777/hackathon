using System.Collections;
using UnityEngine;
using TMPro; // TextMeshPro ���ӽ����̽��� �߰��մϴ�.
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // TextMeshProUGUI ������Ʈ�� �����մϴ�.
    public Canvas canvas; // Canvas ������Ʈ�� �����մϴ�.
    public Canvas canvas2; // Canvas ������Ʈ�� �����մϴ�.
    public float delayBetweenMessages = 2f; // ���� ���� �ð� ����
    public string[] messages; // ����� �����
    public Image canvasImage;
    public Player player;
    public Image[] heart;
    public TextMeshProUGUI Dna;
    public Monkfish monk;
    public Image[] heart2;
    public Monkfish Monk;

    public float timeLimit = 180f;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        canvas2.enabled = false;
        if (textMeshPro != null && canvas != null && messages.Length > 0)
        {
            StartCoroutine(DisplayMessages());
        }
        StartCoroutine(TimerCountdown());
    }

    private void Update()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].enabled = i < player.hp;
        }
        if(player.DNA >= 1)
        {
            Dna.text = "DNA : 3 / 3";
        }
        for (int i = 0; i < heart2.Length; i++)
        {
            heart2[i].enabled = i < monk.hp/5;
        }
    }

    private IEnumerator TimerCountdown()
    {
        float remainingTime = timeLimit;

        while (remainingTime > 0)
        {
            // ���� �ð��� ��:��:�� �������� ��ȯ
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            // �ؽ�Ʈ ������Ʈ
            timerText.text = $"{minutes:D2}:{seconds:D2}";

            yield return new WaitForSeconds(1f); // 1�� ���
            remainingTime -= 1f; // ���� �ð� ����
        }

        // Ÿ�̸� ���� �� ������ �۾�
        timerText.text = "00:00"; // Ÿ�̸Ӱ� 0�� �Ǿ��� �� ǥ��
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            textMeshPro.text = message; // ���� ������ �����մϴ�.
            yield return new WaitForSeconds(delayBetweenMessages); // ���� ���� ���� �ð�
        }

        textMeshPro.text = ""; // ��� �޽��� ��� �� �ؽ�Ʈ�� ����ϴ�.
        canvas2.enabled = true;
        canvas.enabled = false; // Canvas�� ��Ȱ��ȭ�մϴ�.
    }
}
