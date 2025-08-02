using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private float moveSpeed;

    public float MoveSpeed => moveSpeed;
}