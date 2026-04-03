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
    public virtual int hp => 100;
    public virtual int atk => 30;
    public virtual string description => "This is a sample character";
    public virtual float speed => 5f;

    // Default methods that should exist in most characters
    public void Attack()
    {
        Debug.Log("Dealt " + atk + " damage!");
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
}