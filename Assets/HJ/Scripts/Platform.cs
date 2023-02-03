using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HJ
{
    public class Platform : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("�浹");
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("�÷��̾�� �浹");
                collision.transform.parent = transform;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.transform.parent = null;
            }
        }
    }
}

