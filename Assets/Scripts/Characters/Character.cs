using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    // Default stats that should exist in all characters
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Collider physicalCollider;
    [SerializeField] public Collider triggerCollider;
    [SerializeField] public Collider hitBox;
    public int hp = 100;
    public int atk = 10;
    public int lvl = 1;
    public virtual string description => "This is a sample character";
    public virtual float speed => 3f;

    // Default methods that should exist in most characters
    public void Attack()
    {
        //Debug.Log(gameObject.name + "dealt " + atk + " damage!");
    }

    public void Follow(GameObject target)
    {
        Vector3 target_pos = target.transform.position;
        transform.LookAt(target_pos);
        transform.position = Vector3.MoveTowards(
            transform.position,
            target_pos,
            speed * Time.deltaTime
            );
    }

    public enum CharState
    {
        Idle,
        Flinch,
        Chase,
        Flee
    }
}