using System;
using System.Collections;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    MovesData _moves;
    private int damage;
    private string tag;
    
    
    public void Initialize(int damage, string tag)
    {
        this.damage = damage;
        this.tag = tag;
        _moves = new MovesData();
        CalculateRotation();
    }

    private void CalculateRotation()
    {
        string dir = FindAnyObjectByType<PlayerManager>().GetMovement().GetLastMove();
        if(dir == _moves.left) transform.eulerAngles = new Vector3(0, -90, 0);
        if(dir == _moves.right)  transform.eulerAngles = new Vector3(0, 90, 0);
        if(dir == _moves.up)  transform.eulerAngles = new Vector3(0, 0, 0);
        if(dir == _moves.down)  transform.eulerAngles = new Vector3(0, 180, 0);
        StartCoroutine(PerformDestroy());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(this.tag))
        {
            other.GetComponent<IDamagable>().GetDamage(damage);
        }
    }

    IEnumerator PerformDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
