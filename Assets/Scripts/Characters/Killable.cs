using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : Character, IInteractable
{
    [SerializeField] private GameObject target;
    [SerializeField] public List<GameObject> itemDrops;
    [SerializeField] private int expDrop = 100;
    CharState state = CharState.Idle;

    // Events
    public delegate void EmptyDelegate();
    public delegate void IntDelegate(int x);

    //public event IntDelegate EnemyKilled;

    void Update()
    {
        // Death condition
        if (hp <= 0)
        {
            // Implement drops
            //EnemyKilled.Invoke(expDrop);
            Debug.Log("Gained " + expDrop + "EXP!");
            Debug.Log("Killed " + gameObject.name);
            // Insert death protocol here.
            Die();
        }

        switch (state){
            case CharState.Idle:
                break;
            case CharState.Chase:
                Follow(target);
                break;
            case CharState.Flee:
                break;
        }
    }

    void Die()
    {
        rb.constraints = ~RigidbodyConstraints.FreezeAll;
        Destroy(this);
    }

    void TakeHit(int dmg)
    {
        hp -= dmg;
        Debug.Log(gameObject.name + " took " + dmg + " damage!");

        state = CharState.Chase;
    }

    void DropItems()
    {
        foreach (GameObject item in itemDrops)
        {
            Instantiate(item, transform.position, transform.rotation);
        }
    }

    public void Interact()
    {
        TakeHit(50);
    }

    public string GetDescription()
    {
        return description;
    }
}
