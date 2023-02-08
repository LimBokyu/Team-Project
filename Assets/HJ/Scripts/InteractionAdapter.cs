using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HJ
{
    public class InteractionAdapter : MonoBehaviour, IInteractable
    {
        public UnityEvent<PlayerController> OnInteract;
        public void InterAction(PlayerController player)
        {
            //Debug.Log("���ͷ���");
            OnInteract?.Invoke(player);
        }
    }
}

