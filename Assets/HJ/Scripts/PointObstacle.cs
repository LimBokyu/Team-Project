using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointObstacle : MonoBehaviour
{
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    /// <summary>
    /// ���������� ������Ʈ���� ���� ���� ��
    /// �÷��̾��� �ִ� �ӵ� ������ �����ؾ� �Ѵ�.
    /// �÷��̾ �̸� ���� ���·� ����� ������� �ִ� �ӵ� ������ �����غ���.
    /// (�ִϸ��̼� �����ӿ��� �����ϴ� �Լ�)
    /// </summary>
    public void Hit()
    {
        Collider[] colliders = Physics.OverlapSphere(hitPoint.position, radius, layerMask);
        //Debug.Log(colliders.Length);
        foreach (Collider collider in colliders)
        {
            PlayerController pc = collider.GetComponent<PlayerController>();
            if (pc != null)
            {
                //Debug.Log("�÷��̾� ��Ʈ");
                pc.OnHit();
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(hitPoint.position, radius);
    }
}
