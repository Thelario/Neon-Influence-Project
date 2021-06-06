using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D rb2D;
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private SpriteRenderer spriteRenderer;

	private float enemyMoveSpeed;
	private int enemyScoreReward;

	//private bool slowingOfEnemies = false;

	public EnemyType type;

	public AudioClip whirldSFX;

	private void Start()
	{
		if (type == EnemyType.FAST)
		{
			spriteRenderer.color = ColorSchemeManager.Instance.selectedColorScheme.fastEnemyColor;
			enemyMoveSpeed = Random.Range(StatsManager.Instance.fastEnemyMoveSpeed * 0.925f, StatsManager.Instance.fastEnemyMoveSpeed * 1.075f);
			enemyScoreReward = StatsManager.Instance.fastScoreReward;
		}
		else if (type == EnemyType.NORMAL)
		{
			spriteRenderer.color = ColorSchemeManager.Instance.selectedColorScheme.normalEnemyColor;
			enemyMoveSpeed = Random.Range(StatsManager.Instance.normalEnemyMoveSpeed * 0.925f, StatsManager.Instance.normalEnemyMoveSpeed * 1.075f);
			enemyScoreReward = StatsManager.Instance.normalScoreReward;
		}
		else
		{
			spriteRenderer.color = ColorSchemeManager.Instance.selectedColorScheme.slowEnemyColor;
			enemyMoveSpeed = Random.Range(StatsManager.Instance.slowEnemyMoveSpeed * 0.925f, StatsManager.Instance.slowEnemyMoveSpeed * 1.075f);
			enemyScoreReward = StatsManager.Instance.slowScoreReward;
		}
	}

	void FixedUpdate()
    {
		rb2D.velocity = transform.right * enemyMoveSpeed * Time.fixedDeltaTime;
    }

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			animator.SetTrigger("WhirlTrigger");
			GameManager.Instance.UpdateScoreText(enemyScoreReward, transform.position);
			SoundManager.Instance.PlaySFX(whirldSFX);
		}
		else if (collider.CompareTag("Recycler"))
		{
			gameObject.SetActive(false);
		}
	}

	public void SetRotation(float angle)
	{
		transform.rotation = Quaternion.Euler(0f, 0f, angle);
	}

	/* POWERUPS LOGIC (NOT IMPLEMENTED AND PROBABLY WON'T BE) 
	
	public void ApplySlowMovement()
	{
		slowingOfEnemies = true;
	}

	public void ApplyScoreMultiplier()
	{
		enemyScoreReward = enemyScoreReward * 2;
	}

	public void DeApplyPowerup()
	{
		slowingOfEnemies = false;
		enemyScoreReward = enemyScoreReward / 2;
	}

	*/
}
