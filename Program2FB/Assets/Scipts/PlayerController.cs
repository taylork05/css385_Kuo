using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _jumpforce = 5f;
    private Rigidbody2D _rigidbody;
    private InputAction jumpAction;

    [SerializeField]
    private GameObject _menu;

    private int _score = 0;

    public bool isAlive
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    public int getScore
    {
        get
        {
            return _score;
        }
    }


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        jumpAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/space");
    }

    private void OnEnable()
    {
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered)
         {
             var velocity = _rigidbody.linearVelocity;
             velocity.y = _jumpforce;
             _rigidbody.linearVelocity = velocity;
         }

        transform.rotation = Quaternion.Euler(0f, 0f, _rigidbody.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        _menu.SetActive(true);
        _score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score +=1;
    }
}
