﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Empire_Rewritten
{
    public class FactionController : IExposable
    {
        private List<FactionSettlementData> factionSettlementDataList = new List<FactionSettlementData>();
        private List<FactionCivicAndEthicData> factionCivicAndEthicDataList = new List<FactionCivicAndEthicData>();   

        /// <summary>
        /// Needed for loading
        /// </summary>
        public FactionController() { }

        /// <summary>
        /// Creates a new FactionController using a List of <c>FactionSettlementData</c> structs
        /// </summary>
        /// <param name="factionSettlementDataList"></param>
        public FactionController(List<FactionSettlementData> factionSettlementDataList)
        {
            this.factionSettlementDataList = factionSettlementDataList;
        }

        /// <param name="faction"></param>
        /// <returns>The <c>SettlementManager</c> owned by a given <paramref name="faction"/></returns>
        public SettlementManager GetOwnedSettlementManager(Faction faction)
        {
            foreach (FactionSettlementData factionSettlementData in factionSettlementDataList)
            {
                if (factionSettlementData.owner == faction) return factionSettlementData.SettlementManager;
            }

            return null;
        }

        /// <summary>
        /// Adds one <paramref name="civic"/> to a <paramref name="faction"/>
        /// </summary>
        /// <param name="faction"></param>
        /// <param name="civic"></param>
        public void AddCivicToFaction(Faction faction, CivicDef civic)
        {
            GetOwnedCivicAndEthicData(faction).Civics.Add(civic);
            NotifyCivicsOrEthicsChanged(GetOwnedSettlementManager(faction));
        }

        /// <summary>
        /// Adds multiple <paramref name="civics"/> to a <paramref name="faction"/>
        /// </summary>
        /// <param name="faction"></param>
        /// <param name="civics"></param>
        public void AddCivicsToFaction(Faction faction, IEnumerable<CivicDef> civics)
        {
            foreach (CivicDef civic in civics)
            {
                GetOwnedCivicAndEthicData(faction).Civics.Add(civic);
            }

            NotifyCivicsOrEthicsChanged(GetOwnedSettlementManager(faction));
        }

        /// <summary>
        /// Adds a singel <paramref name="ethic"/> to a <paramref name="faction"/>
        /// </summary>
        /// <param name="faction"></param>
        /// <param name="ethic"></param>
        public void AddEthicToFaction(Faction faction, EthicDef ethic)
        {
            GetOwnedCivicAndEthicData(faction).Ethics.Add(ethic);
            NotifyCivicsOrEthicsChanged(GetOwnedSettlementManager(faction));
        }

        /// <summary>
        /// Adds multiple <paramref name="ethics"/> to a <paramref name="faction"/>
        /// </summary>
        /// <param name="faction"></param>
        /// <param name="ethics"></param>
        public void AddEthicsToFaction(Faction faction, IEnumerable<EthicDef> ethics)
        {
            foreach (EthicDef ethic in ethics)
            {
                GetOwnedCivicAndEthicData(faction).Ethics.Add(ethic);
            }

            NotifyCivicsOrEthicsChanged(GetOwnedSettlementManager(faction));
        }

        public void NotifyCivicsOrEthicsChanged(SettlementManager settlementManager)
        {
            throw new NotImplementedException();
        }

        /// <param name="faction"></param>
        /// <returns>The <c>FactionCivicAndEthicData</c>s linked to a given <paramref name="faction"/></returns>
        public FactionCivicAndEthicData GetOwnedCivicAndEthicData(Faction faction)
        {
            foreach (FactionCivicAndEthicData factionCivicAndEthicData in factionCivicAndEthicDataList)
            {
                if (factionCivicAndEthicData.Faction == faction) return factionCivicAndEthicData;
            }

            return null;
        }

        public void ExposeData()
        {
            Scribe_Collections.Look(ref factionSettlementDataList, "FactionSettlementDataList");
        }
    }
}
