using UnityEngine;

[CreateAssetMenu(menuName = "Config/Input")]
public class InputConfig : ScriptableObject
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode interactiveKey;
}
