using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    public float WalkSpeed => walkSpeed;
    public float SprintSpeed => sprintSpeed;
}