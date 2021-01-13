using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {
    [SerializeField] private int health = 100;
    [SerializeField] private GameObject explosionFXPrefab;
    [SerializeField] private AudioClip explosionAudioClip;

    private void OnCollisionEnter2D( Collision2D other ) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        TakeDamage( damageDealer );
    }

    private void TakeDamage( DamageDealer damageDealer ) {
        if ( damageDealer == null )
            return;

        health -= damageDealer.Damage;
        damageDealer.Hit();

        if ( health <= 0 )
            Die();
    }

    private void Die() {
        if ( explosionFXPrefab != null )
            Instantiate( explosionFXPrefab, transform.position, Quaternion.identity );
        if (explosionAudioClip != null)
            AudioSource.PlayClipAtPoint( explosionAudioClip, Camera.main.transform.position, 0.3f );
        if ( IsLastPlayer() ) {
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
        }
        Destroy( gameObject );
    }

    private bool IsLastPlayer() {
        return GetComponent<Player>() != null && FindObjectsOfType<Player>().Length == 1;
    }
}
