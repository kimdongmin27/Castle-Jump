using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    public int attack = 20;

    // ������Ʈ ��ü���� � pool�� ���� �ϴ��� �������ִ� �����Դϴ�.
    private IObjectPool<Bullet> lazerPool;

    void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        lazerPool = pool;
    }

    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        // �޸� Ǯ�� ��ȯ�Ǵ� �Լ�
        lazerPool.Release(this);
    }
}
