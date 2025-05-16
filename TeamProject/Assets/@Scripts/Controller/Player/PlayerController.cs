using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Transform tr;
    Rigidbody2D rb;
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Attack1();
        Jump();
    }
    void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            Vector2 moveDir = new Vector2(h, 0);
            tr.Translate(Vector2.right*Time.deltaTime * 5/*���� �÷��̾�� ��ũ��Ʈ���� Speed���� �޾ƿͼ� ��ü*/ * moveDir);
            anim.SetBool("isRun", true);
            
            if (h > 0)
            {
                tr.localScale = new Vector3(1, 1, 1);
            }
            else if (h < 0)
            {
                tr.localScale = new Vector3(-1, 1, 1);
            }
        }
        else 
        {
            anim.SetBool("isRun", false);
            
        }
    }
    public void Attack1()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetTrigger("Attack");
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            rb.AddForce(Vector3.up * 10,ForceMode2D.Impulse);
        }
    }
}
