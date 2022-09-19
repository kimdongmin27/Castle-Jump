using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemySprite;

    private Material enemyMaterial;

    [SerializeField] int health = 100;
    [SerializeField] Material flash;
    [SerializeField] GameObject effect;

    private void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemyMaterial = enemySprite.material;

        flash = new Material(flash);
    }

    void Update()
    {
        if (GameManager.instance.state == false) return;

        transform.Translate(Vector3.down * Time.deltaTime);

        if(transform.position.y <= -4.5f || health <= 0)
        {
            // effect�� Ȱ��ȭ�Ǿ� ��ƼŬ�� ���̵��� �����մϴ�.
            effect.gameObject.SetActive(true);

            // Enemy ������Ʈ�� 0.25�� �ڿ� �ı��˴ϴ�.
            Destroy(gameObject, 0.25f);
        }
    }

    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {      
        // �浹�� ���� ������Ʈ�� �±װ� Lazer���
        if(other.CompareTag("Lazer"))
        {
            health -= other.GetComponent<Bullet>().attack;
            StartCoroutine(nameof(Damage));
        }

        // Character��� �±׸� ���� ���� ������Ʈ�� �浹���� ��
        if(other.CompareTag("Character"))
        {
            // �浹���� ���� ������Ʈ�� �ı��˴ϴ�.
            Destroy(other.gameObject);
        }
    }

    // ���� ������Ʈ�� �ı��Ǿ��� �� ȣ��Ǵ� �Լ�
    private void OnDestroy()
    {
        GameManager.instance.score += 100;

        // ���� �����͸� �����մϴ�.
        GameManager.instance.Save();

        SoundManager.instance.SoundStart(1);
    }

    private IEnumerator Damage()
    {
        enemySprite.material = flash;
        flash.color = new Color(1, 1, 1, 0.5f);

        yield return new WaitForSeconds(0.05f);

        enemySprite.material = enemyMaterial;
    }
}
