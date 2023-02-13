using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HJ_NoneUse
{
    public class InteractionAdapter : MonoBehaviour, HJ_NoneUse.IInteractable
    {
        public UnityEvent<PlayerController> OnInteract;
        public void Interaction(PlayerController player)
        {
            //Debug.Log("���ͷ���");
            OnInteract?.Invoke(player);

        }
    }
}

