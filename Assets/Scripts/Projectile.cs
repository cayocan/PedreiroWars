using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public Rigidbody rigid;
	[Range (1, 100)]
	public float shootForce;
	public int shootDamage = 1;
	public GameObject enemy;

	//Private Zone
	private Enemy enemyController;

	// Use this for initialization
	void Start ()
	{
		rigid.AddForce (transform.forward * shootForce, ForceMode.Impulse);
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Enemy"))
		{
			enemyController = col.GetComponent<Enemy> ();
			enemyController.life -= shootDamage;
		}

		if (!col.gameObject.CompareTag("Player")) {
			Destroy (gameObject);
		}
	}
}
