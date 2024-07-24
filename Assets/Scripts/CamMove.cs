using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed;   // 카메라의 속도

    private void Update()
    {
        if (target != null) // 타겟이 있으면
        {
            // 타겟의 위치를 카메라의 x와 y 위치로 설정하고, 카메라의 z 위치를 유지합니다.
            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

            // Lerp를 사용하여 카메라가 부드럽게 이동하도록 합니다.
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
