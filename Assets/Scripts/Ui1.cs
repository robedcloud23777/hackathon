using System.Collections;
using UnityEngine;
using TMPro; // TextMeshPro ���ӽ����̽��� �߰��մϴ�.
using UnityEngine.UI;

public class Ui1 : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // TextMeshProUGUI ������Ʈ�� �����մϴ�.
    public Canvas canvas; // Canvas ������Ʈ�� �����մϴ�.
    public float delayBetweenMessages = 2f; // ���� ���� �ð� ����
    public string[] messages; // ����� �����

    private void Start()
    {
        if (textMeshPro != null && canvas != null && messages.Length > 0)
        {
            StartCoroutine(DisplayMessages());
        }
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            textMeshPro.text = message; // ���� ������ �����մϴ�.
            yield return new WaitForSeconds(delayBetweenMessages); // ���� ���� ���� �ð�
        }

        textMeshPro.text = ""; // ��� �޽��� ��� �� �ؽ�Ʈ�� ����ϴ�.
    }
}
