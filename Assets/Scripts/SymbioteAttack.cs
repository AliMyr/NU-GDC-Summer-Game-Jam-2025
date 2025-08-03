using UnityEngine;
using UnityEngine.InputSystem;

public class SymbioteAttack : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private Transform attackOrigin;
    [SerializeField] private LayerMask attackMask;

    private float nextAttackTime;

    public void OnAttack(InputValue inputValue)
    {
        if (Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + characterData.AttackCooldown;

        Collider[] hits = Physics.OverlapSphere(attackOrigin.position, characterData.AttackRange, attackMask);

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent<IDamageable>(out var target))
            {
                target.TakeDamage(characterData.AttackDamage);
                break; // атакуем только одного
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrigin == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, characterData.AttackRange);
    }
}
