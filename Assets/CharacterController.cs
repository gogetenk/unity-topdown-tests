using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 50f;
    private Vector3 _destination;
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", agent.velocity.normalized.magnitude);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //this.transform.position = hit.point;
            //Vector3 targetPostition = new Vector3(hit.point.x,
            //                            this.transform.position.y,
            //                            hit.point.z);
            //this.transform.LookAt(targetPostition);
        }

        if (Input.GetMouseButton(0))
        {
            agent.SetDestination(hit.point);
            //_destination = hit.point;
            //if (_destination != Vector3.zero && Vector3.Distance(this.transform.position, _destination) < 1)
            //{
            //    _destination = Vector3.zero;
            //    this.GetComponent<Animator>().SetBool("IsRunning", false);
            //    return;
            //}

            //this.transform.Translate(this.transform.position * Time.deltaTime * movementSpeed);
            //this.GetComponent<Animator>().SetBool("IsRunning", true);
            //Debug.Log($"Moving to {hit.point}");
        }
    }
}
