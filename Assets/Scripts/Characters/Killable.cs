using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : Character
{
    [Header("Enemy Properties")]
    [SerializeField] public List<GameObject> itemDrops;
    [SerializeField] private int expDrop = 100;
    [SerializeField] private GameObject damagePopupPrefab;

    CharState state = CharState.Idle;
    GameObject target;
    PlayerController player;
    private float stunTime = 0.2f;
    private float positionLockTimer;

    void Awake()
    {
        hp = 200;
        speed = 2f;
    }

    void Start()
    {
        player = Locator.Instance.Player;
        target = player.gameObject;
    }

    void Update()
    {
        // Connect this to state machine!!
        if (!positionLocked)
        {
            positionLockTimer = stunTime;
        }
        else
        {
            positionLockTimer -= Time.deltaTime;
            if (positionLockTimer <= 0)
            {
                positionLocked = false;
            }
        }
        if (hp <= 0)
        {
            // Implement drops
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
        player.GetEXP(expDrop);

        physicalCollider.enabled = false;
        Destroy(this);
    }

    void DropItems()
    {
        foreach (GameObject item in itemDrops)
        {
            Instantiate(item, transform.position, transform.rotation);
        }
    }

    public void HandleDamage(int dmg, string dmgSource, string damagedPart)
    {
        positionLocked = true;
        hp -= dmg;
        Debug.Log(gameObject.name + "'s " + damagedPart + " took " + dmg + " damage from " + dmgSource + "!!");

        state = CharState.Chase;

        // Visual feedback
        DamagePopUp popUp = Instantiate(damagePopupPrefab, transform.position, transform.rotation).GetComponent<DamagePopUp>();
        popUp.PopNum(dmg);
    }

    public string GetDescription()
    {
        return description;
    }
}
