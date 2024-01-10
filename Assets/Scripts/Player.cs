using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // MonoBehaviour 게임 로직 구성에 필요한 것들을 가진 클래스
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();        // GetComponent<T> 오브젝트에서 컴포넌트를 가져오는 함수
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");    // GetAxis() 축의 값 / Horizontal 수평
        inputVec.y = Input.GetAxisRaw("Vertical");     // GetAxis() 축의 값 / Vertical 수직 
        // Input.GetAxis는 입력 값이 부드럽게 바뀐다 / GetAxisRaw는 더욱 명확한 컨트롤 구현 가능(-1 0 1 같이 명확한 값으로 떨어짐)
    }

    void FixedUpdate()      // FixedUpdate 물리 연산 프레임마다 호출되는 생명주기 함수
    {
        // 물리 이동 방식
        // 1. 힘을 준다 / AddForce
        //rigid.AddForce(inputVec);

        // 2. 속도를 직접 제어 / Velocity
        //rigid.velocity = inputVec;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;     
        // normalized 벡터 값의 크기가 1이 되도록 좌표가 수정된 값(대각선도 같은 속도)
        // fixedDeltaTime: 물리 프레임 하나가 소비한 시간

        // 3. 위치를 옮긴다 / MovePosition / MovePosition는 위치 이동이라 현재 위치도 더해줘야 한다
        rigid.MovePosition(rigid.position + nextVec);
    }
}
