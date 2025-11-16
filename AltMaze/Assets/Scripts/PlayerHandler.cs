using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerHandler : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private InputAction moveAction;

    private int collected = 0;

    public int level = 1;

    private void Awake()
    {
        // Create an InputAction for 2D movement
        moveAction = new InputAction(type: InputActionType.Value, binding: "<Gamepad>/leftStick");
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
    }


    public void OnEnable()
    {
        moveAction.Enable();
    }

    public void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        // Movement based on input
        Vector3 move = new Vector3(moveInput.x, moveInput.y, 0) * speed * Time.deltaTime;
        transform.Translate(move);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "End")
        {
            if (collected == 3)
            {
                InGameUIHandler ui = FindFirstObjectByType<InGameUIHandler>();
                ui.gameOver();
                Debug.Log("Level complete!");
            }
            else if (collected < 3)
            {
                Debug.Log("Find all the keys!");
            }
            else
            {
                Debug.Log("More than 3 keys collected (unexpected)");
            }


        }

        if (collision.gameObject.tag == "Keys")
        {
            Destroy(collision.gameObject);
            collected++;
        }

        if (collision.gameObject.tag == "Walls")
        {

        }
    }

    public int getCollected()
    {
        return collected;
    }

}