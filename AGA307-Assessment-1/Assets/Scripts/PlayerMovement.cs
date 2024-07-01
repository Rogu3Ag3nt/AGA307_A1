using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController Controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    public GameObject projectilePrefab;
    public float projectileSpeed = 1000;

    public Transform firingPoint;

    Vector3 velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectileInstance;
            projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);
            Destroy(projectileInstance, 5);
        }

    }
}
