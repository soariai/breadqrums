using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 4.5f;
    public float accel = 12f;
    public float gravity = -25f;
    public float turnSpeed = 12f;

    CharacterController _cc;
    Vector3 _vel;
    Vector2 _move;

    void Awake(){ _cc = GetComponent<CharacterController>(); }
    public void OnMove(InputValue v){ _move = v.Get<Vector2>(); }

    void Update()
    {
        var camF = Camera.main.transform.forward; camF.y = 0; camF.Normalize();
        var camR = Camera.main.transform.right;   camR.y = 0; camR.Normalize();
        Vector3 targetVel = (camF * _move.y + camR * _move.x) * moveSpeed;
        _vel.x = Mathf.Lerp(_vel.x, targetVel.x, 1 - Mathf.Exp(-accel*Time.deltaTime));
        _vel.z = Mathf.Lerp(_vel.z, targetVel.z, 1 - Mathf.Exp(-accel*Time.deltaTime));
        _vel.y += gravity * Time.deltaTime;
        _cc.Move(_vel * Time.deltaTime);

        Vector3 planar = new Vector3(_vel.x,0,_vel.z);
        if (planar.sqrMagnitude > 0.01f)
        {
            var rot = Quaternion.LookRotation(planar.normalized, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1 - Mathf.Exp(-turnSpeed*Time.deltaTime));
        }
    }
}
