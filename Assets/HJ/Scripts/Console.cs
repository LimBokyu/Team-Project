using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HJ
{
    public class Console : MonoBehaviour, IInteractable, IControllable
    {
        [SerializeField] private float duration;
        [SerializeField] private float coolTime;
        [SerializeField] private ParticleSystem buttonDownParticle;

        public UnityEvent<float, float> OnActivate;

        private Animator anim;
        private Coroutine coolTimeCoroutine;

        private PhotonView pv;

        private void Awake()
        {
            anim = GetComponent<Animator>();
            pv = GetComponent<PhotonView>();
        }

        // �뷫 ���⿡ RPC? (�÷��̾� ��ġ Ŭ�������� ȣ��)

        public void InterAction(PlayerController player)
        {
            pv.RPC("Control", RpcTarget.All, duration, coolTime);
            //Control(duration, coolTime);
        }

        [PunRPC]
        public void Control(float duration, float coolTime)
        {
            if (coolTimeCoroutine != null)
                return;

            Debug.Log("����");
            OnActivate?.Invoke(duration, coolTime);
            anim.SetBool("Activate", true);
            if (buttonDownParticle != null) buttonDownParticle.Play();
            // TODO: ��ư ������ �߰�
            coolTimeCoroutine = StartCoroutine(CoolTime());

        }

        private IEnumerator CoolTime()
        {
            yield return new WaitForSeconds(duration + coolTime);

            anim.SetBool("Activate", false);
            coolTimeCoroutine = null;
        }
    }
}
