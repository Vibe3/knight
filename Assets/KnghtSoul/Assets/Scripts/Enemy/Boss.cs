using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region 欄位
    [Header("數據"), Range(1, 200)]
    public static int Hp = 100;
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("動畫參數")]
    public string parameterWalk = "開關走路";
    public string parameterAttack = "觸發攻擊";
    public string parameterDead = "觸發死亡";
    [Header("動畫參數")]
    public Transform target;
    [Range(1, 10)]
    public float AttackDamage = 5;
    [Header("攻擊距離"), Range(0, 5)]
    public float attackDistance = 1.3f;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float attackCD = 2.8f;
    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;

    private float angle = 0;

    private Rigidbody2D rig;
    private Animator ani;
    private float timerAttack;
    #endregion

    #region 事件

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {
        // 指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //繪製立方體(中心,尺寸)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize);

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize);
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;

        ani.SetTrigger("觸發受傷");
    }


    private void Update()
    {

        CheckTargerInArea();
        if (Hp <= 0)
        {
            ani.SetBool("開關死亡", true);
            //StartCoroutine(Deadani());
        }

    }
    /*IEnumerator Deadani()
    {
        yield return new WaitForSeconds(3F);
        Destroy(gameObject);


    }*/

    #endregion

    #region 方法
    /// <summary>
    /// 檢查目標是否在區域內
    /// </summary>
    private void CheckTargerInArea()
    {
        //2D物理.覆蓋盒形(中心，尺寸，角度)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        //if (hit) Move(); 

        if (Knight.hp > 0 && Hp > 0)
        {
            if (hit) Move();
        }




    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        #region 移動
        // 三元運算子語法:布林值 ? 當布林值 為 true: 當布林值 為 false ; 
        // 如果 目標的X小於 敵人的 X就代表在左邊 角度0
        // 如果 目標的X大於 敵人的 X就代表在右邊 角度180

        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rig.velocity = transform.TransformDirection(new Vector2(-speed, rig.velocity.y));
        ani.SetBool(parameterWalk, true);

        float distance = Vector3.Distance(target.position, transform.position);
        //print("與目標的距離: " + distance);
        #endregion
        if (Knight.hp > 0)
        {

            if (distance <= attackDistance) //如果距離小於等於攻擊距離
            {
                rig.velocity = Vector3.zero; //停止
                Attack();
            }
        }
        if (Knight.hp <= 0)
        {
            ani.SetBool(parameterWalk, false);

        }
    }



    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (timerAttack < attackCD)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            ani.SetTrigger(parameterAttack);
            timerAttack = 0;
            Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize, 0, layerTarget);
            print("攻擊到物件: " + hit.name);
            //hurtSystem.Hurt(AttackDamage);
            hit.GetComponent<Knight>().Hurt(AttackDamage);
        }
    }

    #endregion
}
