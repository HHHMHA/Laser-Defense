using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {
    [SerializeField] private int health = 100;

    private void OnCollisionEnter2D( Collision2D other ) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        TakeDamage( damageDealer );
    }

    private void TakeDamage( DamageDealer damageDealer ) {
        if ( damageDealer != null ) {
            health -= damageDealer.Damage;
            damageDealer.Hit();

            if ( health <= 0 )
                Die();
        }
    }

    private void Die() {
        Destroy( gameObject );
    }
}
