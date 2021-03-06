using BepInEx;
using R2API.Utils;
using RoR2;
using System.Security;
using System.Security.Permissions;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace MedicMod
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    [R2APISubmoduleDependency(new string[]
    {
        "PrefabAPI",
        "LanguageAPI",
        "SoundAPI",
    })]

    public class MedicPlugin : BaseUnityPlugin
    {
        public const string MODUID = "com.DestroyedClone.ROR2TF2Medic";
        public const string MODNAME = "TF2 Medic";
        public const string MODVERSION = "1.0.0";

        // a prefix for name tokens to prevent conflicts- please capitalize all name tokens for convention
        public const string developerPrefix = "ROB";

        public static MedicPlugin instance;

        private void Awake()
        {
            instance = this;

            // load assets and read config
            Modules.Assets.Initialize();
            Modules.Config.ReadConfig();
            Modules.States.RegisterStates(); // register states for networking
            Modules.Buffs.RegisterBuffs(); // add and register custom buffs/debuffs
            Modules.Projectiles.RegisterProjectiles(); // add and register custom projectiles
            Modules.Tokens.AddTokens(); // register name tokens
            Modules.ItemDisplays.PopulateDisplays(); // collect item display prefabs for use in our display rules

            // create your survivor here
            new Modules.Survivors.MyCharacter().Initialize();

            // now make a content pack and add it- this part will change with the next update
            new Modules.ContentPacks().CreateContentPack();

            Hook();
        }

        private void Start()
        {
            // have to set item displays in start now because they require direct object references..
            Modules.Survivors.MyCharacter.instance.SetItemDisplays();
        }

        private void Hook()
        {
            // run hooks here, disabling one is as simple as commenting out the line
            On.RoR2.CharacterBody.RecalculateStats += CharacterBody_RecalculateStats;
            On.RoR2.HealthComponent.TakeDamage += HealthComponent_TakeDamage;
        }

        private void HealthComponent_TakeDamage(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {

            if (self)
            {
                // Stock Uber //
                if (self.body.HasBuff(Modules.Buffs.stockUberBuff))
                {
                    damageInfo.damage = 0f;
                }
                if (self.body.HasBuff(Modules.Buffs.stockDisuberDebuff))
                {
                    damageInfo.damage *= 1.5f;
                }

                // Kritzkrieg
                if (damageInfo.attacker)
                {
                    var attackerCB = damageInfo.attacker.GetComponent<CharacterBody>();
                    if (attackerCB.HasBuff(Modules.Buffs.kritzkUberBuff))
                    {
                        var crit = Modules.WhateverHelper.GetCritValue(self.body);
                        if (crit > 100f)
                        {
                            damageInfo.crit = true;
                            damageInfo.damage *= (100f - crit)/100f;
                        }
                    }
                    if (attackerCB.HasBuff(Modules.Buffs.kritzDisuberDebuff))
                    {
                        damageInfo.damage *= 0.5f;
                    }
                }
            }


            orig(self, damageInfo);
        }

        private void CharacterBody_RecalculateStats(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self);

            // a simple stat hook, adds armor after stats are recalculated
            if (self)
            {
                if (self.HasBuff(Modules.Buffs.stockUberBuff))
                {
                    self.healthComponent.godMode = true;
                }
            }
        }
    }
}