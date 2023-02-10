using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Force, radius;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();

            if (pc != null)
            {
                //pc.OnHit();
            }

            if (rigid != null)
            {
                Debug.Log("����");
                rigid.AddExplosionForce(Force, transform.position, radius);
            }

            //Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            //for (int i = 0; i < colliders.Length; i++)
            //{
            //    Debug.Log("Player�浹���� ����");
            //    PlayerController pc = colliders[i].gameObject.GetComponent<PlayerController>();
            //    Rigidbody rigid = colliders[i].gameObject.GetComponent<Rigidbody>();

            //    if (pc != null)
            //    {
            //        Debug.Log("OnHit ȣ��");
            //        pc.OnHit();
            //    }

            //    if (rigid != null)
            //    {
            //        rigid.AddExplosionForce(Force, transform.position, radius);
            //    }
            //}
        }
    }
}
