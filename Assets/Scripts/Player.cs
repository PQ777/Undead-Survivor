using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour // MonoBehaviour ���� ���� ������ �ʿ��� �͵��� ���� Ŭ����
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();        // GetComponent<T> ������Ʈ���� ������Ʈ�� �������� �Լ�
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");    // GetAxis() ���� �� / Horizontal ����
        inputVec.y = Input.GetAxisRaw("Vertical");     // GetAxis() ���� �� / Vertical ���� 
        // Input.GetAxis�� �Է� ���� �ε巴�� �ٲ�� / GetAxisRaw�� ���� ��Ȯ�� ��Ʈ�� ���� ����(-1 0 1 ���� ��Ȯ�� ������ ������)
    }

    void FixedUpdate()      // FixedUpdate ���� ���� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    {
        // ���� �̵� ���
        // 1. ���� �ش� / AddForce
        //rigid.AddForce(inputVec);

        // 2. �ӵ��� ���� ���� / Velocity
        //rigid.velocity = inputVec;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;     
        // normalized ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��(�밢���� ���� �ӵ�)
        // fixedDeltaTime: ���� ������ �ϳ��� �Һ��� �ð�

        // 3. ��ġ�� �ű�� / MovePosition / MovePosition�� ��ġ �̵��̶� ���� ��ġ�� ������� �Ѵ�
        rigid.MovePosition(rigid.position + nextVec);
    }
}
