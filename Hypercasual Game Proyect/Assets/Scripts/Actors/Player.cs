using UnityEngine;

public class Player : MonoBehaviour
{
	public delegate void OnPlayerDead();
	public static event OnPlayerDead PlayerDead;

	private Rigidbody2D rb2D;

	[Header("Dash")]
	public float playerDashSpeed;
	private float dashTime;
	public float startDashTime;
	private Vector2 directionFromMouse;
	private bool dashing;

	[Header("Time After Pause")]
	private bool pausedGame;
	public float pauseGameTime;
	private float pauseGameTimeCounter;

	[Header("Objects to Spawn")]
	public GameObject collectableExplosionParticles;
	public GameObject metaCurrencyExplosionParticles;
	public GameObject scoreFloatingText;

	[Header("SFX")]
	public AudioClip deadSFX;
	public AudioClip collectableSFX;

	//private bool scoreMultiplier = false;

	private void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();

		//PowerupMaster.OnScoreMultiplier += ScoreMultiplierPowerup;
		//PowerupMaster.DeApplyPowerups += DeApplyPowerup;
	}

	void Start()
    {
		dashTime = startDashTime;
		dashing = false;
		pausedGame = false;
		pauseGameTimeCounter = pauseGameTime;
    }
	
    void Update()
    {
        if (!dashing) /* The player is not dashing */
		{

#if UNITY_EDITOR || UNITY_STANDALONE

			if (Input.GetMouseButtonDown(0) && !pausedGame) /* Player tries to move and game is not paused */
			{
				PrepareDash();
			}
			else if (pausedGame) /* Game is paused */
			{
				pauseGameTimeCounter -= Time.deltaTime;

				if (pauseGameTimeCounter <= 0f)
				{
					pausedGame = false;
					pauseGameTimeCounter = pauseGameTime;
				}
			}

#endif

#if UNITY_ANDROID

			if ((Input.touchCount > 0) && (Input.touchCount < 2) && (!pausedGame)) /* Player tries to move and game is not paused */
			{
				PrepareDash();
			}
			else if (pausedGame) /* Game is paused */
			{
				pauseGameTimeCounter -= Time.deltaTime;

				if (pauseGameTimeCounter <= 0f)
				{
					pausedGame = false;
					pauseGameTimeCounter = pauseGameTime;
				}
			}

#endif

		}
		else /* The player is dashing */
		{
			if (dashTime <= 0f) /* We check if the dashTime has already get to 0 */
			{
				dashing = false;
				dashTime = startDashTime;
			}
			else /* In case it hasn't reached 0 yet it means player still has to keep dashing */
			{
				dashTime -= Time.deltaTime;
			}
		}
    }

	private void FixedUpdate()
	{
		if (!dashing)
		{
			rb2D.velocity = Vector2.zero;
		}
		else
		{
			rb2D.velocity = directionFromMouse * playerDashSpeed * Time.fixedDeltaTime;
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Enemy"))
		{
			PlayerDead();
			SoundManager.Instance.PlaySFX(deadSFX);
		}
		else if (collider.CompareTag("Collectable"))
		{
			GameManager.Instance.UpdateScoreText(5, collider.transform.position);
			CollectableSpawnner.Instance.SpawnCollectable();
			SoundManager.Instance.PlaySFX(collectableSFX);
			Destroy(Instantiate(collectableExplosionParticles, collider.transform.position, Quaternion.identity), 1f);
			Destroy(collider.gameObject);
		}
		else if (collider.CompareTag("MetaCurrency"))
		{
			MetaCurrencyData.Instance.IncreaseMetaCurrency();
			Destroy(Instantiate(metaCurrencyExplosionParticles, collider.transform.position, Quaternion.identity), 1f);
			CollectableSpawnner.Instance.SpawnCollectable();
			Destroy(collider.gameObject);
		}
	}

	/*
	private void OnDestroy()
	{
		PowerupMaster.OnScoreMultiplier -= ScoreMultiplierPowerup;
		PowerupMaster.DeApplyPowerups -= DeApplyPowerup;
	}
	*/

	public void GamePaused()
	{
		rb2D.velocity = Vector2.zero;
		pausedGame = true;
		dashTime = startDashTime;
		dashing = false;
	}

	private void PrepareDash()
	{
		dashing = true;

#if UNITY_EDITOR || UNITY_STANDALONE
		
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		directionFromMouse = mousePosition - (Vector2)transform.position;
		directionFromMouse.Normalize();

#endif

#if UNITY_ANDROID

		Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
		directionFromMouse = touchPosition - (Vector2)transform.position;
		directionFromMouse.Normalize();

#endif

		// Rotation
		float angleToRotate = Mathf.Atan2(directionFromMouse.y, directionFromMouse.x) * Mathf.Rad2Deg;
		rb2D.rotation = angleToRotate;
	}

	/* POWERUPS LOGIC (WON'T BE IMPLEMENTED)

	public void ScoreMultiplierPowerup()
	{
		scoreMultiplier = true;
	}

	public void DeApplyPowerup()
	{
		scoreMultiplier = false;
	}

	*/
}
