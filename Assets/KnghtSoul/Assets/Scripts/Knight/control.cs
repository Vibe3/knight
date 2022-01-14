using UnityEngine;

  //���:2D ��V���b����
  //</Summary>
public class control : MonoBehaviour
{
    #region ���:���}
    [Header("���ʳt��"), Range(0, 500)]
    public float speed = 3.5f;
    [Header("���D����"), Range(0, 15000)]
    public float jump = 500;
    [Header("�ˬd�a�O�ؤo�P�첾")]
    [Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundoffset;
    [Header("���D����P�i���D�ϼh")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canjumpLayer;
    [Header("�ʵe�Ѽ�:�����P���D")]
    public string parameterWalk = "�}���]�B";
    public string parameterJump = "�}�����D";
    #endregion

    #region ���:�p�H
    private Animator ani;
    ///<summary>
    ///���餸�� Rightbody 2D
    ///</summary>
    private Rigidbody2D rig;
    // �N�p�H�����ܦb�ݩʭ��O�W
    [SerializeField]
    ///<summary>
    ///�ˬd�O�_�b�a�O�W
    ///</summary>
    private bool isGrounded;
    #endregion

    #region �ƥ�
    /// <summary>
    /// ø�s�ϥ� Unity ø�s���U�Ϊ��ϥ� �u���B�g�u�B��ΡB��ΡB���ΡB�Ϥ� �ϥ� Gizmos ���O
    /// </summary>
    private void OnDrawGizmos()
    {
        // 1.�M�w�ϥ��C��
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        // 2.�M�wø�s�ϧ�
        // transform.position �����󪺥@�ɮy��
        // transform.TransformDirection() �ھ��ܧΤ��󪺰ϰ�y���ഫ���@�ɮy��
        Gizmos.DrawSphere(transform.position+ transform.TransformDirection(checkGroundoffset), checkGroundRadius);
    }

    private void Start()
    {
        // ������� = ���o����<2D ����>()
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    ///<summary>
    /// update �� 60 FPS
    /// �T�w��s�ƥ� : 50 FPS
    /// �B�z���z�欰
    ///</summary>
    private void FixedUpdate()
     

    {
        if (Knight.hp >0 )
        {
            Move();
        }
    }

    private void Update()
    {
        CheckGround();
        if (Knight.hp > 0)
        {
            Jump();
            Flip();
        }
    } 
    #endregion


    #region ��k
    /// <summary>
    /// 1. ���a�O�_�������ʫ��� ���k��V�� ��A.D
    /// 2. ���󲾰ʦ欰 (API)
    /// </summary>
    private void Move()
    {
        // h �� ���w�� ��J.���o�b�V(�����b) - �����b�N���k��P AD
        float h = Input.GetAxis("Horizontal");
        // print("���a���k����� : " + h);

        // ���餸��.�[�t�� = �s �G���V�q(h �� * ���ʳt�סA����.�[�t��.����);
        rig.velocity = new Vector2(h * speed, rig.velocity.y);

        // �� ������ ������s �Ŀ� �����Ѽ�
        ani.SetBool(parameterWalk, h != 0);
    }
    


    private void Flip()
    {
        float h = Input.GetAxis("Horizontal");

        if (h< 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (h> 0)
        {
            transform.eulerAngles = Vector3.zero;
        }

    }

    /// <summary>
    /// �ˬd�O�_�b�a�O
    /// </summary>
    private void CheckGround()
    {
        //�I����T = 2D ���z.�л\���(�����I,�b�|,
        Collider2D hit = Physics2D.OverlapCircle(transform.position + 
            transform.TransformDirection(checkGroundoffset), checkGroundRadius, canjumpLayer);

        // print("�I�쪺����W��:" + hit.name);

        isGrounded = hit;

        // �� ���b�a�O�W �Ŀ�
        ani.SetBool(parameterJump, !isGrounded);

    }

    /// <summary>
    /// ���D
    /// </summary>
    private void Jump()
    {
        // �p�G �b�a�O�W �åB ���U���w����
        if (isGrounded && Input.GetKeyDown(keyjump))
        {
            //����.�K�[���O(�G���V�q)
            rig.AddForce(new Vector2(0, jump));
        }

    }
    


    #endregion
}