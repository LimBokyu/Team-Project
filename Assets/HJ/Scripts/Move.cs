using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour, IInteractable
{
    public void Interaction(PlayerController player)
    {
        Debug.Log(string.Format("{0} �� ��ȣ�ۿ� �մϴ�.", player.name));
    }

    public void MoveLeft()
    {
        Debug.Log("Move Left �ߵ�");
        float posX = Mathf.Lerp(transform.position.x, transform.position.x + 10, 1f);
        transform.Translate(new Vector3(posX, transform.position.y, transform.position.z));
    }

}
