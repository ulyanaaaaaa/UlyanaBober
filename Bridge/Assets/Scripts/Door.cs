using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private HingeJoint _joint;
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void Open()
    {
        _material.color = Color.green;
        JointSpring joint = _joint.spring;
        joint.targetPosition = 110;
        _joint.spring = joint;
    }

    public void Close()
    {
        _material.color = Color.gray;
        JointSpring joint = _joint.spring;
        joint.targetPosition = -110;
        _joint.spring = joint;
    }
}
