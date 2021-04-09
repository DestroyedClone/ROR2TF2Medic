using R2API;
using System;

namespace MedicMod.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Henry
            string prefix = MedicPlugin.developerPrefix + "_MEDIC_BODY_";

            string desc = "Medic is a mercenary that uses his trusty medigun to heal his team, or damage enemies..<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > The syringe guns offer more reliable attacking. Consider the Crusader's Crossbow for when your team gets further away." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Don't worry too hard about your medigun choice, just choose the best you think for the situation." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Your medigun can be used on enemies for a weaker, opposite effect." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Activate your ubercharge when its ready to activate a powerful state for you and your heal target." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Kritzkrieg boosts your damage, so as to not become obsolete!" + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, with another soul to bargain.";
            string outroFailure = "..and so he vanished, never to reanimate again.";

            LanguageAPI.Add(prefix + "NAME", "Medic");
            LanguageAPI.Add(prefix + "DESCRIPTION", desc);
            LanguageAPI.Add(prefix + "SUBTITLE", "Doctor Assisted Homicide");
            LanguageAPI.Add(prefix + "LORE", "sample lore");
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", outro);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Reliable Excavation & Demolitions");
            LanguageAPI.Add(prefix + "BLU_SKIN_NAME", "Builder's League United");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Australium");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "German Medicine");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "All healing is 35% more effective.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_TARGET_NAME", "Target");
            LanguageAPI.Add(prefix + "PRIMARY_TARGET_DESCRIPTION", $"Select a target to heal with your medigun.  Allies get healed, while enemies get the inverse effect. Uber gain rate is 50% slower when damaging enemies.Your mediguns increase in effectiveness by 10 % per level.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_STOCK_NAME", "Syringe Gun");
            LanguageAPI.Add(prefix + "SECONDARY_STOCK_DESCRIPTION", Helpers.agilePrefix + $"Fire needles rapidly for <style=cIsDamage>{100f * StaticValues.syringeGunDamageCoefficient}% damage</style>.");
            LanguageAPI.Add(prefix + "SECONDARY_BLUT_NAME", "Syringe Gun");
            LanguageAPI.Add(prefix + "SECONDARY_BLUT_DESCRIPTION", Helpers.agilePrefix + $"Fires healing needles rapidly for for <style=cIsDamage>{100f * StaticValues.blutDamageCoefficient}% damage</style>. Heals for <style=cIsHealing>{StaticValues.blutHealAmount} health</style>.");
            LanguageAPI.Add(prefix + "SECONDARY_XBOW_NAME", "Crusader's Crossbow");
            LanguageAPI.Add(prefix + "SECONDARY_XBOW_DESCRIPTION", Helpers.agilePrefix + $"Fire a syringe that <style=cIsHealing>heals allies</style> or <style=cIsDamage>damages enemies</style> based on distance traveled, up to <style=cIsDamage>{100f * StaticValues.blutDamageCoefficient}% damage</style>.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_CYCLEUBER_NAME", "Switch Medigun");
            LanguageAPI.Add(prefix + "UTILITY_CYCLEUBER_DESCRIPTION", "Switches your <style=cIsUtility>currently equipped medigun</style>. Takes longer to switch once you've started healing someone.");
            LanguageAPI.Add(prefix + "UTILITY_STRONGUBER_NAME", "Upgraded Uber");
            LanguageAPI.Add(prefix + "UTILITY_STRONGUBER_DESCRIPTION", "Increases the <style=cIsUtility>effectiveness</style> of your currently equipped medigun.");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_BOMB_NAME", "Ubercharge");
            LanguageAPI.Add(prefix + "SPECIAL_BOMB_DESCRIPTION", $"Activate your ubercharge, granting special effects to you and your target.");
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Medic: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Medic, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Henry: Mastery");
            #endregion
            #endregion
        }
    }
}