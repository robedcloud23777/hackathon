using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject target; // ī�޶� ���� ���
    public float moveSpeed;   // ī�޶��� �ӵ�

    private void Update()
    {
        if (target != null) // Ÿ���� ������
        {
            // Ÿ���� ��ġ�� ī�޶��� x�� y ��ġ�� �����ϰ�, ī�޶��� z ��ġ�� �����մϴ�.
            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

            // Lerp�� ����Ͽ� ī�޶� �ε巴�� �̵��ϵ��� �մϴ�.
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
