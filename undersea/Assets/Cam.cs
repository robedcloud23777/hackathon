using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;// 카메라가 따라갈 대상
    public float moveSpeed;//카메라의 속도
    private Vector3 targetPosition;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject != null)//타겟이 있으면
        {
            targetPosition.Set(target.transform.position.x, this.transform.position.y, this.transform.position.z); //타겟의 x,y를 똑같이 따라가고 카메라의 z값이 대상과 같으면 안보임 그래서 this 사용해서 카메라의 z값을 유지
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //this 는 카메라를 가리키기 때문에 카메라의 포지션을 바꿈 Lerp(a,b,c) a에서 b까지의 거리를 C의 속도로 움직이느 것
            //1초에 moveSpeed 만큼 움직임 

        }
    }
}
