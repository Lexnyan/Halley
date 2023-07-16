using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    bool alive = true;

    public float speed;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] private float horizontalMultiplier = 2;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }


    }

    public void Die()
    {
        alive = false;
        //Restart
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}