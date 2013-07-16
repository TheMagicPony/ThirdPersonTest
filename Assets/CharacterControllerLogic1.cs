using UnityEngine;
using System.Collections;

public class CharacterControllerLogic1 : MonoBehaviour {
	
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private float DirectionDampTime = 0.25f;
	
	private float speed = 0.0f;
	private float h = 0.0f;
	private float v = 0.0f;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		
		if(animator.layerCount >= 2)
		{
			animator.SetLayerWeight(1,1);	
		}
	}
	
	
	void Update()
	{
		if(animator)
		{
			h = 0;
			v = 0;
			
			if(Input.GetKey(KeyCode.D))
			{
				h = 1f;
			}
			
			if(Input.GetKey(KeyCode.A))
			{
				h = -1f;
			}
			//h = Input.GetAxis("Horizontal");
			//v = Input.GetAxis("Vertical");
			if(Input.GetKey(KeyCode.S))
				v = -1f;
			
			if(Input.GetKey(KeyCode.W))
				v = 1f;

			
			speed = h * h + v *v;
			animator.SetFloat("Speed", speed);
			animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
		}
	}
}
