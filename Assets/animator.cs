using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator : MonoBehaviour
{
    public int speed = 4;
    public int s = 1;
    Rigidbody2D rb;
    [SerializeField] Animator _animator;
    bool facingRight = true;
    public ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float t = Input.GetAxisRaw("Horizontal") ;
        if(t>0)
        {
            if(!facingRight)
            {
                TurnArround();
            }
            _animator.SetFloat("Walk", Mathf.Abs(t));
            transform.Translate(Vector3.right * Time.deltaTime * t);
        }
        if(t<0)
        {
            if(facingRight)
            {
                TurnArround();
            }
            _animator.SetFloat("Walk",Mathf.Abs(t));
            transform.Translate(Vector3.right * Time.deltaTime * t);
        }
        if(t==0)
        {
            _animator.SetFloat("Walk", t);
        }
       // rb.velocity = new Vector2(t * speed , rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            //if (!b.IsTouchingLayers(LayerMask.GetMask("Ground")))
            //{
            //    return;
            //}
            _animator.SetBool("Jump", true);
            transform.Translate(Vector2.up * s);
           // rb.AddForce(new Vector2(200, 0));
            
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("Jump", false); 
        }

        //if(_animator.GetComponentInParent<Transform>().rotation.z != 0)
        //{
        //    _animator.GetComponentInParent<Transform>().rotation= Quaternion.identity;
        //}
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.SetBool("Attack", true);
            
            // rb.AddForce(new Vector2(200, 0));
        }
        else
        {
            _animator.SetBool("Attack", false);
        }

    }
    public void TurnArround()
    {
       // transform.rotation += transform.Rotate(Quaternion.Euler(0f,180f,0f));
        facingRight = !facingRight;
        Vector3 scaleChange = transform.localScale;
       scaleChange.x *= -1;
        transform.localScale = scaleChange;
    }

    public void AttackPartical()
    {
        p.Emit(100);
    }
}
