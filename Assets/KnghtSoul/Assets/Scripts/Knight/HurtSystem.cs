using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HurtSystem : MonoBehaviour
{
    private void Update()
    {
        Dead();
    }


    [Header("¦º¤`¨Æ¥ó")]
    public UnityEvent onDead;


    private void Dead()
    {
        if (Knight.hp <= 0)
        {
            onDead.Invoke();
        }
    }
}
