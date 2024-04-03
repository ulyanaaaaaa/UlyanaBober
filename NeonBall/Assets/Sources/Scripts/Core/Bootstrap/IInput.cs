using UnityEngine;

public interface IInput
{
    public Vector3 Direction();
}

public class KeyboardInput : IInput
{
    public Vector3 Direction()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
