using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Knight : MonoBehaviour
{
    public static float hp = 10;
    public int max_hp = 10;

    public Image blood;


    private Animator ani;
    public string parameterDead = "Ĳ�o���`";
    public UnityEvent onDead;

    private void Start()
    {
        print("Start");
        hp = max_hp;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (blood.transform.localScale.x > 0)
        {
            blood.transform.localScale = new Vector3((float)hp / (float)max_hp, blood.transform.localScale.y, blood.transform.localScale.z);

        }

        if(Knight.hp <=0)
        {
            ani.SetTrigger(parameterDead);
        }


    }

    public void Hurt(float damage)
    {
        print("��q");
        hp -= damage;
        ani.SetTrigger("Ĳ�o����");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 1;
            ani.SetTrigger("Ĳ�o����");
        }
    }



}
