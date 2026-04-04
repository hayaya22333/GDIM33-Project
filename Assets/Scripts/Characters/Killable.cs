using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : Character, IInteractable
{
    [SerializeField] public List<GameObject> itemDrops;
    [SerializeField] private int expDrop = 100;

    // Events
    public delegate void EmptyDelegate();
    public delegate void IntDelegate(int x);

    public event IntDelegate EnemyKilled;

    void Update()
    {
        // Death condition
        if (hp <= 0)
        {
            // Implement drops
            //EnemyKilled.Invoke(expDrop);
            Debug.Log("Gained " + expDrop + "EXP!");
            Debug.Log("Killed " + gameObject.name);
            // Insert item drop function here
            Destroy(gameObject);
        }

    }

    void TakeHit(int dmg)
    {
        hp -= dmg;
        Debug.Log(gameObject.name + " took " + dmg + " damage!");
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
        TakeHit(100);
    }

    public string GetDescription()
    {
        return description;
    }
}
