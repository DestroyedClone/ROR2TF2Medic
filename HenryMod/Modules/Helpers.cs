using System;
using System.Collections.Generic;
using RoR2;

namespace MedicMod.Modules
{
    internal static class Helpers
    {
        internal const string agilePrefix = "<style=cIsUtility>Agile.</style> ";

        internal static string ScepterDescription(string desc)
        {
            return "\n<color=#d299ff>SCEPTER: " + desc + "</color>";
        }

        public static T[] Append<T>(ref T[] array, List<T> list)
        {
            var orig = array.Length;
            var added = list.Count;
            Array.Resize<T>(ref array, orig + added);
            list.CopyTo(array, orig);
            return array;
        }

        public static Func<T[], T[]> AppendDel<T>(List<T> list) => (r) => Append(ref r, list);
    }

    internal static class ArrayHelper
    {
        public static T[] Append<T>(ref T[] array, List<T> list)
        {
            var orig = array.Length;
            var added = list.Count;
            Array.Resize<T>(ref array, orig + added);
            list.CopyTo(array, orig);
            return array;
        }

        public static Func<T[], T[]> AppendDel<T>(List<T> list) => (r) => Append(ref r, list);
    }

    internal static class WhateverHelper
    {
        public static float GetCritValue(CharacterBody characterBody)
        {
            var inventory = characterBody.inventory;

            float num9 = inventory.GetItemCount(RoR2Content.Items.CritGlasses);
            var num10 = inventory.GetItemCount(RoR2Content.Items.AttackSpeedOnCrit);
            var num31 = inventory.GetItemCount(RoR2Content.Items.BleedOnHitAndExplode);
            var num11 = inventory.GetItemCount(RoR2Content.Items.CooldownOnCrit);
            var num12 = inventory.GetItemCount(RoR2Content.Items.HealOnCrit);
            var num17 = inventory.GetItemCount(RoR2Content.Items.CritHeal);
            var num27 = inventory.GetItemCount(RoR2Content.Items.ShinyPearl);
            float num38 = characterBody.level - 1f;
            float num61 = characterBody.baseCrit + characterBody.levelCrit * num38;


            num61 += (float)num9 * 10f;
            if (num10 > 0)
            {
                num61 += 5f;
            }
            if (num31 > 0)
            {
                num61 += 5f;
            }
            if (num11 > 0)
            {
                num61 += 5f;
            }
            if (num12 > 0)
            {
                num61 += 5f;
            }
            if (num17 > 0)
            {
                num61 += 5f;
            }
            if (characterBody.HasBuff(RoR2Content.Buffs.FullCrit))
            {
                num61 += 100f;
            }
            num61 += (float)num27 * 10f;
            return num61;
        }
    }
}