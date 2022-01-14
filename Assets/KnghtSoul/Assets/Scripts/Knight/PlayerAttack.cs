using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float time;
    public float startTime;

    [Header("§ðÀ»«öÁä")]
    public KeyCode keyattack = KeyCode.J;
    public string attackname;

    [Header("§ðÀ»¶ZÂ÷"), Range(0, 5)]
    public float attack = 1.3f;

    public Animator anim;
    private PolygonCollider2D coll2D;

     void Start()
    {
        coll2D = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(keyattack))
        {
            print("§ðÀ»°Êµe");
            anim.SetTrigger(attackname);

            StartCoroutine(StartAttack());

        }
        
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startTime);
        coll2D.enabled = true;
        StartCoroutine(disableHitbox());

    }

    IEnumerator disableHitbox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            other.GetComponent<Boss>().TakeDamage(damage);
        }
    }



}
