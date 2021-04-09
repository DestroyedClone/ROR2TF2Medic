using Mono.Cecil.Cil;
using MonoMod.Cil;
using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace MedicMod.Modules
{
    public static class Buffs
    {
        // Medigun
        internal static BuffDef stockUberBuff;
        internal static BuffDef stockDisuberDebuff;

        // Kritzkrieg
        internal static BuffDef kritzkUberBuff;
        internal static BuffDef kritzDisuberDebuff;

        // Vaccinator
        internal static BuffDef vacUberBuff;
        internal static BuffDef vacDisuberDebuff;

        // Quickfix
        internal static BuffDef qfUberBuff;
        internal static BuffDef qfDisuberDebuff;

        internal static List<BuffDef> buffDefs = new List<BuffDef>();

        internal static void RegisterBuffs()
        {
            // fix the buff catalog to actually register our buffs
            IL.RoR2.BuffCatalog.Init += FixBuffCatalog; // remove this hook after next ror2 update as it will have been fixed

            // Medigun
            stockUberBuff = AddNewBuff("Uber (Stock)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
            stockDisuberDebuff = AddNewBuff("Disuber (Stock)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);

            // Kritzkrieg
            kritzkUberBuff = AddNewBuff("Uber (Kritzkrieg)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
            kritzDisuberDebuff = AddNewBuff("Disuber (Kritzkrieg)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);

            // Vaccinator
            vacUberBuff = AddNewBuff("Uber (Vaccinator)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
            vacDisuberDebuff = AddNewBuff("Disuber (Vaccinator)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);

            // Quickfix
            qfUberBuff = AddNewBuff("Uber (Quick-Fix)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
            qfDisuberDebuff = AddNewBuff("Disuber (Quick-Fix)", Resources.Load<Sprite>("Textures/BuffIcons/texBuffGenericShield"), Color.white, false, false);
        }

        internal static void FixBuffCatalog(ILContext il)
        {
            ILCursor c = new ILCursor(il);

            if (!c.Next.MatchLdsfld(typeof(RoR2Content.Buffs), nameof(RoR2Content.Buffs.buffDefs)))
            {
                return;
            }

            c.Remove();
            c.Emit(OpCodes.Ldsfld, typeof(ContentManager).GetField(nameof(ContentManager.buffDefs)));
        }

        // simple helper method
        internal static BuffDef AddNewBuff(string buffName, Sprite buffIcon, Color buffColor, bool canStack, bool isDebuff)
        {
            BuffDef buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = buffName;
            buffDef.buffColor = buffColor;
            buffDef.canStack = canStack;
            buffDef.isDebuff = isDebuff;
            buffDef.eliteDef = null;
            buffDef.iconSprite = buffIcon;

            buffDefs.Add(buffDef);

            return buffDef;
        }
    }
}