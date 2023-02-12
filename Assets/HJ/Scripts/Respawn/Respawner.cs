using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField] private int respawnIndex = 0;
    [SerializeField] private int myPlayerNum;

    public void UpdateCheckPoint(int respawnNum)
    {
        if(respawnIndex < respawnNum)
        {
            respawnIndex = respawnNum;
        }
    }

    public void Respawn()
    {
        //���ӸŴ����κ��� ������ ������ �����´�.
        Vector3 respawnPos = RespawnManager.Instance.GetRespawnPos(respawnIndex, 0/* �÷��̾� ��ȣ */);
        transform.position = respawnPos;

        //TODO:
        //�׿� ������ ����
    }
}
