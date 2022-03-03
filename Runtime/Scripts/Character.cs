using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem hitMileStoneFX;
    [SerializeField] private ParticleSystem hitGoalFX;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float timeout = 0.2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip goalSound;

    private float cooldown = 0f;
    private bool IsActive = true;
    public AudioSource CharacterAudioSource { get; private set; }
    public bool HoldPosition { get; set; }
    public bool HoldHeight  { get; set; }
    public int CurrentMileStone { get; set; }
    public int CurrentCoins { get; set; }

    private void Start() {
        HoldPosition = true;
        HoldHeight = true;
        CurrentMileStone = 0;
        CurrentCoins = 0;
        CharacterAudioSource = GetComponent<AudioSource>();
    }

    private void StartLevel()
    {
        HoldHeight = false;
    }

    void Update()
    {
        if(!IsActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        cooldown -= Time.deltaTime;

        if(HoldPosition)
            transform.position = new Vector2(0, transform.position.y);
        else {
            Vector3 newPos = transform.position;
            newPos.x += speed * Time.deltaTime;
            newPos.z = 0f;
            transform.position = newPos;
        }

        if(HoldHeight)
            transform.position = new Vector2(transform.position.x, 0);
    }

    public void Jump()
    {
        if (cooldown > 0) return;

        CharacterAudioSource.PlayOneShot(jumpSound);
        animator.SetTrigger("Jump");
        cooldown = timeout;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
    }

    private void HitWall()
    {
        Collider2D coll = GetComponentInChildren<Collider2D>();
        
        if(coll)
            coll.enabled = false;

        CharacterAudioSource.PlayOneShot(hitSound);
        animator.SetTrigger("HitWall");
        IsActive = false;

        LevelController levelController = FindObjectOfType<LevelController>();
        levelController.IsActive = false;

        UIController uiController = FindObjectOfType<UIController>();
        uiController.EndLevel();
    }

    private void HitMileStone()
    {
        CurrentMileStone++;
        animator.SetTrigger("HitMileStone");
        hitMileStoneFX.Play();
    }

    private void HitGoal() {
        animator.SetTrigger("HitGoal");

        CharacterAudioSource.PlayOneShot(goalSound);

        FollowPlayer followPlayer = FindObjectOfType<FollowPlayer>();
        followPlayer.IsActive = false;
        HoldPosition = false;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.simulated = false;
        hitGoalFX.Play();

        UIController uiController = FindObjectOfType<UIController>();
        uiController.EndLevel();
    }

    private void HitCoin(GameObject _coin){
        CoinController coin = _coin.GetComponentInParent<CoinController>();

        if(!coin) return;

        coin.Collect();
        CurrentCoins++;
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.transform.CompareTag("Wall"))
            HitWall();
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.transform.CompareTag("MileStone"))
            HitMileStone();

        if (_other.transform.CompareTag("Goal"))
            HitGoal();

        if (_other.transform.CompareTag("Coin"))
            HitCoin(_other.gameObject);
    }
}
