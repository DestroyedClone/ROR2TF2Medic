using System;
using RoR2.Orbs;
using UnityEngine;
using RoR2.Projectile;
using RoR2;

namespace MedicMod.Modules
{
    [RequireComponent(typeof(ProjectileController))]
	[RequireComponent(typeof(ProjectileDamage))]
	public class ProjectileScaleDamageOverDistance : MonoBehaviour
	{
		public float fractionOfDamage;
		private ProjectileDamage projectileDamage;

		private float distanceTraveledToMaxDamage = 100f;
		private float distanceTraveled = 0f;
		private float minimumDamageFraction = 0.0f;
		public float damageFraction = 0f;
		public float cachedDamage = 0f;

		public Vector3 lastPosition = new Vector3();

		private void Awake()
		{
			projectileDamage = base.GetComponent<ProjectileDamage>();
			cachedDamage = projectileDamage.damage;
			lastPosition = transform.position;
		}

		private void FixedUpdate()
		{
			var distance = Vector3.Distance(lastPosition, base.transform.position);
			lastPosition = base.transform.position;

			distanceTraveled += distance;
			var preFraction = distanceTraveled / distanceTraveledToMaxDamage;

			damageFraction = Mathf.Min(preFraction, 1f);
			projectileDamage.damage = cachedDamage * damageFraction;
		}
	}
}
