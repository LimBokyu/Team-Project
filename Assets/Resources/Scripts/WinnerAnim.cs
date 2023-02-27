using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerAnim : MonoBehaviour
{
    //public List<string> animArray = new List<string>();
    //[SerializeField] private Animation anim;
    //private int index = 0;
    //private int randomNum;

    private Animator anim;

    private PhotonView pv;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pv = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int rd = Random.Range(1, 10); // �ִϸ��̼� �Ѱ��� ��ŭ 2��° ���� ����
            pv.RPC("SetRandomAnim", RpcTarget.All, rd);
        }
    }

    [PunRPC]
    public void SetRandomAnim(int rd)
    {
        anim.SetTrigger(rd.ToString());
    }


}
