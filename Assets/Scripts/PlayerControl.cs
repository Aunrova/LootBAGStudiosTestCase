using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed=1.0f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector3 CharPos;
    [SerializeField] private GameObject _camera;
    private SpriteRenderer _renderer;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        CharPos=transform.position;
        _renderer =GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    CharacterMelee();
        /*if(Input.GetKey(KeyCode.Space))
        {
            speed=1.0f;
            Debug.Log("Speed 1.0f");
        }
        else
        {
            speed=0.0f;
            Debug.Log("Speed 0.0f");
        }*/

    //_animator.SetFloat("speed",speed);
    //_rigidbody2D.linearVelocity=new Vector2(speed,0f);
    CharPos = new Vector3(CharPos.x+Input.GetAxis("Horizontal")*speed*Time.deltaTime,CharPos.y);
    transform.position=CharPos;

    if(Input.GetAxis("Horizontal")==0.0f)
    {
        _animator.SetFloat("speed",0.0f);
    }
    else
    {
        _animator.SetFloat("speed",speed);
    }

    if(Input.GetAxis("Horizontal")>0.01f)
    {
        _renderer.flipX=false;
    }
    else if (Input.GetAxis("Horizontal")<-0.01f)
    {
        _renderer.flipX=true;
    }

    }


    private void LateUpdate()
    {
        _camera.transform.position= new Vector3(CharPos.x, CharPos.y+1.6f, CharPos.z-1.0f);
    }


    void CharacterMelee()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("isMelee");
        }
    }
}
