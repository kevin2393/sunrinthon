using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    public float jumpSpeed = 4f;
    public float moveSpeed = 5f;
    public bool isGrounded;
    UiMove um;
    Rigidbody rb;
    int i;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter2D(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isGrounded)//땅에 있을때
        {
            i = 0;
            if (Input.GetKeyDown(KeyCode.W))//w를 입력받으면
            {
                rb.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode2D.Impulse);//점프하고
                //isGrounded = false;//땅에있지 않다고 설정한다
                i++;
                if (i == 2)
                {
                    isGrounded = false;
                }
            }
        }
        if (Input.GetKey(KeyCode.A) || um.left)
        {
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || um.right)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}