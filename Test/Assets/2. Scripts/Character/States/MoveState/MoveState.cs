using UnityEngine;

public class MoveState : BaseState
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float _drag_speed = 10f;

    private bool _is_dragging;
    private Vector3 _mouse_offset;

    private CharacterController characterController;

    public void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController is not found on this GameObject!");
            enabled = false;
        }
    }

    public override BaseState StateUpdate()
    {
        ForwardMove();

        if (_is_dragging)
            Drag();

        return this;
    }

    private void ForwardMove()
    {
        float angle = transform.eulerAngles.y;
        Vector3 moveDirection = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        characterController.Move(speed * Time.deltaTime * moveDirection);
    }


    private void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            return;

        Vector3 targetPosition = hit.point;
        targetPosition.y = transform.position.y;
        targetPosition -= _mouse_offset;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        moveDirection = transform.InverseTransformDirection(moveDirection);
        moveDirection.y = 0;
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(_drag_speed * Time.deltaTime * moveDirection);
    }

    void OnMouseDown()
    {
        _is_dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = transform.position.y;
            Vector3 move = targetPosition - transform.position;
            characterController.Move(move);
            _mouse_offset = hit.point - transform.position;
        }
    }

    void OnMouseUp()
    {
        _is_dragging = false;
    }
}