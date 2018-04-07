using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start() {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider() {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        //call ScoreHit from ScoreBoard class
        scoreBoard.ScoreHit(scorePerHit); 

        //this creates explosion in the place of enemy ships when they get destroyed
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); 
        fx.transform.parent = parent;
        Destroy(gameObject);     
    }
}
