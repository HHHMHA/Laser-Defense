using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
    [SerializeField] private int damage = 100;

    public int Damage { get => damage; }

    // TODO: not all damage dealers must be destroyed
    public void Hit() {
        Destroy( gameObject );
    }
}
