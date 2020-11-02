using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 10f;
    private NavMeshAgent agent;
    private Animator animator;
    private Vector2 inputMovement;
    private Vector2 inputRotation;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        //if (Input.GetMouseButton(0))
        //    MoveToMousePosition();

        //if (Input.GetMouseButton(1))
        //    Attack();

        animator.SetFloat("Velocity", agent.velocity.normalized.magnitude);
    }

    private void Move()
    {
        this.transform.Translate(new Vector3(inputMovement.x, 0, inputMovement.y) * movementSpeed * Time.deltaTime);
        this.transform.Rotate(new Vector3(0, inputRotation.y * rotationSpeed * Time.deltaTime));
    }

    public void OnAttack()
    {
        this.animator.SetTrigger("IsAttacking");
        //var mousePosition = GetMousePosition();
        //var targetPostition = new Vector3(mousePosition.x, this.transform.position.y, mousePosition.z);
        //this.transform.LookAt(targetPostition);
    }

    private Vector3 GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
            return Vector3.zero;

        return hit.point;
    }

    private void MoveToMousePosition()
    {
        var mousePosition = GetMousePosition();
        agent.SetDestination(mousePosition);
    }

    public void OnMove(InputValue value)
    {
        inputMovement = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        inputRotation = value.Get<Vector2>();
    }
}
