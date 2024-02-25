using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour ,IDamageable
{
    public int Diamonds;
    private Rigidbody2D _rigid;
    [SerializeField] private float _jumpforce=5.0f;
    [SerializeField] private bool grounded = false;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private bool resetjumpneeded = false;
    [SerializeField] private PlayerAnimation _anim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swardSprite;
    public AudioClip Death1;
    public AudioClip hit;
    public AudioClip diamond;
    public int Health { get; set; }

    [SerializeField]
    private float _speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
       _rigid= GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        /*_swardSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();*/
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(1)*/
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && grounded==true)
        {
            _anim.Attack();
        }
        // float Move = Input.GetAxis("Horizontal");
        float Move = CrossPlatformInputManager.GetAxis("Horizontal");
        /*Debug.Log("vertical");*/
        //Input.GetAxis("Horizontal");
        /*Debug.Log("vertical");*/
        _rigid.velocity = new Vector2(Move * _speed, _rigid.velocity.y);
        if (Move > 0)
        {
            _sprite.flipX = false;
        }
        else if (Move < 0)
        {
            _sprite.flipX = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button"))  && grounded==true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            grounded = false;
            resetjumpneeded = true;
            StartCoroutine(resetjumpneededroutin());
            _anim.Jump(true);
             

        }
        IEnumerator resetjumpneededroutin()
        {
            yield return new WaitForSeconds(1f);
            resetjumpneeded = false;
        }



        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.2f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down*1.2f, Color.green);
        if (hitInfo.collider != null)
        {
                _anim.Jump(false);
                grounded = true;
            
        }



        _rigid.velocity = new Vector2(Move*_speed, _rigid.velocity.y);
        _anim.Move(Move);
  
    }

/*    void Flip(bool flipstart)
    {
        if (flipstart == true)
        {
            _sprite.flipX = false;
            _swardSprite.flipX = false;
            _swardSprite.flipY = false;

            Vector3 newPos = _swardSprite.transform.localPosition;
            newPos.x = 1.0f;
            _swardSprite.transform.localPosition = newPos;
        }
        else if(flipstart == false)
        {
            _sprite.flipX = true;
            _swardSprite.flipX = true;
            _swardSprite.flipY = true;

            Vector3 newPos = _swardSprite.transform.localPosition;
            newPos.x = -1.0f;
            _swardSprite.transform.localPosition = newPos;
        }
    }*/
 
    public void Damege()
    {
        Debug.Log("Plaer:Damage");
        if (Health < 1)
        {
            return;
        }
      
        Health--;
        UiManager.IUnstance.Updatelive(Health);
        if (Health < 1)
        {
            _anim.Death();
            AudioSource.PlayClipAtPoint(Death1, transform.position, 50f);
        }
        else
        {
            _anim.Hit();
            AudioSource.PlayClipAtPoint(hit, transform.position, 50f);
        }
    }

    public void AddGems(int amount)
    {
        Diamonds += amount;
        UiManager.IUnstance.UpdateGemsCount(Diamonds);
        AudioSource.PlayClipAtPoint(diamond, transform.position, 50f);
    }
}
