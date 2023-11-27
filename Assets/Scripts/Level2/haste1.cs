using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haste1 : MonoBehaviour
{
    Vector3 trans1;
    Vector2 trans2;
    public float zhenFu = 1f;
    public float HZ = 1f;
    public float speedMultiplier = 2f; // ���ٱ���
    public float delayBeforeReset = 1f; // �����ٶȵ��ӳ�ʱ��
    public float scaleMultiplier = 1.5f; // ���ű���
    private void Awake()
    {
        trans1 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        trans2 = trans1;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans1.y;
        transform.position = trans2;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // ����� Player ����ײ
        if (other.CompareTag("Player"))
        {
            // ��ȡ Player �Ľű�
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                // Ӧ�ü���Ч��
                playerMovement.SetSpeedMultiplier(speedMultiplier, delayBeforeReset); StartCoroutine(ScaleEffect());
            }
        }
    }
    IEnumerator ScaleEffect()
    {
        // ����Ч�����Ŵ�
        transform.localScale *= scaleMultiplier;
        yield return new WaitForSeconds(0.1f); // ��������ʱ�䣬���Ը�����Ҫ����
        // ����Ч������С
        transform.localScale /= scaleMultiplier;
    }
}
