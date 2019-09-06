﻿using System.Collections.Generic;
using System.Linq;
using BoardSystem;
using UnityEngine;

namespace SkillSystem
{
    [CreateAssetMenu(fileName = "MagicSkillSniping", menuName = "Magic Card/Sniping", order = 5)]
    public class MagicSkillSniping : MagicSkill
    {
        public BoardLayer layer;
        public int damage;

        public override List<BoardCoord> GetTargetCoordinations()
        {
            List<BoardCoord> coords = new List<BoardCoord>();

            if (GameManager.Instance.currentTurn == TeamColor.Black)
            {
                coords = layer.GetCoordinations(BoardManager.Instance.kingBlack).ToList();
            }
            else
            {
                coords = layer.GetCoordinations(BoardManager.Instance.kingWhite).ToList();
            }

#if DEBUG_ALL || DEBUG_SKILL || DEBUG_SKILL_MAGIC
            string DEBUG_STRING = $"Magic Skill Sniping Target Query\"{name}\"";
            DEBUG_STRING += $"\nQueried count [{coords.Count()}]";
            DEBUG_STRING += $"\nQueried list below";
            foreach (var ELEM in coords)
            {
                DEBUG_STRING += $"\n({ELEM.col}, {ELEM.row})";
            }
            Debug.Log(DEBUG_STRING);
#endif

            return coords;
        }

        public override void Operate(BoardCoord[] targets)
        {
            foreach (var target in targets)
            {
                BoardManager.Instance.GetPieceAt(target).DamageHP(damage);
                BoardManager.Instance.GetPieceAt(target).UpdateStatus();
            }

#if DEBUG_ALL || DEBUG_SKILL || DEBUG_SKILL_MAGIC
            string DEBUG_STRING = $"Magic Skill Sniping Operate \"{name}\"";
            DEBUG_STRING += $"\nTarget count [{targets.Count()}]";
            DEBUG_STRING += $"\nDamage {damage} HP";
            DEBUG_STRING += $"\nTarget list below";
            foreach (var ELEM in targets)
            {
                DEBUG_STRING += $"\n{BoardManager.Instance.GetPieceAt(ELEM)} at ({ELEM.col}, {ELEM.row})";
            }
            Debug.Log(DEBUG_STRING);
#endif
        }
    }
}