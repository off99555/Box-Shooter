using UnityEngine;
using System.Collections;

public class ExplodingShooter : MonoBehaviour
{
    public GameObject Projectile;
    public float Power = 5.0f;
    public int Shots = 20;
    public AudioClip shootSFX;
    public GameObject Spawner;

    void OnCollisionEnter(Collision collision)
    {
        if (GameManager.gm.gameIsOver)
        {
            return;
        }
        if (collision.gameObject.tag == "Projectile")
        {
            for (int i = 0; i < Shots; i++)
            {
                GameObject newProjectile =
                    Instantiate(Projectile, transform.position, Random.rotationUniform) as GameObject;
                newProjectile.transform.Translate(Vector3.forward);
                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }
                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody>()
                    .AddForce(newProjectile.transform.forward*Power, ForceMode.VelocityChange);
            }
            // play sound effect if set
            if (shootSFX)
            {
                AudioSource.PlayClipAtPoint(shootSFX, transform.position);
            }
        }
    }
}