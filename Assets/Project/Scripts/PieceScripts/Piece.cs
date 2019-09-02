﻿using System;
using UnityEngine;

namespace PieceSystem
{
    public class Piece : MonoBehaviour
    {
        [Flags]
        public enum StatusFlag
        {
            Initial = 0,
            Dead = 1 << 0,
            Moved = 1 << 1
        }

        private TeamColor team;
        private HeroCard data = null;
        private BoardCoord position = new BoardCoord(0, 0);
        private BufDebuf[] bufDebufs = {};
        private StatusFlag status = StatusFlag.Initial;
        private int HPCurrent = 0;
        private int HPAdditional = 0;
        private int ATKCurrent = 0;
        private int movability = 0;
        private int unbeatability = 0;
        private int skillAvailability = 0;

        public void Initialize(TeamColor teamColor, HeroCard heroCard)
        {
            team = teamColor;
            data = heroCard;
        }

        public void UpdateStatus()
        {
            // TODO(@Tetramad)
            throw new System.NotImplementedException();
        }

        public BoardCoord[] GetMovablePositions()
        {
            return data.heroClass.GetMovablePositions(this);
        }

        public BoardCoord[] GetAttackablePositions()
        {
            return data.heroClass.GetAttackablePositions(this);
        }

        #region Modify Functions

        public TeamColor GetTeamColor()
        {
            return team;
        }
        public int GetStockHP()
        {
            return data.statHP;
        }
        public int GetCurrentHP()
        {
            return HPCurrent;
        }
        public int GetMaxHP()
        {
            return data.statHP + HPAdditional;
        }
        public void AddHP(int delta)
        {
            HPAdditional += delta;
        }
        public void HealHP(int amount)
        {
            amount = amount < 0 ? 0 : amount;
            HPCurrent = Mathf.Clamp(HPCurrent + amount, 0, data.statHP + HPAdditional);
        }
        public void DamageHP(int amount)
        {
            amount = amount < 0 ? 0 : amount;
            HPCurrent = Mathf.Clamp(HPCurrent - amount, 0, data.statHP + HPAdditional);
        }
        public int GetStockATK()
        {
            return data.statATK;
        }
        public int GetCurrentATK()
        {
            return ATKCurrent;
        }
        public void AddATK(int delta)
        {
            ATKCurrent += delta;
        }
        public int GetProtectability()
        {
            throw new System.NotImplementedException();
        }
        public void AddProtectability(int delta)
        {
            throw new System.NotImplementedException();
        }
        public int GetMovability()
        {
            return movability;
        }
        public void SetMovability(int value)
        {
            movability = value;
        }
        public void AddMovability(int delta)
        {
            movability += delta;
        }
        public int GetSkillUsability()
        {
            return skillAvailability;
        }
        public void AddSkillUsability(int amount)
        {
            skillAvailability += amount;
        }
        public BoardCoord GetPosition()
        {
            return position;
        }
        public void MovePosition(BoardCoord destination)
        {
            position = destination;
        } 
        public BufDebufTag[] GetEffectsWithTag(BufDebufTag tag)
        {
            throw new System.NotImplementedException();
        }
        public void AddEffect(BufDebuf effect)
        {
            throw new System.NotImplementedException();
        }
        public void RemoveEffect(BufDebuf effect)
        {
            throw new System.NotImplementedException();
        }
        public StatusFlag GetStatus()
        {
            return status;
        }

        #endregion
    }
}
