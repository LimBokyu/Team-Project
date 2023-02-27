using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swamp : MonoBehaviour
{
    [SerializeField]
    private float rate;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigid = other.attachedRigidbody;

        if (rigid != null)
        {
            // �ӵ� �������� �ϱ�
            rigid.velocity *= rate;
            //Debug.Log("�ӵ�ũ��: " + rigid.velocity.sqrMagnitude);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        Rigidbody rigid = other.attachedRigidbody;

        if (rigid != null)
        {
            rigid.velocity /= rate;
        }
    }*/
}
