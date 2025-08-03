using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;

    [SerializeField] private float maxHealth;
    [SerializeField] private float meleeDamage;

    public float WalkSpeed => walkSpeed;
    public float SprintSpeed => sprintSpeed;

    public float JumpHeight => jumpHeight;
    public float Gravity => gravity;

    public float MaxHealth => maxHealth;
    public float MeleeDamage => meleeDamage;
}