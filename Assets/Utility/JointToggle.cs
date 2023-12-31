using System;
using UnityEngine;

public class JointToggle : MonoBehaviour
{
    [SerializeField] private Joint joint;
    private Rigidbody connectedBody;

    private void Awake()
    {
        joint = joint ? joint : GetComponent<Joint>();
        if (joint) connectedBody = joint.connectedBody;
        else Debug.LogError("No joint found.", this);
    }

    private void OnEnable() { joint.connectedBody = connectedBody; }

    private void OnDisable()
    {
        joint.connectedBody = null;
        connectedBody.WakeUp();
    }

}